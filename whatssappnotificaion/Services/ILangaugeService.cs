using whatssappnotificaion.Models.localize;

namespace whatssappnotificaion.Services
{
    public interface ILangaugeService
    {
        IEnumerable<Language> GetLanguages();
        Language GetLanguageByCulture(string culture);
    }
}
