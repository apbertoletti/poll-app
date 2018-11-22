
# Poll Application API

Sistema de gerenciamento de enquetes e votações eletrônica.

## Iniciando

### Pre-requisitos

* [.Net Core](https://www.microsoft.com/net/download) - Framework 
* [Sql Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) - Banco de dados

### Instalação

 1. Descompactar o arquivo PollApp.zip 
 2. Abrir o arquivo PollApp.sln na IDE Visual Studio 
 4. Abrir a classe Settings.cs do projeto "PollApp.Shared" e editar nela a propriedade ConnectionString, apontando para a instância de SQL Server que será utilizada na aplicação.
```
namespace PollApp.Shared
{
    public static class Settings
    {
        /** Informe aqui a string de conexão do BD **/
        public static string ConnectionString = @"Server=(local);Database=PollApp;Trusted_Connection=True;";
    }
}
```
 
 6. Abrir o Package Manager Console (PMC) do Visual Studio
 7. Setar o Default Project do PMC para o projeto "PollApp.Infra" 
 8. Executar o comando abaixo, a fim de criar o script de criação do BD.
```
Add-Migration CriarBD
```
 8. Executar o comando abaixo, a fim de criar a estrutura do BD.
```
Update-Database
```
 
 
## Rodar os testes

Abaixo as orientações para realização dos testes na API

### Testes automatizados
Existe uma suite de testes automatizados que verifica os principais resultados esperados da aplicação. Siga os passos abaixo para rodá-los:

 1. Abra a o arquivo PollApp.sln na IDE Visual Studio 
 2. Acesse o menu Test -> Run -> All tests (CTRL + R, A)

### Testes manuais
Os testes manuais poderão ser executados acessando diretamente o endpoints da API conforme solicitada no PDF do desafio proposto. Também foi implementada uma documentação Swagger que poderá facilitar esta tarefa.

1. Abra a o arquivo PollApp.sln na IDE Visual Studio 
2. Setar o projeto "PollApp.API" como Startup Project da solução
3. Execute a aplicação através do menu Debug -> Start debug (F5)


## Feito com

* [Asp.Net Core](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-2.1) - Framework web utilizado
* [Sql Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) - Banco de dados
* [EF Core](https://docs.microsoft.com/pt-br/ef/core/) - ORM para conectar no BD
* [Git](https://git-scm.com/) - Versionador de código fonte
* [Swagger](https://swagger.io/) - Documentação da API
* [Visual Studio](https://visualstudio.microsoft.com/) - IDE de desenvolvimento


## Autor

* **André P. Bertoletti** - [LinkedIn](https://www.linkedin.com/in/apbertoletti)

