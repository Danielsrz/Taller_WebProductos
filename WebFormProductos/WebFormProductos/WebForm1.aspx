<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebFormProductos.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/Estilos.css" rel="stylesheet" />
    <title></title>
</head>

<body>
    <h3>Detalles de Productos</h3>
    <div class="formulario">
        <form id="form1" runat="server" method="post">
            <ul>
                <li>
                    <label for="name">Nombre:</label>
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </li>
                <li>
                    <label for="desc">Descripción:</label>
                    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                </li>
                <li>
                    <label for="price">Precio:</label>
                    <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                </li>
                <li>
                    <label for="stock">Stock:</label>
                    <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
                </li>
            </ul>

            <br />
                <asp:Button class="button" type="submit" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button class="button" type="submit" ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                <asp:Button class="button" type="submit" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />

            <br />
            <br />
            <asp:GridView ID="dgvProductos" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="315px">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
                
            

        </form>

        
                
    </div>
</body>
</html>
