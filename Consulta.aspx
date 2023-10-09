<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="loginalejandrar.Consulta" %>

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

        .ddlPaises, .ddlCiudades {
            display: block;
            width: 100%;
            padding: 8px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
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
        .grid-view table {
        width: 100%;
        border: 1px solid #ccc;
        border-collapse: collapse;
        margin-bottom: 20px;
        }

        .grid-view th, .grid-view td {
            border: 1px solid #ccc;
            padding: 8px;
            text-align: center;
        }

        .grid-view th {
            background-color: #f8f9fa;
            font-weight: bold;
        }

        .grid-view tr:nth-child(even) {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Button ID="btnHome" runat="server" CssClass="btn" Text="Home" OnClick="btnHome_Click" />
            <h1>Consulta de Giros</h1>

            <asp:DropDownList ID="ddlPaises" runat="server" CssClass="ddlPaises" AutoPostBack="true" OnSelectedIndexChanged="ddlPaises_SelectedIndexChanged">
            </asp:DropDownList>

            <asp:DropDownList ID="ddlCiudades" runat="server" CssClass="ddlCiudades">
            </asp:DropDownList>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="gir_giro_id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="gir_giro_id" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="gir_recibo" HeaderText="Recibo" />
                    <asp:BoundField DataField="nombre_ciudad" HeaderText="Ciudad" />
                </Columns>
            </asp:GridView>

            <asp:Label ID="lblResultados" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>