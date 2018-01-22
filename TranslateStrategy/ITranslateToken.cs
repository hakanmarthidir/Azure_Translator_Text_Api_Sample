using System.Threading.Tasks;

namespace TranslateStrategy
{
    public interface ITranslateToken
    {
        Task<string> GetAuthenticationToken(string subkey);
    }
}
