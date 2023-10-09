<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Paises.aspx.cs" Inherits="loginalejandrar.Paises" %>

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

        .txtNuevoPais {
            display: block;
            width: 100%;
            padding: 8px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .btnCrearPais {
            display: block;
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Button ID="btnHome" runat="server" CssClass="btn" Text="Home" OnClick="btnHome_Click" />
            <h1>Gestión de Países</h1>

            <div class="grid-view">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="id_pais" OnRowEditing="GridView1_RowEditing"
                    OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                    OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="id_pais" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="nombre_pais" HeaderText="Nombre del País" />
                        <asp:CommandField ShowEditButton="True" ButtonType="Button" />
                        <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                    </Columns>
                </asp:GridView>
            </div>

            <asp:TextBox ID="txtNuevoPais" runat="server" CssClass="txtNuevoPais" placeholder="Nombre del Nuevo Pais"></asp:TextBox>
            <asp:Button ID="btnCrearPais" runat="server" CssClass="btn btnCrearPais" Text="Crear Pais" OnClick="btnCrearPais_Click" />
        </div>
    </form>
</body>
</html>
