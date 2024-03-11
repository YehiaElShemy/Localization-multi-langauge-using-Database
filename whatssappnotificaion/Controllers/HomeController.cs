using MailChimp.Net.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;
using whatssappnotificaion.Models;
using System.Runtime;
using static whatssappnotificaion.Controllers.HomeController;
using MailChimp.Net.Core;

namespace whatssappnotificaion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            IPInfo iPInfo = new IPInfo();
            _logger = logger;
        }

        public  async Task< IActionResult> Index()
        {
            string apiUrl = "https://ipinfo.io";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result);

                    // Parse the result (which is in JSON format) to get details like country, city, etc.
                    // You can use a JSON library like Newtonsoft.Json to deserialize the result.
                    var ipInfo = JsonConvert.DeserializeObject<IPInfo>(result);
                    Console.WriteLine($"IP Address: {ipInfo.Ip}");
                    Console.WriteLine($"Country: {ipInfo.Country}");
                    Console.WriteLine($"City: {ipInfo.City}");
                }

            }



            string userAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"];

            // Retrieve IP address
            string ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();
            string strHostName = string.Empty;
            // Getting Ip address of local machine...
            // First get the host name of local machine.
            strHostName = Dns.GetHostName();
            Console.WriteLine("Local Machine's Host Name: " + strHostName);
            // Then using host name, get the IP address list..
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;

            for (int i = 0; i < addr.Length; i++)
            {
                Console.WriteLine("IP Address {0}: {1} ", i, addr[i].ToString());
            }
            //Console.ReadLine();
            string ip = GetLocalIpAddress();

            PromoCode promoCode = new PromoCode();
            string code = promoCode.Code;
            return View();
        }

        public IActionResult lang()
        {
            string? culture = Request.Query["culture"];
            if (culture != null)
            {
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            }
            string returnUrl = Request.Headers["Referer"].ToString() ?? "/";
            return Redirect(returnUrl);
            /*     if (Url.IsLocalUrl(returnUrl))
                 {
                     return LocalRedirect(returnUrl);
                 }
                 else
                 {
                     // If it's not a local URL, you can choose to redirect to a default local URL
                     return RedirectToAction("Index", "Home");
                 }*/
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
            // return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public static string GetLocalIpAddress()
        {
            UnicastIPAddressInformation mostSuitableIp = null;


            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var network in networkInterfaces)
            {
                if (network.OperationalStatus != OperationalStatus.Up)
                    continue;

                var properties = network.GetIPProperties();
                if (properties.GatewayAddresses.Count == 0)
                    continue;

                foreach (var address in properties.UnicastAddresses)
                {
                    if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                        continue;

                    if (IPAddress.IsLoopback(address.Address))
                        continue;

                    if (!address.IsDnsEligible)
                    {
                        if (mostSuitableIp == null)
                            mostSuitableIp = address;
                        continue;
                    }

                    // The best IP is the IP got from DHCP server  
                    if (address.PrefixOrigin != PrefixOrigin.Dhcp)
                    {
                        if (mostSuitableIp == null || !mostSuitableIp.IsDnsEligible)
                            mostSuitableIp = address;
                        continue;
                    }
                    return address.Address.ToString();
                }
            }
            return mostSuitableIp != null
                ? mostSuitableIp.Address.ToString()
                : "";
        }
    }

}