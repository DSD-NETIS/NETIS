using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServicioREST.Dominio
{
    [DataContract]
    public class AccesoPerfilDominio
    {
        [DataMember]
        public int IdPerfil { get; set; }

        [DataMember]
        public string HoraInicio {get; set;}

        [DataMember]
        public string HoraFin { get; set; }
    }
}