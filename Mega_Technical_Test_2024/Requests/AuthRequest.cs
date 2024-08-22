using Mega_Technical_Test_2024.Models;
using System.Text.Json;

namespace Mega_Technical_Test_FE_2024.Requests
{
    public class AuthRequest
    {

        public async Task<LoginViewModel> Login(LoginViewModel login)
        {
            LoginViewModel responseData = new LoginViewModel();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constant.URL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(JsonSerializer.Serialize(login), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("Login", content);

                if (response.IsSuccessStatusCode)
                {
                    string strResponse = await response.Content.ReadAsStringAsync();
                    responseData = JsonSerializer.Deserialize<LoginViewModel>(strResponse);
                }
            }

            return responseData;
        }

        public async Task<bool> Logout()
        {
            bool responseData = new bool();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constant.URL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("Logout", content);

                if (response.IsSuccessStatusCode)
                {
                    string strResponse = await response.Content.ReadAsStringAsync();
                    responseData = JsonSerializer.Deserialize<bool>(strResponse);
                }
            }

            return responseData;
        }
    }
}
