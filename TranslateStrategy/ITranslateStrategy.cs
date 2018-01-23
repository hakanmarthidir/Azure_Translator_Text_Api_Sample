using System.Threading.Tasks;

namespace TranslateStrategy
{
    public interface ITranslateStrategy
    {
        Task<string> TranslateText(string translateText, string sourceLang, string targetLang, string accessToken);
        Task<string> GetAuthenticationToken(string subkey);
    }
}
