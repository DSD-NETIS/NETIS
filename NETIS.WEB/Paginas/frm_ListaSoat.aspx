<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_ListaSoat.aspx.cs" Inherits="Paginas_frm_ListaSoat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h3>Lista SOAT</h3>
    <div>
        <table>
            <thead >
                <tr>
                    <th style="border:1px solid">Placa</th>
                    <th style="border:1px solid">Fecha Registro</th>
                    <th style="border:1px solid">Estado</th>
                    <th style="border:1px solid"> Acciones </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td style="border:1px solid" >AQZ-123</td>
                    <td style="border:1px solid">12/06/2016</td>
                    <td style="border:1px solid">Pendiente</td>
                    <td style="border:1px solid"> <a href="#" onclick="window.open('frm_DetalleSoat.aspx', 'newwindow', 'width=500, height=450'); return false;"  >Detalle</a> 
                        <a href="#" onclick="window.open('frm_EditarSoat.aspx', 'newwindow', 'width=500, height=450'); return false;" >Editar</a></td>
                </tr>
                <tr>
                    <td style="border:1px solid">WXS-346</td>
                    <td style="border:1px solid">23/05/2016</td>
                    <td style="border:1px solid">Aprobado</td>
                    <td style="border:1px solid"> <a href="#" onclick="window.open('frm_DetalleSoat.aspx', 'newwindow', 'width=500, height=450'); return false;"  >Detalle</a> 
                        <a href="#" onclick="window.open('frm_EditarSoat.aspx', 'newwindow', 'width=500, height=450'); return false;" >Editar</a></td>
                </tr>
                <tr>
                    <td style="border:1px solid">TGE-651</td>
                    <td style="border:1px solid">09/02/2016</td>
                    <td style="border:1px solid">Aprobado</td>
                    <td style="border:1px solid"> <a href="#" onclick="window.open('frm_DetalleSoat.aspx', 'newwindow', 'width=500, height=450'); return false;"  >Detalle</a> 
                        <a href="#" onclick="window.open('frm_EditarSoat.aspx', 'newwindow', 'width=500, height=450'); return false;" >Editar</a></td>
                </tr>
                <tr>
                    <td style="border:1px solid">BRT-986</td>
                    <td style="border:1px solid">12/01/2016</td>
                    <td style="border:1px solid">Aprobado</td>
                    <td style="border:1px solid"> <a href="#" onclick="window.open('frm_DetalleSoat.aspx', 'newwindow', 'width=500, height=450'); return false;"  >Detalle</a> 
                        <a href="#" onclick="window.open('frm_EditarSoat.aspx', 'newwindow', 'width=500, height=450'); return false;" >Editar</a></td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
