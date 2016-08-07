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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "SWSoap" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione SWSoap.svc o SWSoap.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class SWSoap : ISWSoap
    {

        RecuperarContrasenaDAO dao = new RecuperarContrasenaDAO();

        public UsuarioDominio CrearUsuario(UsuarioDominio crearUsuario)
        {
            UsuarioDominio usuarioEncontrado = null;
            usuarioEncontrado = dao.Obtener(crearUsuario.Correo);
            if (usuarioEncontrado != null)
            {
                throw new FaultException<RepetidoException>(new RepetidoException
                {
                    Codigo = "101",
                    Descripcion = "El Usuario ya existe"
                }, new FaultReason("Error al intentar la creación."));
            }

            return dao.CrearUsuario(crearUsuario);
        }
    }
}
