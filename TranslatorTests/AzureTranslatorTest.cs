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
                var translator = new AzureTextApiTranslator();
                accessToken = await translator.GetAuthenticationToken(key);
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
                 var translator = new AzureTextApiTranslator();
                 accessToken = await translator.GetAuthenticationToken(key);
                 translateResult = await translator.TranslateText("naber", "tr", "en","eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzY29wZSI6Imh0dHBzOi8vYXBpLm1pY3Jvc29mdHRyYW5zbGF0b3IuY29tLyIsInN1YnNjcmlwdGlvbi1pZCI6IjAzYjIyZjcwZjhhOTRlZWRhOTA5Y2M3MGMzNGQyMTg4IiwicHJvZHVjdC1pZCI6IlRleHRUcmFuc2xhdG9yLkYwIiwiY29nbml0aXZlLXNlcnZpY2VzLWVuZHBvaW50IjoiaHR0cHM6Ly9hcGkuY29nbml0aXZlLm1pY3Jvc29mdC5jb20vaW50ZXJuYWwvdjEuMC8iLCJhenVyZS1yZXNvdXJjZS1pZCI6Ii9zdWJzY3JpcHRpb25zLzQzZTFmNDA5LWY0ODgtNGJlOS04ZTk5LTU3NGE5NGZhZGJlOS9yZXNvdXJjZUdyb3Vwcy90cmFuc2xhdG9yTWFydC9wcm92aWRlcnMvTWljcm9zb2Z0LkNvZ25pdGl2ZVNlcnZpY2VzL2FjY291bnRzL3RyYW5zbGF0b3JNYXJ0IiwiaXNzIjoidXJuOm1zLmNvZ25pdGl2ZXNlcnZpY2VzIiwiYXVkIjoidXJuOm1zLm1pY3Jvc29mdHRyYW5zbGF0b3IiLCJleHAiOjE1MTY2NTYyNzZ9.W0MZF6BzMqxnxBHGtB-mMrlgaReSKguK1JnpA6rtKaw");
                 Debug.WriteLine("Translate Result : " + translateResult);                 
             }).Wait();

            Assert.AreNotEqual(string.Empty, translateResult);           
        }       

    }
}
