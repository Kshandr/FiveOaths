<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewcharacter.aspx.cs" Inherits="FiveOathsDowntime.viewcharacter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 159px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <strong>Character Details</strong><br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2"><strong>Name</strong></td>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><strong>Race</strong></td>
                    <td>
                        <asp:Label ID="lblRace" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><strong>Native Realm</strong></td>
                    <td>
                        <asp:Label ID="lblNativeRealm" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2"><hr /></td>
                </tr>
                <tr>
                    <td class="auto-style2"><strong>Body</strong></td>
                    <td>
                        <asp:Label ID="lblBody" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><strong>Armour</strong></td>
                    <td>
                        <asp:Label ID="lblArmour" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><strong>Mana</strong></td>
                    <td>
                        <asp:Label ID="lblMana" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
            <hr />
            <table style="width:50%">
                <tr>
                    <td>
                        <strong>Feats</strong><br />
                        <asp:Label ID="lblFeatTable" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <strong>Lammied Possessions</strong><br />
                        <asp:Label ID="lblLammyTable" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>

            <hr />

            <table>
                <tr>
                    <td colspan="2"><strong>Coins</strong></td>
                    <td>
                        <asp:Label ID="lblCoins" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><strong>Crystals</strong></td>
                    <td><strong>Fire</strong></td>
                    <td>
                        <asp:Label ID="lblFire" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><strong>Earth</strong></td>
                    <td>
                        <asp:Label ID="lblEarth" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><strong>Water</strong></td>
                    <td>
                        <asp:Label ID="lblWater" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><strong>Air</strong></td>
                    <td>
                        <asp:Label ID="lblAir" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><strong>Blended</strong></td>
                    <td>
                        <asp:Label ID="lblBlended" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><strong>Void</strong></td>
                    <td>
                        <asp:Label ID="lblVoid" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <asp:LinkButton ID="cmdBack" runat="server" OnClick="cmdBack_Click">Back</asp:LinkButton>
    </form>
</body>
</html>
