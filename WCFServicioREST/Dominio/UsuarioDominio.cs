using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServicioREST.Dominio
{
    [DataContract]
    public class UsuarioDominio
    {
        public int IdPerfil  {get; set;}

        public string Nombre    {get; set;}

        public string Apellido  {get; set;}

        public string Dni       {get; set;}

        public string Correo    {get; set;}

        public string Contraseña { get; set; }
        
    }
}