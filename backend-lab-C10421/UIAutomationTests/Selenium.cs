using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace UIAutomationTests
{ 
    public class Selenium
    {
        IWebDriver _driver;
        Actions _actions;

        [SetUp]   
        public void Setup()
        {
            _driver = new ChromeDriver();
            _actions = new Actions(_driver);
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
            int cantidadPaises = _driver.FindElements(By.Id("lista-paises")).Count;
            var botonAgregarPais = _driver.FindElement(By.Id("boton-ir-a-agregar-pais"));
            _actions.MoveToElement(botonAgregarPais).Click().Perform();

            var inputNombrePais = _driver.FindElement(By.Id("name"));
            var selectContinente = _driver.FindElement(By.Id("continente"));
            var inputIdioma = _driver.FindElement(By.Id("idioma"));

            inputNombrePais.SendKeys("Mexico");
            selectContinente.SendKeys("América");
            inputIdioma.SendKeys("Español");
            _driver.FindElement(By.Id("btn-guardar-pais")).Click();

            Assert.Greater(_driver.FindElements(By.Id("lista-paises")).Count, cantidadPaises);
        }
    }
}
