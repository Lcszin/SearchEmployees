using Microsoft.AspNetCore.Mvc; // Necessário para OkObjectResult
using Moq;
using SearchEmployees.WebAPI.Entities;
using SearchEmployees.Controllers;
using SearchEmployees.Repositories;
using Xunit;

namespace WebAppUsuarios.Tests
{
    public class UsuariosControllerTests
    {
        [Fact] // [Fact] marca este método como um teste que o xUnit deve executar
        public async Task GetUsuarios_QuandoChamado_RetornaOkComListaDeUsuarios()
        {
            // Padrão de Teste "Arrange, Act, Assert"

            // 1. Arrange (Preparação)
            // -------------------------
            // Cria uma lista de usuários falsa que servirá como nosso "banco de dados" em memória.
            var usuariosFalsos = new List<Usuario>
            {
                new Usuario { Id = 1, Nome = "Usuário de Teste 1", Email = "teste1@email.com", Cidade = "Cidade Teste" },
                new Usuario { Id = 2, Nome = "Usuário de Teste 2", Email = "teste2@email.com", Cidade = "Cidade Teste" }
            };

            // Cria um "Mock" (simulação) da nossa interface IUsuarioRepository.
            var mockRepositorio = new Mock<IUsuarioRepository>();

            // Configura o mock: "Quando o método GetAllAsync for chamado,
            // retorne a nossa lista de usuários falsos".
            mockRepositorio.Setup(repo => repo.GetAllAsync()).ReturnsAsync(usuariosFalsos);

            // Cria uma instância do nosso Controller, mas em vez de passar o repositório real,
            // passamos o nosso MOCK. O Controller não sabe a diferença!
            var controller = new UsuariosController(mockRepositorio.Object);


            // 2. Act (Ação)
            // -------------------------
            // Executa o método que queremos testar.
            var resultado = await controller.GetUsuarios();


            // 3. Assert (Verificação)
            // -------------------------
            // Verifica se o resultado da ação é do tipo esperado (um status 200 OK com dados).
            var okResult = Assert.IsType<OkObjectResult>(resultado.Result);

            // Verifica se os dados dentro do resultado são do tipo esperado (uma lista de usuários).
            var usuariosRetornados = Assert.IsAssignableFrom<IEnumerable<Usuario>>(okResult.Value);

            // Verifica se a quantidade de usuários retornados é a mesma que a da nossa lista falsa.
            Assert.Equal(2, usuariosRetornados.Count());
        }
    }
}