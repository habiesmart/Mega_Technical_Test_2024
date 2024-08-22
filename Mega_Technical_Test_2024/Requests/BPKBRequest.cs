using Mega_Technical_Test_2024.Models;
using System.Text.Json;

namespace Mega_Technical_Test_FE_2024.Requests
{
    public class BPKBRequest
    {

        public async Task<BPKBViewModel> Create(BPKBViewModel bpkb)
        {
            BPKBViewModel responseData = new BPKBViewModel();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constant.URL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(JsonSerializer.Serialize(bpkb), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("BPKB/Create", content);

                if (response.IsSuccessStatusCode)
                {
                    string strResponse = await response.Content.ReadAsStringAsync();
                    responseData = JsonSerializer.Deserialize<BPKBViewModel>(strResponse);
                }
            }

            return responseData;
        }

        public async Task<List<BPKBViewModel.StorageLocationViewModel>> GetListStorageLocations()
        {
            List<BPKBViewModel.StorageLocationViewModel> responseData = new List<BPKBViewModel.StorageLocationViewModel>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constant.URL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("BPKB/GetListStorageLocations");

                if (response.IsSuccessStatusCode)
                {
                    string strResponse = await response.Content.ReadAsStringAsync();
                    responseData = JsonSerializer.Deserialize<List<BPKBViewModel.StorageLocationViewModel>>(strResponse);
                }
            }

            return responseData;
        }
    }
}
