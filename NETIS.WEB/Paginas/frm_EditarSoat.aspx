﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_EditarSoat.aspx.cs" Inherits="Paginas_frm_EditarSoat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Detalle SOAT</title>
</head>
<body>
    <form id="form1" runat="server">
    <h3>Editar SOAT</h3>
        <div>
        </div>
        <div style="border:1px solid; width:400px;">
            <table>
                <tbody>
                    <tr>
                        <td>Placa :</td>
                        <td> <input type="text" value="AQZ-123" /></td>
                        <td>Imagen SOAT</td>
                    </tr>
                    <tr>
                        <td>Fecha Registro :</td>
                        <td><input type="text" value="12/06/2016" /></td>
                        <td rowspan="2"> <input type="file" /> </td>
                    </tr>
                    <tr>
                        <td>Estdo :</td>
                        <td>Pendiente</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
