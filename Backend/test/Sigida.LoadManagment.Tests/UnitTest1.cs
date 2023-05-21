using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;

namespace Sigida.LoadManagment.Tests
{
    public class Tests
    { 
        private WebApplicationFactory<WebApiStartup> _factory;
        private HttpClient _client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _factory = new WebApplicationFactory<WebApiStartup>();
            _client = _factory.CreateClient();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [Test]
        public async Task GetWeater_EndpointReturnsOk()
        {
            // Создаем клиент для отправки HTTP-запросов
            var client = _factory.CreateClient();
                
            // Отправляем GET-запрос на указанный путь
            var response = await client.GetAsync("/weatherforecast");
            var data = await response.Content.ReadAsStringAsync();
            // Проверяем, что код состояния HTTP равен 200 (OK)
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}