using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCF_SAT_Impuesto_Vehicular.Dominio
{
    [DataContract]
    public class Sat
    {
        [DataMember]
        public int idSAT { get; set; }

        [DataMember]
        public string placa { get; set; }

        [DataMember]
        public string tipo { get; set; }

        [DataMember]
        public decimal monto { get; set; }
    }
}