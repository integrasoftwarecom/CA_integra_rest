using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CA_RestAPIRequest
{
    public class UsersController
    {
        private HttpClient httpClient { get; set; }


        public UsersController(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<CreateUpdateUserResponse> CreateUpdateUsersAsync()
        {
            CreateUpdateUserResponse requestResponse = new CreateUpdateUserResponse();
            IEnumerable<UserEntity> usersToUpdateCreate = new List<UserEntity>();
            UsersDA usersDA = new UsersDA();

            //Se consultan los datos de los usuarios a crear y/o actualizar
            usersToUpdateCreate = await usersDA.GetUsersToUpdate();

            if (usersToUpdateCreate !=null)
            {
                //Se hace el consumo del servicio para actualizar/crear usuarios
                var response = await httpClient.PostAsJsonAsync("ExternalServicesAccount/EmployeeExternalUpdate", usersToUpdateCreate);

                requestResponse = await response.Content.ReadAsAsync<CreateUpdateUserResponse>();
            }
            
            return requestResponse;
        }
    }
}
