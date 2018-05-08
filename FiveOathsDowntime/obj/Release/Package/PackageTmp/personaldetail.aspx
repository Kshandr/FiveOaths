<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="personaldetail.aspx.cs" Inherits="FiveOathsDowntime.personaldetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 222px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblModeMessage" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="True" ForeColor="Red" Text="I am an error message" Visible="False"></asp:Label>
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server" Columns="60"></asp:TextBox>
                        <asp:Label ID="lblUsername" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" Columns="60" TextMode="Password"></asp:TextBox>
                        *</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Text="Re-type Password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRetypePassword" runat="server" Columns="60" TextMode="Password"></asp:TextBox>
                        *</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label4" runat="server" Text="Real Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRealname" runat="server" Columns="60"></asp:TextBox>
                        *</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label7" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Columns="60"></asp:TextBox>
                        *</td>
                </tr>
                <tr>
                    <td class="auto-style2">Car Registration</td>
                    <td>
                        <asp:TextBox ID="txtCarRegistration" runat="server" Columns="60"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Emergency Contact Name</td>
                    <td>
                        <asp:TextBox ID="txtEmergencyContactName" runat="server" Columns="60"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label6" runat="server" Text="Emergency Contact Number"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmergencyContactNumber" runat="server" Columns="60"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="vertical-align:top;">Medical Details</td>
                    <td>
                        <asp:TextBox ID="txtMedicalDetails" runat="server" Columns="60" Rows="5" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Button ID="cmdSubmitChanges" runat="server" OnClick="cmdSubmitChanges_Click" Text="Submit Changes" />
            <br />
            <asp:LinkButton ID="cmdBack" runat="server" OnClick="cmdBack_Click">Back</asp:LinkButton>
        </div>
    </form>
</body>
</html>
