using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServicioSOAT.Dominio
{
    [DataContract]
    public class Papeletas
    {
        [DataMember]
        public int IdSAT { get; set; }

        [DataMember]
        public string Placa { get; set; }

        [DataMember]
        public string Tipo { get; set; }

        [DataMember]
        public decimal Monto { get; set; }
    }
}