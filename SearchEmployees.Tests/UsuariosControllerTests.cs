using Microsoft.AspNetCore.Mvc; // Necess�rio para OkObjectResult
using Moq;
using SearchEmployees.WebAPI.Entities;
using SearchEmployees.Controllers;
using SearchEmployees.Repositories;
using Xunit;

namespace WebAppUsuarios.Tests
{
    public class UsuariosControllerTests
    {
        [Fact] // [Fact] marca este m�todo como um teste que o xUnit deve executar
        public async Task GetUsuarios_QuandoChamado_RetornaOkComListaDeUsuarios()
        {
            // Padr�o de Teste "Arrange, Act, Assert"

            // 1. Arrange (Prepara��o)
            // -------------------------
            // Cria uma lista de usu�rios falsa que servir� como nosso "banco de dados" em mem�ria.
            var usuariosFalsos = new List<Usuario>
            {
                new Usuario { Id = 1, Nome = "Usu�rio de Teste 1", Email = "teste1@email.com", Cidade = "Cidade Teste" },
                new Usuario { Id = 2, Nome = "Usu�rio de Teste 2", Email = "teste2@email.com", Cidade = "Cidade Teste" }
            };

            // Cria um "Mock" (simula��o) da nossa interface IUsuarioRepository.
            var mockRepositorio = new Mock<IUsuarioRepository>();

            // Configura o mock: "Quando o m�todo GetAllAsync for chamado,
            // retorne a nossa lista de usu�rios falsos".
            mockRepositorio.Setup(repo => repo.GetAllAsync()).ReturnsAsync(usuariosFalsos);

            // Cria uma inst�ncia do nosso Controller, mas em vez de passar o reposit�rio real,
            // passamos o nosso MOCK. O Controller n�o sabe a diferen�a!
            var controller = new UsuariosController(mockRepositorio.Object);


            // 2. Act (A��o)
            // -------------------------
            // Executa o m�todo que queremos testar.
            var resultado = await controller.GetUsuarios();


            // 3. Assert (Verifica��o)
            // -------------------------
            // Verifica se o resultado da a��o � do tipo esperado (um status 200 OK com dados).
            var okResult = Assert.IsType<OkObjectResult>(resultado.Result);

            // Verifica se os dados dentro do resultado s�o do tipo esperado (uma lista de usu�rios).
            var usuariosRetornados = Assert.IsAssignableFrom<IEnumerable<Usuario>>(okResult.Value);

            // Verifica se a quantidade de usu�rios retornados � a mesma que a da nossa lista falsa.
            Assert.Equal(2, usuariosRetornados.Count());
        }
    }
}