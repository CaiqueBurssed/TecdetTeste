# Tecdet

[GitHub](https://github.com/CaiqueBurssed/TecdetTeste)

# ConsoleApp com .NET Core & EntityFramework 

Projeto de uma Console Aplication, para a leitura e deserialização de um diretório preenchido por objetos Json.

## Pré-requisitos

* Visual Studio 2019
* .NET Core SDK
* SQL Server versão 15.SQLEXPRESS
* EntityFramework
* Newtonsoft.Json

## ConsoleApp Passagem

*  Essa aplicação foi desenvolvida em C#, com acesso a um banco de dados SQL Server, com o intuito de processar e deserializar objetos .json armazenados em um diretório escolhido.


## Instruções de Teste da Aplicação

Abaixo irei listar algumas instruções que recomendo para o teste da aplicação: 

### Alterar ConnectionString

Antes de podermos rodar propriamente a aplicação, será necessário substituir a string de conexão da Classe **PassagemContext**, no método `OnConfiguring` por uma string de conexão que possui o seu servidor, usuário e senha.

> Exemplo: 

	optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PassagemDB;Trusted_Connection=True;User ID=sa;Password=senha123;");
	
Uma vez que sua string de conexão esteja propriamente adequada com a de seu servidor local,  iremos  precisar criar o banco de dados em seu SqlServer.

Para isso, usaremos o próprio terminal do Visual Studio.
* Clique em Exibir e depois Terminal, ou Ctrl + ' ;
* Entre em seu terminal o seguinte código:

		> dotnet ef database update
	
Isso vai fazer com que se crie o banco de dados com o  nome e local especificado na string de conexão do método `OnConfiguring`. Irá também criar a tabela `Passagens` no banco,  como mostrado abaixo:

![Exemplo de criação do Banco de Dados](https://drive.google.com/file/d/1sl2TWkYCYzZOGVDbWgqI7s1jh_CFmQZS/view?usp=sharing)

## Rodar aplicação

Uma vez configurada toda a  parte de criação do Banco de Dados, a aplicação está pronta para processar o diretório escolhido, e incluir os objetos .Json no banco. 
#
