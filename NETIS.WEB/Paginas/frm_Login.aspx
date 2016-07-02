<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_Login.aspx.cs" Inherits="Paginas_frm_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sistema SOAT</title>
</head>
<body>
    <form id="form1" runat="server">
    <h1 style="text-align:center">NETIS - SOAT</h1>
    <div>
    </div>
    <div style="text-align:center"><span >Mi SOAT</span></div>
    <div style="text-align:center">
        <table style="border:1px solid;text-align:center;margin:0px auto">
        <tbody>
            <tr>
                <td>Correo</td>
                <td><input type="email" id="txtLogin" runat="server" style="width:200px;" /></td>
            </tr>
            <tr>
                <td>Password</td>
                <td><input type="password" id="txtPassword" runat="server" style="width:200px;" /></td>
            </tr>
            <tr>
                <td style="text-align:center"><asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClientClick="window.open('frm_RegistrarUsuario.aspx', 'newwindow', 'width=500, height=450'); return false;" /></td>
                <td style="text-align:center"><asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" /></td>
            </tr>
            <tr>
                <td style="text-align:center"> <a href="#" onclick="window.open('frm_RecuperarContrasena.aspx', 'newwindow', 'width=500, height=450'); return false;" >Rescuperar Contraseña</a> </td>
            </tr>
        </tbody>
    </table>
    </div>
    </form>
</body>
</html>
