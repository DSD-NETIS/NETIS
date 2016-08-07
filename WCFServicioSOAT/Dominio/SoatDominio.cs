using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServicioSOAT.Dominio
{
    [DataContract]
    public class SoatDominio
    {
        [DataMember]
        public string Placa {get; set;}

        [DataMember]
        public string Marca {get; set;}

        [DataMember]
        public string Categoria {get; set;}

        [DataMember]
        public string FechaInicio {get; set;}

        [DataMember]
        public string Contratante {get; set;}

        [DataMember]
        public int Año {get; set;}

        [DataMember]
        public string Documento {get; set;}

        [DataMember]
        public string Modelo {get; set;}

        [DataMember]
        public int NroAsientos {get; set;}

        [DataMember]
        public string Direccion {get; set;}

        [DataMember]
        public string UsoDiario {get; set;}

        [DataMember]
        public string NroSerie {get; set;}

    }
}