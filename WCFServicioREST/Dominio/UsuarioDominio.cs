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
        [DataMember]
        public int IdPerfil  {get; set;}

        [DataMember]
        public string Nombre    {get; set;}

        [DataMember]
        public string Apellido  {get; set;}

        [DataMember]
        public string Dni       {get; set;}

        [DataMember]
        public string Correo    {get; set;}

        [DataMember]
        public string Contraseña { get; set; }
        
    }
}