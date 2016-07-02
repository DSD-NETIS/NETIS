<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_SolicitarSoat.aspx.cs" Inherits="Paginas_frm_SolicitarSoat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <h1>Solicitar Mi SOAT</h1>
     Ingresar los datos segun la tarjeta de propiedad
     <br />
     <br />
    <div>
         <div>
            <div>Marca: </div>
            <div>
                <asp:DropDownList runat="server" ID="ddlMarca">
                    <asp:ListItem Text="Toyota"></asp:ListItem>
                    <asp:ListItem Text="Nissan"></asp:ListItem>
                    <asp:ListItem Text="Mitsubishi"></asp:ListItem>
                    <asp:ListItem Text="Honda"></asp:ListItem>
                    <asp:ListItem Text="Chevrolet"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div>
            <div>Placa: </div>
            <div><input type="text" placeholder="Ingrese su Placa" id="txtPlaca" maxlength="6" runat="server"/></div>
        </div>
        <div>
            <div>Fecha Inicio: </div>
            <div><input type="date" placeholder="Ingrese la Fecha de Inicio" id="dtFechaInicio" runat="server" /></div>
        </div>
        <div>
            <div>Categoria/Clase: </div>
            <div><input type="text" placeholder="Ingrese su Contraseña" id="txtCategoria" runat="server" /></div>
        </div>
        <div>
            <div>Contratante: </div>
            <div><input type="text" placeholder="Ingrese el contratante" id="txtContratante" runat="server" /></div>
        </div>
        <div>
            <div>Año Vehiculo: </div>
            <div><asp:DropDownList runat="server" ID="ddlAño">
                    <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                    <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                    <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                    <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                    <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                </asp:DropDownList></div>
        </div>
        <div>
            <div>Doc. Identidad: </div>
            <div><input type="text" placeholder="DNI/RUC" id="txtDocumento" maxlength="11" runat="server" /></div>
        </div>
        <div>
            <div>Modelo: </div>
            <div>
                <asp:DropDownList runat="server" ID="ddlModelo">
                    <asp:ListItem Text="XL356"></asp:ListItem>
                    <asp:ListItem Text="NW SUMO"></asp:ListItem>
                    <asp:ListItem Text="RT 987"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        
        <div>
            <div>Número de Asientos: </div>
            <div><input type="text" placeholder="Ingrese el número de asientos" id="txtNroAsientos" runat="server" /></div>
        </div>
        <div>
            <div>Dirección: </div>
            <div><input type="number" placeholder="Ingrese la dirección" id="txtDireccion" runat="server" /></div>
        </div>
        <div>
            <div>Uso del Vehículo: </div>
            <div>
                <asp:DropDownList runat="server" ID="ddlUso">
                    <asp:ListItem Text="Diario"></asp:ListItem>
                    <asp:ListItem Text="Semanal"></asp:ListItem>
                    <asp:ListItem Text="Mensual"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div>
            <div>Número de Serie: </div>
            <div><input type="text" placeholder="Ingrese el numero de serie" id="txtNroSerie" runat="server" /></div>
        </div>
        <div>
            <div>
                <asp:Button ID="btnGuardar" runat="server" Text="Submit" OnClientClick="if(txtPlaca.value == ''){ alert('Por favor ingrese la placa'); return false; } 
                    if(txtContratante.value == ''){ alert('Por favor ingrese el contratante'); return false; } if(txtDocumento.value == ''){ alert('Por favor ingrese el DNI/RUC'); return false; }
                    if(txtCategoria.value == ''){ alert('Por favor ingrese la categoría/clase'); return false; } if(txtNroAsientos.value == ''){ alert('Por favor ingrese el numero de asientos'); return false; }
                    if(txtNroSerie.value == ''){ alert('Por favor ingrese el numero de serie'); return false; } if(txtDireccion.value == ''){ alert('Por favor ingrese la direccion'); return false; } alert('Se registraron los datos con éxito'); window.close();" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClientClick="window.close();" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
