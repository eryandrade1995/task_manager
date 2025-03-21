# Título
<h2 align="center">Task Manager API</h2>
API RESTful de gerenciamento e controle de tarefas.
<p align="center">
<img loading="lazy" src="https://img.shields.io/badge/.NET-v8.0-purple"/>
</p>


# Índice
* [Título](#Título)
* [Índice](#Índice)
* [Sobre o Projeto](#Sobre-o-Projeto)
* [Tecnologias Utilizadas](#Tecnologias-Utilizadas)
* [Pré-Requisitos](#Pré-Requisitos)
* [Instalação](#Instalação)
* [Configuração](#Configuracao)
* [Como Usar](#Como-Usar)
* [Testes](#Teste)
* [Migração](#Migração)


# Sobre o Projeto
Aplicação desenvolvida como base para construção de API RESTful simulando um controle e gerenciamento de tarefas.

# Tecnologias Utilizadas
* .NET 8
* ASP.NET Core
* Entity Framework Core
* Swagger
* PostgreSQL
* NUnit

# Pré-Requisitos
.NET Framework v8.0, PostGreSQL

# Instalação
1. Clone o Repositório: git clone https://github.com/eryandrade1995/task_manager.git
2. Navegue até o diretório do projeto: cd seu-repositorio
3. Instale as dependências: dotnet restore

# Configuração
1. Configuração do Banco de Dados:
   Na camada de API, edite o arquivo appsetting.json como o modelo abaixo:
"ConnectionStrings": {
    "DatabaseTaskManager": "Server=localhost;Database=nome-do-banco;Trusted_Connection=True;"
}
2. Configuração do IP:
  Na camada de API abra a pasta Properties, edite o arquivo launchsettings.json na tag applicationUrl como o exemplo abaixo:
      "applicationUrl": "http://localhost:sua-porta;http://seu-ip:sua-porta",

# Como Usar
<h2>Iniciar a API</h2>
1. Entre na camada da API: cd .\TaskManager.API\ 
2. Execute: dotnet run

# Testes
Para rodar os testes da API, você pode utilizar o comando: dotnet test

# Migração
Para atualizar a database, navegue até o seu repositório e utilize o comando:  dotnet ef database update -s .\TaskManager.API\ -p .\TaskManager.Infrastructure\
