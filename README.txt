Esse modelo é executavel e a comunicação vem pronta entre o Back-end e o Front-end.
As alterações necessárias serão quanto as particularidades do banco, como conexão e os itens e nome da tabela.
Caso os itens da tabela sejam diferentes também lembre de atualizar o front-end para mostrar os itens na tabela.
A conexão com o banco é configurada em SearchEmployees.WebAPI/appsettings.json
A chamada pro banco que retorna a tabela é em SearchEmployees.WebAPI/Repositories/UsuarioRepository.cs
A classe que modela o usuario está em SearchEmployees.WebAPI/Entities/Usuario.cs