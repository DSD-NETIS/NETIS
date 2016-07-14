using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_SAT_Impuesto_Vehicular.Persistencia;
using WCF_SAT_Impuesto_Vehicular.Dominio;
using WCF_SAT_Impuesto_Vehicular.Errores;

namespace WCF_SAT_Impuesto_Vehicular
{
    
    public class Impuesto_Vehicular : IImpuesto_Vehicular
    {
        private SatDAO satDAO = new SatDAO();

        public Sat ConsultaImpuesto(string placa)
        {

            if (satDAO.ConsultaImpuesto(placa) == null)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "101",
                        Descripcion = "No existe impuesto Vehicular para la placa ingresada"
                    },
                    new FaultReason("No existe impuesto Vehicular para la placa ingresada"));
            }
                return satDAO.ConsultaImpuesto(placa);   

        }
    }
}
