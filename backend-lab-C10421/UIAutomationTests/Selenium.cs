using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace UIAutomationTests
{ 
public class Selenium
    {
        IWebDriver _driver;
        Actions _actions;
        WebDriverWait _wait;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _actions = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void Enter_To_List_of_Countries_Test()
        {
            //Abre una nueva ventana
            var URL = "http://localhost:8080/";
            //Maximiza la pantalla
            _driver.Manage().Window.Maximize();
            //Navega a la pagina que se necesita probar
            _driver.Navigate().GoToUrl(URL);
            int cantidadPaisesTabla = _driver.FindElements(By.CssSelector("#lista-paises tbody tr")).Count;

            var botonAgregarPais = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("boton-ir-a-agregar-pais")));
            _actions.MoveToElement(botonAgregarPais).Click().Perform();

            var inputNombrePais = _driver.FindElement(By.Id("name"));
            var selectContinente = _driver.FindElement(By.Id("continente"));
            var inputIdioma = _driver.FindElement(By.Id("idioma"));
            inputNombrePais.SendKeys("Mexico");
            selectContinente.SendKeys("América");
            inputIdioma.SendKeys("Español");

            var botonGuardarPais = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btn-guardar-pais")));
            botonGuardarPais.Click();

            Assert.Greater(_driver.FindElements(By.CssSelector("#lista-paises tbody tr")).Count, cantidadPaisesTabla);
        }
    }
}
