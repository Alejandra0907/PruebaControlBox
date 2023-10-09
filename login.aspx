<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="loginalejandrar.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://www.google.com/recaptcha/api.js" async defer></script>
    <style>
        body {
            background-color: black;
            color: white;
        }

        .container {
            background-color: white;
            border-radius: 10px;
            padding: 20px;
            max-width: 400px;
            margin: 100px auto;
            text-align: center;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .btn-primary {
            width: 100%;
        }
    </style>
    <title>Login</title>
</head>
<body>
    <form id="formulario_login" runat="server">
        <div class="container">
            <asp:Label class="h1" ID="lblBienvenida" runat="server" Text="Bienvenido"></asp:Label>

            <div class="form-group">
                <asp:Label ID="LblUsuario" runat="server" Text="Usuario"></asp:Label>
                <asp:TextBox ID="tbUsuario" CssClass="form-control" runat="server" placeholder="Nombre de Usuario"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="LblPassword" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="tbPassword" CssClass="form-control" TextMode="Password" runat="server" placeholder="Password"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label runat="server" CssClass="alert-danger" ID="lblError"></asp:Label>
            </div>

            <div class="form-group">
                <div class="g-recaptcha" data-sitekey="6LcTC1ghAAAAAGV7rRwIkhsGWxplCAkWhRzaxFSb"></div>
            </div>

            <asp:Button ID="BtnIngresar" CssClass="btn btn-primary btn-dark" runat="server" Text="Ingresar" OnClick="BtnIngresar_Click" />
        </div>
    </form>
</body>
</html>