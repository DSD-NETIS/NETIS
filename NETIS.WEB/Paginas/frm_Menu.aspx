<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_Menu.aspx.cs" Inherits="Paginas_frm_Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MENU - SYS SOAT</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ul>
            <li><a href="#" runat="server" >INICIO</a></li>
            <li><asp:LinkButton ID="lbSolicitar" runat="server" OnClick="lbSolicitar_Click" >SOLICITAR SOAT</asp:LinkButton></li>
            <li><asp:LinkButton ID="lbListado" runat="server" OnClick="lbListado_Click" >LISTADO SOAT</asp:LinkButton></li>
            <li><a href="#">CERRAR SESIÓN</a></li>
        </ul>
    </div>
    </form>
</body>
</html>
