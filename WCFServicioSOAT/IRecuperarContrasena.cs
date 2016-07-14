using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServicioSOAT.Errores;

namespace WCFServicioSOAT
{
    [ServiceContract]
    public interface IRecuperarContrasena
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        string RecuperarContrasenaUsuario(string stCorreo);
    }
}
