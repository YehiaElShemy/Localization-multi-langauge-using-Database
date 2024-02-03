using Microsoft.EntityFrameworkCore;
using whatssappnotificaion.Models.DataContext;
using whatssappnotificaion.Models.localize;

namespace whatssappnotificaion.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly ApplicationDbContext db;

        public LocalizationService(ApplicationDbContext _db)
        {
            db = _db;
        }
        public StringResource GetStringResource(string resourceKey, int languageId)
        {
          return  db.stringResources.FirstOrDefault(k => k.key.Trim().ToLower() == resourceKey.Trim().ToLower() 
          && k.LangaugeId == languageId);
        }
    }
}
