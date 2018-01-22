using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace TranslateStrategy
{
    public class AzureTextApiTranslator : ITranslateStrategy, ITranslateToken
    {
        static string translatorEndPoint = "https://api.microsofttranslator.com/V2/Http.svc/Translate";
        static string tokenEndPoint = "https://api.cognitive.microsoft.com/sts/v1.0/issueToken";          

        public async Task<string> TranslateText(string translateText, string sourceLang, string targetLang, string accessToken)
        {           
            string queryStringParameters = $"?text={System.Net.WebUtility.UrlEncode(translateText)}&to={targetLang}&from={sourceLang}";
            var translateUri = $"{translatorEndPoint}{queryStringParameters}";
            using (var client = new HttpClient())
            {                
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var response = await client.GetAsync(translateUri);               
                if (!response.IsSuccessStatusCode )
                {
                    return string.Empty;
                }
                var result = await response.Content.ReadAsStringAsync();
                var xm = XElement.Parse(result);
                return xm.Value;
            }
        }

        public async Task<string> GetAuthenticationToken(string subkey)
        {  
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subkey);       
                var response = await client.PostAsync(tokenEndPoint, null);
                if (!response.IsSuccessStatusCode)
                {
                    return string.Empty;
                }
                var token = await response.Content.ReadAsStringAsync();               
                return token;
            }
        }
    }
}
