using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TranslateStrategy
{
    public class TranslateManager
    {
        private readonly ITranslateStrategy _translator;
        public TranslateManager(ITranslateStrategy translator)
        {
            this._translator = translator;
        }

        public Task<string> Translate(string text, string source, string target, string token)
        {            
            return _translator.TranslateText(text, source, target,token);
        }

        public Task<string> GetToken(string subkey)
        {
            return _translator.GetAuthenticationToken(subkey);
        }
    }
}
