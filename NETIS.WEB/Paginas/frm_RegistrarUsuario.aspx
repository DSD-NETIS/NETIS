<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_RegistrarUsuario.aspx.cs" Inherits="Paginas_frm_RegistrarUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <h1>Mi SOAT</h1>
    <div>
        <div>
            <div>Nombre :</div>
            <div><input type="text" placeholder="Ingrese su Nombre" id="txtNombre" runat="server" /></div>
        </div>
        <div>
            <div>Apellido :</div>
            <div><input type="text" placeholder="Ingrese su Apellido" id="txtApellido" runat="server" /></div>
        </div>
        <div>
            <div>Correo :</div>
            <div><input type="email" placeholder="Ingrese su Correo" id="txtEmail" runat="server" /></div>
        </div>
        <div>
            <div>Contraseña :</div>
            <div><input type="password" placeholder="Ingrese su Contraseña" id="txtContrasea" runat="server" /></div>
        </div>
        <div>
            <div>Repetir Contraseña :</div>
            <div><input type="password" placeholder="Vuelva a ingresar su contraseña" id="txtConfirmaContrasea" runat="server" /></div>
        </div>
        <div>
            <div>
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClientClick="if(txtEmail.value == 'admin@netis.com'){ alert('El Correo ya fue registrado'); return false; } alert('Se registraron los datos con éxito'); window.close();" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClientClick="window.close();" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
