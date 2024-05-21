
Esta é uma API mínima em C# e ASP.NET Core para cadastro de usuários (usuários), utilizando o padrão MVC (Model-View-Controller) e MongoDB como banco de dados. A API pode ser testada utilizando o Swagger, permitindo uma interface interativa para execução de requisições.

Funcionalidades
Cadastro de usuários
Consulta de usuários
Atualização de informações de usuários
Remoção de usuários
Pré-requisitos
Antes de começar, certifique-se de ter os seguintes componentes instalados:

Visual Studio (ou Visual Studio Code com a extensão C#)
.NET SDK
MongoDB (instalado e em execução)
Configuração
Clone o repositório do projeto para sua máquina local:

bash
Copiar código
git clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio
Abra o projeto no Visual Studio.

Configure a string de conexão do MongoDB no arquivo appsettings.json:

json
Copiar código
{
  "MongoDB": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "UserDB",
    "CollectionName": "Usuarios"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
Estrutura do Projeto
Controllers/: Contém os controladores da API.
Models/: Contém as classes de modelo (usuários).
Services/: Contém os serviços de acesso ao MongoDB.
appsettings.json: Arquivo de configuração da aplicação.
Program.cs: Ponto de entrada da aplicação.
Startup.cs: Configuração dos serviços e pipeline de requisição HTTP.
Executando a API
No Visual Studio, selecione o projeto e pressione F5 para iniciar a aplicação.

A API estará disponível em https://localhost:5001 (ou http://localhost:5000 para HTTP).

Para acessar o Swagger e testar a API, navegue até https://localhost:5001/swagger (ou http://localhost:5000/swagger).

Endpoints
Abaixo estão os principais endpoints da API:

GET /api/usuarios

Retorna a lista de todos os usuários.
GET /api/usuarios/{id}

Retorna os dados de um usuário específico.
POST /api/usuarios

Cria um novo usuário.
Exemplo de Corpo da Requisição:

json
Copiar código
{
  "nome": "John Doe",
  "email": "johndoe@example.com",
  "senha": "password123"
}
PUT /api/usuarios/{id}
Atualiza os dados de um usuário específico.
Exemplo de Corpo da Requisição:

json
Copiar código
{
  "nome": "Jane Doe",
  "email": "janedoe@example.com",
  "senha": "newpassword123"
}
DELETE /api/usuarios/{id}
Remove um usuário específico.
Testes
Os testes podem ser executados diretamente pelo Swagger. Basta acessar https://localhost:5001/swagger e utilizar a interface para enviar requisições para os endpoints disponíveis.
