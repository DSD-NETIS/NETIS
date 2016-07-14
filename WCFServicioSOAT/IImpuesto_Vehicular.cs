using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_SAT_Impuesto_Vehicular.Dominio;
using WCF_SAT_Impuesto_Vehicular.Errores;

namespace WCF_SAT_Impuesto_Vehicular
{
    
    [ServiceContract]
    public interface IImpuesto_Vehicular
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        Sat ConsultaImpuesto(string placa);
    }
}
