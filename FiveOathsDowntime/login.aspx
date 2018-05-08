<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="FiveOathsDowntime.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Text="I AM AN ERROR MESSAGE" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Username  "></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Password  "></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="cmdLogin" runat="server" OnClick="cmdLogin_Click" Text="Login" />
            <br />
            <a href="personaldetail.aspx">Register</a>
            <br />
            <asp:LinkButton ID="cmdForgotPassword" runat="server" OnClick="cmdForgotPassword_Click">Forgot Password</asp:LinkButton>
        </div>
    </form>
</body>
</html>
