using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServicioSOAT.Dominio
{
    [DataContract]
    public class RecuperarContrasenaDominio
    {

        [DataMember]
        public int IdUsuario { get; set; }

        [DataMember]
        public string Correo { get; set; }

    }
}