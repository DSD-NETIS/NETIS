<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_RecuperarContrasena.aspx.cs" Inherits="Paginas_frm_RecuperarContrasena" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Mi SOAT</h1>
     <p>Debe ingresar el correo asociado a su cuenta. Se le enviará un correo con los pasos para restablecer su contraseña.</p>
    <div style="text-align:center">
        <table style="border:1px solid;text-align:center;margin:0px auto">
        <tbody>
            <tr>
                <td>Correo</td>
                <td><input type="email" id="txtEmail" runat="server" style="width:200px;" /></td>
            </tr>
            
            <tr>
                <td style="text-align:center"><asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClientClick="if(txtEmail.value == ''){ alert('Ingrese un correo valido'); return false; }  alert('Se envió los pasos a su correo.'); window.close();" /></td>
                <td style="text-align:center"><asp:Button ID="btnIngresar" runat="server" Text="Cancelar" OnClientClick="window.close();" /></td>
            </tr>
            
        </tbody>
        </table>
    </div>
    </form>
</body>
</html>
