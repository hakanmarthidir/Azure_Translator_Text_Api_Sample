using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslateStrategy;

namespace TranslatorTests
{
    [TestClass]
    public class AzureTranslatorTest
    {
        string key = string.Empty;

        [TestInitialize]
        public void Initialize()
        {
            key = System.Configuration.ConfigurationManager.AppSettings["SubKey"];
        }

        [TestMethod]
        public void AzureTranslator_Token_ShouldNotBeEmpty()
        {
            var accessToken = string.Empty;
            Task.Run(async () =>
            {
                var translator = new TranslateManager(new AzureTextApiTranslator());
                accessToken = await translator.GetToken(key);
            }).Wait();
            Debug.WriteLine("Token : " + accessToken);
            Assert.AreNotEqual(null, accessToken);
            Assert.AreNotEqual(string.Empty, accessToken);
        }

        [TestMethod]
        public void AzureTranslator_Translate_ShouldNotBeEmpty()
        {
            var translateResult = string.Empty;
            var accessToken = string.Empty;
            Task.Run(async () =>
             {
                 var translator = new TranslateManager(new AzureTextApiTranslator());
                 accessToken = await translator.GetToken(key);
                 translateResult = await translator.Translate("naber", "tr", "en", accessToken);
                 Debug.WriteLine("Translate Result : " + translateResult);                 
             }).Wait();

            Assert.AreNotEqual(string.Empty, translateResult);           
        }       

    }
}
