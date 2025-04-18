# DotNet RestSharp Test API - GoRest

<div align="center">
  <img src="Assets/banner-repository.png" />
</div>

Este projeto é uma aplicação de testes automatizados para a API pública [GoRest](https://gorest.co.in/), utilizando .NET, RestSharp e XUnit. Ele inclui serviços para interagir com os endpoints da API e testes para validar as operações.

## Estrutura do Projeto

### Diretórios Principais

- **`Services`**: Contém a classe `GoRestService`, que encapsula as chamadas à API GoRest.
- **`Models`**: Contém os modelos de dados utilizados para serialização e deserialização das respostas da API.
- **`Tests`**: Contém os testes automatizados escritos com XUnit para validar os endpoints da API.
- **`Utils`**: Contém utilitários como o carregamento de variáveis de ambiente.

### Principais Arquivos

- **`GoRestService.cs`**: Implementa os métodos para interagir com os endpoints da API GoRest, como criar, atualizar, excluir e buscar usuários, posts, comentários e tarefas.
- **`Env.cs`**: Gerencia o carregamento de variáveis de ambiente a partir do arquivo `.env`.
- **`GoRestTests.cs`**: Contém os testes automatizados para validar os métodos do serviço `GoRestService`.

---

## Configuração do Ambiente

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) instalado.
- [RestSharp](https://restsharp.dev/) para chamadas HTTP.
- [XUnit](https://xunit.net/) para testes.
- [DotNetEnv](https://github.com/tonerdo/dotnet-env) para carregar variáveis de ambiente.

### Configuração do Arquivo `.env`

Crie um arquivo `.env` na raiz do projeto com o seguinte conteúdo:

```properties
GOREST_TOKEN="Bearer SEU_TOKEN_AQUI"
```

Substitua `SEU_TOKEN_AQUI` pelo token de autenticação da API GoRest.

---

## Como Executar o Projeto

### 1. Clonar o Repositório

Clone o repositório para sua máquina local:

```bash
git clone https://github.com/seu-usuario/dotnet-restsharp-test-api-go-rest.git
cd dotnet-restsharp-test-api-go-rest
```

### 2. Restaurar Dependências

Restaure as dependências do projeto:

```bash
dotnet restore
```

### 3. Configurar o Arquivo `.env`

Certifique-se de criar o arquivo `.env` na raiz do projeto, conforme descrito na seção **Configuração do Arquivo `.env`**.

### 4. Executar os Testes

Para rodar os testes automatizados, execute o seguinte comando:

```bash
dotnet test
```

Isso executará todos os testes definidos no projeto e exibirá os resultados no terminal.

---

## Funcionalidades

### Serviços Disponíveis (`GoRestService`)

- **Usuários**
  - `GetAllUsersAsync()`: Busca todos os usuários.
  - `GetUserByIdAsync(int id)`: Busca um usuário pelo ID.
  - `GetUsersByQueryAsync(string key, string value)`: Busca usuários com base em uma query string.
  - `CreateUserAsync(User user)`: Cria um novo usuário.
  - `UpdateUserAsync(int userId, User user)`: Atualiza um usuário existente.
  - `DeleteUserAsync(int userId)`: Exclui um usuário.

- **Comentários**
  - `GetAllCommentsAsync()`: Busca todos os comentários.

- **Posts**
  - `GetAllPostsAsync()`: Busca todos os posts.

- **Tarefas (ToDos)**
  - `GetAllTodosAsync()`: Busca todas as tarefas.

---

## Tecnologias Utilizadas

- **.NET 9.0**: Framework principal para o desenvolvimento.
- **RestSharp**: Biblioteca para chamadas HTTP.
- **XUnit**: Framework de testes.
- **FluentAssertions**: Biblioteca para asserções fluentes nos testes.
- **Newtonsoft.Json**: Biblioteca para manipulação de JSON.
- **DotNetEnv**: Biblioteca para carregar variáveis de ambiente.

---

## Contribuindo
Se você deseja apoiar este projeto, deixe um ⭐.

___

Feito com 💙 por [Marco Antonio](https://www.linkedin.com/in/mrk-silva/).