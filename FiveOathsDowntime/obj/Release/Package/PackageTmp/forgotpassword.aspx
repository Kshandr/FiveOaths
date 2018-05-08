<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="FiveOathsDowntime.forgotpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="pnlNewForgotPassword" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Enter the email for the account you wish to reset the password for"></asp:Label>
                <br />
                <asp:Label ID="lblErrorMessage" runat="server" Text="THIS IS AN ERROR MESSAGE" Visible="False" ForeColor="Red"></asp:Label>
                <br />
                <asp:TextBox ID="txtInputEmail" runat="server" Width="385px"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="cmdForgotPassword" runat="server" OnClick="cmdForgotPassword_Click" Text="Send Reset Message" />
                <br />
                <asp:LinkButton ID="cmdBack" runat="server" OnClick="cmdBack_Click">Back</asp:LinkButton>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
