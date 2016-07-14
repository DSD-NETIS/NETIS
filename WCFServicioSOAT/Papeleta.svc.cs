using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServicioSOAT.Dominio;
using WCFServicioSOAT.Persistencia;
using WCFServicioSOAT.Errores;

namespace WCFServicioSOAT
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Papeleta" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Papeleta.svc o Papeleta.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Papeleta : IPapeleta
    {
        private PapeletasDAO papeletasDAO = new PapeletasDAO();

        public List<Papeletas> ValidarPapeletas(string placa)
        {
            if (papeletasDAO.ValidarPapeleta(placa) != null)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "301",
                        Descripcion = "La placa ingresada presenta papeletas vigentes."
                    }, new FaultReason("Error al intentar crear un SOAT"));
            }
            return papeletasDAO.ValidarPapeleta(placa);
        }

        public Papeletas Obtener(int id)
        {
            return papeletasDAO.Obtener(id);
        }

    }
}
