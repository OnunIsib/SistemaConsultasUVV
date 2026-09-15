# Sistema de Gestão de Consultas UVV
Trabalho feito por Nuno Bisi Bolsanello para a disciplina de Desenvolvimento Web Back-end da UVV.
Matricula 202526921

Sistema web desenvolvido em C# com ASP.NET Core MVC para gerenciamento de consultas.

O sistema permite que usuários realizem cadastro e login e, após a autenticação, possam cadastrar, visualizar, editar e excluir suas próprias consultas.

## Funcionalidades

* Cadastro de usuários
* Login e logout
* Senhas armazenadas com hash BCrypt
* Autenticação utilizando Cookie Authentication
* Cadastro de consultas
* Listagem das consultas do usuário logado
* Edição de consultas
* Exclusão de consultas
* Validação dos dados utilizando DataAnnotations
* Proteção contra requisições não autorizadas
* Isolamento das consultas por usuário
* Persistência dos dados em SQL Server
* Entity Framework Core Code First
* Migrations para criação e atualização do banco de dados

## Tecnologias utilizadas

* C#
* .NET 10
* ASP.NET Core MVC
* Entity Framework Core 10
* SQL Server
* Bootstrap
* BCrypt.Net-Next
* Visual Studio
* Git e GitHub

## Estrutura do projeto

```text
SistemaConsultasUVV/
│
├── Controllers/
│   ├── AccountController.cs
│   ├── ConsultasController.cs
│   └── HomeController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Models/
│   ├── Usuario.cs
│   └── Consulta.cs
│
├── ViewModels/
│   ├── LoginViewModel.cs
│   └── CadastroViewModel.cs
│
├── Views/
│   ├── Account/
│   └── Consultas/
│
├── Migrations/
│
├── wwwroot/
│
├── appsettings.json
├── Program.cs
└── README.md
```

## Pré-requisitos

Para executar o projeto, é necessário ter instalado:

* .NET 10 SDK
* SQL Server ou SQL Server Express
* Visual Studio 2022 ou versão compatível
* Entity Framework Core Tools

## Configuração do banco de dados

O projeto utiliza SQL Server.

A conexão com o banco está configurada no arquivo:

```text
appsettings.json
```

Exemplo:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=SistemaConsultasUVV;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Caso seja utilizado outro servidor SQL Server, altere a string de conexão conforme o ambiente.

## Criação do banco de dados

Abra o projeto no Visual Studio.

Abra:

```text
Tools
→ NuGet Package Manager
→ Package Manager Console
```

Execute:

```powershell
Update-Database
```

O Entity Framework Core executará as migrations e criará o banco de dados `SistemaConsultasUVV`.

## Executando o projeto

Após configurar o banco de dados:

1. Abra o projeto no Visual Studio.
2. Confirme a string de conexão no `appsettings.json`.
3. Execute o projeto utilizando o botão de execução do Visual Studio.
4. A aplicação abrirá a tela de login.
5. Caso ainda não possua uma conta, utilize a opção de cadastro.
6. Após realizar o login, será possível acessar o gerenciamento de consultas.

## Fluxo do sistema

### Cadastro

O usuário informa:

* Nome
* E-mail
* Senha
* Confirmação da senha

A senha é armazenada utilizando hash BCrypt.

### Login

O usuário informa seu e-mail e senha.

Após a autenticação, o sistema cria uma sessão utilizando Cookie Authentication.

### Consultas

Após o login, o usuário pode:

* Criar uma consulta
* Visualizar suas consultas
* Editar uma consulta
* Excluir uma consulta

Cada usuário visualiza somente suas próprias consultas.

## Segurança

O projeto utiliza:

* BCrypt para armazenamento seguro das senhas
* `[Authorize]` para proteção das áreas autenticadas
* Cookie Authentication
* `[ValidateAntiForgeryToken]` nos formulários de alteração de dados
* Validação através de DataAnnotations
* Restrição das consultas pelo `UsuarioId` do usuário autenticado

## Migration

A migration inicial do projeto é:

```text
InitialCreate
```

Para atualizar ou criar o banco de dados:

```powershell
Update-Database
```

Para verificar as migrations existentes:

```powershell
Get-Migration
```

## Credenciais de teste

O sistema permite realizar o cadastro diretamente pela tela de cadastro.

Para demonstração, pode ser criada uma conta de teste, por exemplo:

```text
Nome: Usuário Teste
E-mail: teste@teste.com
Senha: 123456
```

## Vídeo de demonstração

Vídeo demonstrando o funcionamento do sistema:

**[INSIRA AQUI O LINK DO VÍDEO]**

O vídeo demonstra:

* Cadastro de usuário
* Login
* Cadastro de consulta
* Listagem de consultas
* Edição de consulta
* Exclusão de consulta
* Validação dos campos
* Isolamento das consultas entre usuários

## Autores

Projeto desenvolvido para a disciplina de Desenvolvimento Web Back-end da UVV.

Aluno: Nuno Bisi

## Licença

Projeto desenvolvido para fins acadêmicos.
