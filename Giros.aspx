<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giros.aspx.cs" Inherits="loginalejandrar.Giros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }

        .container {
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        h1 {
            text-align: center;
        }

        .grid-view {
            margin-bottom: 20px;
        }

        .grid-view table {
            width: 100%;
            border-collapse: collapse;
        }

        .grid-view th, .grid-view td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: center;
        }

        .grid-view th {
            background-color: #f8f9fa;
        }

        .btn {
            display: inline-block;
            padding: 8px 16px;
            font-size: 14px;
            font-weight: bold;
            text-align: center;
            text-decoration: none;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .btn.editar-btn {
            background-color: #28a745;
        }

        .btn.eliminar-btn {
            background-color: #dc3545;
        }

        .txtNuevoGiro {
            display: block;
            width: 100%;
            padding: 8px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .ddlCiudades {
            display: block;
            width: 100%;
            padding: 8px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .btnCrearGiro {
            display: block;
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Button ID="btnHome" runat="server" CssClass="btn" Text="Home" OnClick="btnHome_Click" />

            <h1>Gestión de Giros</h1>

            <div class="grid-view">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="gir_giro_id" OnRowEditing="GridView1_RowEditing"
                    OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                    OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="gir_giro_id" HeaderText="ID" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Recibo">
                            <ItemTemplate>
                                <asp:Label ID="lblRecibo" runat="server" Text='<%# Eval("gir_recibo") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtReciboEdit" runat="server" Text='<%# Bind("gir_recibo") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ciudad">
                            <ItemTemplate>
                                <asp:Label ID="lblCiudad" runat="server" Text='<%# Eval("nombre_ciudad") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlCiudadEdit" runat="server" CssClass="ddlCiudades" 
                                    DataSource='<%# GetCiudades() %>' DataTextField="nombre_ciudad" DataValueField="id_ciudad" 
                                    SelectedValue='<%# Bind("gir_ciudad_id") %>' AppendDataBoundItems="true">
                                    <asp:ListItem Value="" Text="-- Seleccione --"></asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" ButtonType="Button" />
                        <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                    </Columns>
                </asp:GridView>
            </div>

            <asp:TextBox ID="txtNuevoGiro" runat="server" CssClass="txtNuevoGiro" placeholder="Nombre del Nuevo Giro"></asp:TextBox>
            <asp:DropDownList ID="ddlNuevaCiudad" runat="server" CssClass="ddlCiudades" AppendDataBoundItems="true">
                <asp:ListItem Value="" Text="-- Seleccione --"></asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnCrearGiro" runat="server" CssClass="btn btnCrearGiro" Text="Crear Giro" OnClick="btnCrearGiro_Click" />

            <asp:Label ID="lblResultados" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
