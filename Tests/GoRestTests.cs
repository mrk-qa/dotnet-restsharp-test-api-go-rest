using Xunit;
using FluentAssertions;
using Newtonsoft.Json;
using ApiTestsPOC.Models;
using ApiTestsPOC.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ApiTestsPOC.Tests
{
    public class GoRestTests
    {
        private readonly GoRestService _service = new();

        [Fact(DisplayName = "[CT01] Buscar todos os usuários")]
        public async Task CT01_GetAllUsers()
        {
            var response = await _service.GetAllUsersAsync();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var users = JsonConvert.DeserializeObject<List<User>>(response.Content!);
            users.Should().NotBeEmpty();
            users![0].Should().Match<User>(u =>
                u.Id > 0 &&
                !string.IsNullOrWhiteSpace(u.Name) &&
                !string.IsNullOrWhiteSpace(u.Email) &&
                !string.IsNullOrWhiteSpace(u.Gender) &&
                !string.IsNullOrWhiteSpace(u.Status));
        }

        [Fact(DisplayName = "[CT02] Buscar usuário por ID")]
        public async Task CT02_GetUserById()
        {
            var response = await _service.GetUserByIdAsync(7834404);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var user = JsonConvert.DeserializeObject<User>(response.Content!);
            user.Should().NotBeNull();
            user!.Id.Should().Be(7834404);
        }

        [Fact(DisplayName = "[CT03] Buscar usuário por nome")]
        public async Task CT03_GetUserByName()
        {
            var response = await _service.GetUsersByQueryAsync("name", "Enakshi Butt");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var users = JsonConvert.DeserializeObject<List<User>>(response.Content!);
            users.Should().NotBeEmpty();
            users![0].Name.Should().Contain("Enakshi Butt");
        }

        [Fact(DisplayName = "[CT04] Buscar usuário por e-mail")]
        public async Task CT04_GetUserByEmail()
        {
            var response = await _service.GetUsersByQueryAsync("email", "enakshi_butt@hodkiewicz-nicolas.test");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var users = JsonConvert.DeserializeObject<List<User>>(response.Content!);
            users.Should().NotBeEmpty();
            users![0].Email.Should().Be("enakshi_butt@hodkiewicz-nicolas.test");
        }

        [Fact(DisplayName = "[CT05] Buscar usuário por gênero")]
        public async Task CT05_GetUserByGender()
        {
            var response = await _service.GetUsersByQueryAsync("gender", "female");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var users = JsonConvert.DeserializeObject<List<User>>(response.Content!);
            users.Should().NotBeEmpty();
            users![0].Gender.ToLower().Should().Be("female");
        }

        [Fact(DisplayName = "[CT06] Buscar usuário por status")]
        public async Task CT06_GetUserByStatus()
        {
            var response = await _service.GetUsersByQueryAsync("status", "active");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var users = JsonConvert.DeserializeObject<List<User>>(response.Content!);
            users.Should().NotBeEmpty();
            users![0].Status.ToLower().Should().Be("active");
        }

        [Fact(DisplayName = "[CT07] Buscar todos os comentários")]
        public async Task CT07_GetAllComments()
        {
            var response = await _service.GetAllCommentsAsync();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Content.Should().NotBeNullOrEmpty();
        }

        [Fact(DisplayName = "[CT08] Buscar todos os posts")]
        public async Task CT08_GetAllPosts()
        {
            var response = await _service.GetAllPostsAsync();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Content.Should().NotBeNullOrEmpty();
        }

        [Fact(DisplayName = "[CT09] Buscar todos os TO DOs")]
        public async Task CT09_GetAllTodos()
        {
            var response = await _service.GetAllTodosAsync();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Content.Should().NotBeNullOrEmpty();
        }

        [Fact(DisplayName = "[CT10] Criar usuário")]
        public async Task CT10_CreateUser()
        {
            var newUser = new User
            {
                Name = "QA Test User",
                Email = $"qatest{DateTime.Now.Ticks}@mail.com",
                Gender = "male",
                Status = "active"
            };

            var response = await _service.CreateUserAsync(newUser);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            var createdUser = JsonConvert.DeserializeObject<User>(response.Content!);
            createdUser.Should().NotBeNull();
            createdUser!.Email.Should().Be(newUser.Email);
        }

        [Fact(DisplayName = "[CT11] Alterar usuário")]
        public async Task CT11_UpdateUser()
        {
            // Primeiro cria
            var user = new User
            {
                Name = "Usuário para Update",
                Email = $"update{DateTime.Now.Ticks}@mail.com",
                Gender = "female",
                Status = "active"
            };
            var createResp = await _service.CreateUserAsync(user);
            var createdUser = JsonConvert.DeserializeObject<User>(createResp.Content!);

            // Altera
            var updatedUser = new User
            {
                Name = "Usuário Atualizado",
                Email = user.Email,
                Gender = "female",
                Status = "inactive"
            };
            var updateResp = await _service.UpdateUserAsync(createdUser!.Id, updatedUser);

            updateResp.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var updated = JsonConvert.DeserializeObject<User>(updateResp.Content!);
            updated!.Name.Should().Be("Usuário Atualizado");
            updated.Status.Should().Be("inactive");
        }

        [Fact(DisplayName = "[CT12] Excluir usuário")]
        public async Task CT12_DeleteUser()
        {
            var user = new User
            {
                Name = "Usuário para Delete",
                Email = $"delete{DateTime.Now.Ticks}@mail.com",
                Gender = "male",
                Status = "active"
            };

            var createResp = await _service.CreateUserAsync(user);
            var createdUser = JsonConvert.DeserializeObject<User>(createResp.Content!);

            var deleteResp = await _service.DeleteUserAsync(createdUser!.Id);
            deleteResp.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

    }
}
