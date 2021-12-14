using System;
using ApiTest.Utils;
using Aquality.Selenium.Browsers;
using NUnit.Framework;

namespace ApiTest.Tests
{
    public abstract class BaseTest
    {
        [SetUp]
        protected void SetUp()
        {
            AqualityServices.SetDefaultFactory();
            AqualityServices.Browser.GoTo(UtilsJson.ReadJsonFile("url"));
        }

        [TearDown]
        protected void TeatDown()
        {
            AqualityServices.Browser.Quit();
        }
    }
}