<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="loginalejandrar.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <title>Inicio</title>
    <style>
        body, html {
            height: 100%;
            margin: 0;
        }

        .main-container {
            background-color: #f5f5f5;
            padding: 30px;
            border-radius: 10px;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            height: 100%;
        }

        .botones-container {
            text-align: center;
            margin-bottom: 20px;
        }

        .consulta-container {
            background-color: #ffffff;
            border: 1px solid #ccc;
            border-radius: 10px;
            padding: 20px;
            width: 100%;
            max-width: 400px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main-container">
            <h1>Menú Principal</h1>
            <div class="botones-container">
                <asp:Button ID="BtnAgregar" CssClass="btn btn-primary btn-lg m-2" runat="server" Text="Paises" OnClick="BtnPaises_Click" />
                <asp:Button ID="Button1" CssClass="btn btn-primary btn-lg m-2" runat="server" Text="Ciudades" OnClick="BtnCiudades_Click" />
                <asp:Button ID="Button2" CssClass="btn btn-primary btn-lg m-2" runat="server" Text="Giros" OnClick="BtnGiros_Click" />
            </div>

            <div class="consulta-container">
                <h2>Consulta Principal</h2>
                <asp:Button ID="Button4" CssClass="btn btn-primary btn-lg m-2" runat="server" Text="Consulta" OnClick="BtnConsulta_Click" />
            </div>
        </div>
    </form>
</body>
</html>
