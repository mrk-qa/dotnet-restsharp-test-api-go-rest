using RestSharp;
using System.Threading.Tasks;
using ApiTestsPOC.Models;

namespace ApiTestsPOC.Services
{
    public class GoRestService
    {
        private readonly RestClient _client;
        private readonly string _token = "Bearer 3b92fccbccfd8a823022eb7104f32c70fadc514cb008f25f9af45edb5a486302";

        public GoRestService()
        {
            _client = new RestClient("https://gorest.co.in/public/v2");
        }

        public async Task<RestResponse> GetAllUsersAsync() =>
            await _client.ExecuteAsync(new RestRequest("/users", Method.Get));

        public async Task<RestResponse> GetUserByIdAsync(int id) =>
            await _client.ExecuteAsync(new RestRequest($"/users/{id}", Method.Get));

        public async Task<RestResponse> GetUsersByQueryAsync(string key, string value)
        {
            var request = new RestRequest("/users", Method.Get);
            request.AddQueryParameter(key, value);
            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> GetAllCommentsAsync() =>
            await _client.ExecuteAsync(new RestRequest("/comments", Method.Get));

        public async Task<RestResponse> GetAllPostsAsync() =>
            await _client.ExecuteAsync(new RestRequest("/posts", Method.Get));

        public async Task<RestResponse> GetAllTodosAsync() =>
            await _client.ExecuteAsync(new RestRequest("/todos", Method.Get));

        private RestRequest CreateRequest(string resource, Method method)
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("Authorization", _token);
            request.AddHeader("Content-Type", "application/json");
            return request;
        }

        // POST
        public async Task<RestResponse> CreateUserAsync(User user)
        {
            var request = CreateRequest("/users", Method.Post);
            request.AddJsonBody(user);
            return await _client.ExecuteAsync(request);
        }

        // PUT
        public async Task<RestResponse> UpdateUserAsync(int userId, User user)
        {
            var request = CreateRequest($"/users/{userId}", Method.Put);
            request.AddJsonBody(user);
            return await _client.ExecuteAsync(request);
        }

        // DELETE
        public async Task<RestResponse> DeleteUserAsync(int userId)
        {
            var request = CreateRequest($"/users/{userId}", Method.Delete);
            return await _client.ExecuteAsync(request);
        }

    }
}
