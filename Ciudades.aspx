<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ciudades.aspx.cs" Inherits="loginalejandrar.Ciudades" %>

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

        .txtNuevaCiudad {
            display: block;
            width: 100%;
            padding: 8px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .ddlPaises {
            display: block;
            width: 100%;
            padding: 8px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .btnCrearCiudad {
            display: block;
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
              <asp:Button ID="btnHome" runat="server" CssClass="btn" Text="Home" OnClick="btnHome_Click" />
            <h1>Gestión de Ciudades</h1>

            <div class="grid-view">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="id_ciudad" OnRowEditing="GridView1_RowEditing"
                    OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                    OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="id_ciudad" HeaderText="ID" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Nombre de la Ciudad">
                            <ItemTemplate>
                                <asp:Label ID="lblNombreCiudad" runat="server" Text='<%# Eval("nombre_ciudad") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNombreCiudadEdit" runat="server" Text='<%# Bind("nombre_ciudad") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="País">
                            <ItemTemplate>
                                <asp:Label ID="lblPais" runat="server" Text='<%# Eval("nombre_pais") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlPaisEdit" runat="server" CssClass="ddlPaises" 
                                    DataSource='<%# GetPaises() %>' DataTextField="nombre_pais" DataValueField="id_pais" 
                                    SelectedValue='<%# Bind("id_pais") %>' AppendDataBoundItems="true">
                                    <asp:ListItem Value="" Text="-- Seleccione --"></asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" ButtonType="Button" />
                        <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                    </Columns>
                </asp:GridView>
            </div>

            <asp:TextBox ID="txtNuevaCiudad" runat="server" CssClass="txtNuevaCiudad" placeholder="Nombre de la Nueva Ciudad"></asp:TextBox>
            <asp:DropDownList ID="ddlNuevoPais" runat="server" CssClass="ddlPaises" AppendDataBoundItems="true">
                <asp:ListItem Value="" Text="-- Seleccione --"></asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnCrearCiudad" runat="server" CssClass="btn btnCrearCiudad" Text="Crear Ciudad" OnClick="btnCrearCiudad_Click" />
          

            <asp:Label ID="lblResultados" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
