using whatssappnotificaion.Models.localize;

namespace whatssappnotificaion.Services
{
    public interface ILocalizationService
    {
        StringResource GetStringResource(string resourceKey,int languageId);
    }
}
