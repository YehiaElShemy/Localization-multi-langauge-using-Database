using Microsoft.EntityFrameworkCore;
using whatssappnotificaion.Models.DataContext;
using whatssappnotificaion.Models.localize;

namespace whatssappnotificaion.Services
{
    public class LangaugeService : ILangaugeService
    {
        private readonly ApplicationDbContext db;

        public LangaugeService(ApplicationDbContext _db)
        {
            db = _db;
        }

        public Language GetLanguageByCulture(string culture)
        {
            return db.languages.FirstOrDefault(l=>l.Culture.Trim().ToLower()==culture.Trim().ToLower());
        }

        public  IEnumerable<Language> GetLanguages()
        {
           return  db.languages.ToList();
        }
    }
}
