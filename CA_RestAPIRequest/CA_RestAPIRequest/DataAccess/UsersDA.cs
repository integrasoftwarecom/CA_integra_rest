using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CA_RestAPIRequest
{


    public class UsersDA
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
            }

        }

        public async Task<IEnumerable<UserEntity>> GetUsersToUpdate()
        {

            /*
             Las siguietnes líneas comentadas muestran un ejemplo de acceso a una base de datos SQL
             para traer unos posibles usuarios a crear o actualizar
             */

            /*
            string selectSQL = "<<SQL O Procedimiento almacenado a ejecutar>>";

            using (IDbConnection connection = Connection)
            {
                try
                {
                    connection.Open();
                    //Con la librería Dapper se puede hacer un mapeo directo al objeto
                    var results = await connection.QueryAsync<UserEntity>(selectSQL);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            */

            // Ejemplo de lista de usuarios a retornar
            List<UserEntity> usersToUpdateCreate = new List<UserEntity>()
            {
                new UserEntity
                {
                    Sede = "ADMON MEDELLIN",
                    AreaSeccion ="ADMINISTRATIVO",
                    Activo = true,
                    Cedula= "98588934",
                    NombresApellidos = "ALEXANDER ACEVEDO LOPERA",
                    Genero = "M",
                    FechaNacimiento = new DateTime(1980,05,12),
                    FechaIngreso=new DateTime(2015,01,20),
                    Cargo="Coordinador De Sst",
                    Salario= 5000000,
                    Eps="SURA EPS",
                    Arl="SEGUROS BOLÍVAR",
                    FondoPension="COLPENSIONES",
                    TipoContrato="Término indefinido"
                }
            };

            return usersToUpdateCreate;
        }
    }
}
