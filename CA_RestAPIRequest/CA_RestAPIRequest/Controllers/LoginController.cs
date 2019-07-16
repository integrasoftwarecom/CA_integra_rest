using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CA_RestAPIRequest
{
    public static class LoginController
    {
        public static async Task<LoginRequestResponse> LoginAsync(string userName, string password, HttpClient httpClient)
        {
            LoginRequestResponse loginResponse = new LoginRequestResponse();
            var response = await httpClient.PostAsJsonAsync("ExternalServicesAccount/Login", new
            {
                AccountName = userName,
                AccountPassword = password
            });


            if (response.IsSuccessStatusCode)
            {
                loginResponse = await response.Content.ReadAsAsync<LoginRequestResponse>();
            }
            else
            {
                var responseErrorData = await response.Content.ReadAsStreamAsync();
                var readStream = new StreamReader(responseErrorData, Encoding.UTF8);
                string dataString = await readStream.ReadToEndAsync();

                var errorResponse = JsonConvert.DeserializeObject<LoginErrorResponse>(dataString);
                loginResponse.HasError = true;
                loginResponse.Error = errorResponse.Error;
            }
            return loginResponse;
        }
    }
}
