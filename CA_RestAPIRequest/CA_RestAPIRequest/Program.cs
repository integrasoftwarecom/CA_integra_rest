using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Configuration;
using NLog;
using Newtonsoft.Json;

namespace CA_RestAPIRequest
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static LoginRequestResponse loginObject = new LoginRequestResponse();
        static string apiBaseUrl = ConfigurationManager.AppSettings["WebApiBaseUri"];
        static string apiUserName = ConfigurationManager.AppSettings["WebApiConnUserName"];
        static string apiPassword = ConfigurationManager.AppSettings["WebApiConnPassword"];
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            // Se configura el cliente http para realizar peticiones web
            client.BaseAddress = new Uri(apiBaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Se hace el login de la aplicación
            // Se pueden leer el usuario y contraseña de un archivo para que sea más configurable
            loginObject = await LoginController.LoginAsync(apiUserName, apiPassword, client);

            if (loginObject.HasError)
            {
                // Se puede imprimir en un log txt
                Console.WriteLine($"Error de login: {loginObject.Error}");
                return;
            }

            // Si el login se realizó correctamente se procede a realizar la actualización de los datos

            // Se le agrega a la petición el token de autorización
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginObject.Token);
            
            
            UsersController userCrtl = new UsersController(client);

            CreateUpdateUserResponse requestResponse = await userCrtl.CreateUpdateUsersAsync();

            //Guardamos el log
            logger.Info(JsonConvert.SerializeObject(requestResponse));

            if (!requestResponse.HasErrors)
            {
                // Se puede imprimir en un log txt
                Console.WriteLine($"Se finalizó correctamente la creación / actualización de {requestResponse.ProcessedItems} items de un total de {requestResponse.LoadedItems} items");
            }else
            {
                foreach (var item in requestResponse.ErrorsDescription)
                {
                    // Se puede imprimir en un log txt
                    Console.WriteLine($" Línea {item.Line} - {item.ErrorDescription}");
                }
            }
        }

        

    }
}