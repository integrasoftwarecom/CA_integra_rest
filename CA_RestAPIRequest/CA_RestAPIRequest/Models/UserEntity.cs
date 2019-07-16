using System;
namespace CA_RestAPIRequest
{
    public class UserEntity
    {
        public string Sede { get; set; }
        public string AreaSeccion { get; set; }
        public bool Activo { get; set; }
        public string Cedula { get; set; }
        public string NombresApellidos { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
        public string Eps { get; set; }
        public string Arl { get; set; }
        public string FondoPension { get; set; }
        public string TipoContrato { get; set; }
    }
}
