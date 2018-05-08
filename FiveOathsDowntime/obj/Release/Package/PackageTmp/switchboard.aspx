<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="switchboard.aspx.cs" Inherits="FiveOathsDowntime.switchboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            Welcome
            <asp:Label ID="lblRealname" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <strong>FUNCTIONS</strong><br />
            <br />
            <a href="personaldetail.aspx">Change Personal Details</a><br />
            <asp:LinkButton ID="cmdViewCharacter" runat="server" OnClick="cmdViewCharacter_Click">View Character</asp:LinkButton>
            <br />
            <asp:LinkButton ID="cmdLogout" runat="server" OnClick="cmdLogout_Click">Logout</asp:LinkButton>
            <br />
            <br />
            <asp:Panel ID="pnlAdminPanel" runat="server" Visible="False">
                <strong>ADMIN FUNCTIONS</strong><br />
                <br />
                Manage Administrative Users<br /> 
                <a href="reports/allplayersreport.aspx">Download Player Database Report</a><br />
                <a href="reports/fulllogreport.aspx">Download Log Report</a></asp:Panel>
            <br />
        </div>
    </form>
</body>
</html>
