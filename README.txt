Esse modelo � executavel e a comunica��o vem pronta entre o Back-end e o Front-end.
As altera��es necess�rias ser�o quanto as particularidades do banco, como conex�o e os itens e nome da tabela.
Caso os itens da tabela sejam diferentes tamb�m lembre de atualizar o front-end para mostrar os itens na tabela.
A conex�o com o banco � configurada em SearchEmployees.WebAPI/appsettings.json
A chamada pro banco que retorna a tabela � em SearchEmployees.WebAPI/Repositories/UsuarioRepository.cs
A classe que modela o usuario est� em SearchEmployees.WebAPI/Entities/Usuario.cs