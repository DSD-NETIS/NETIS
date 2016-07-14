using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServicioSOAT.Dominio;
using WCFServicioSOAT.Errores;
using WCFServicioSOAT.Persistencia;

namespace WCFServicioSOAT
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPapeleta" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPapeleta
    {

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        List<Papeletas> ValidarPapeletas(string placa);

        [OperationContract]
        Papeletas Obtener(int id);
    }
}
