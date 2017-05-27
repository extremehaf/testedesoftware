<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication1.default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/WS/WebService1.asmx">HyperLink</asp:HyperLink>
        <br />
        <asp:Label ID="Label2" runat="server" Text="E-mail:"></asp:Label><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Senha:"></asp:Label> <asp:TextBox ID="txtSenha" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click"/>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
