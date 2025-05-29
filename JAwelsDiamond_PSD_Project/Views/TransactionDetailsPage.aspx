<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionDetailsPage.aspx.cs" Inherits="JAwelsDiamond_PSD_Project.Views.TransactionDetailsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Transaction Details</h1>
            <br />

            <h3>Transaction ID</h3>
            <asp:Label ID="idlbl" runat="server" Text=""></asp:Label>
            
            <h3>Jewel Name</h3>
            <asp:Label ID="namelbl" runat="server" Text=""></asp:Label>
            
            <h3>Quantity</h3>
            <asp:Label ID="quantitylbl" runat="server" Text=""></asp:Label>

            <br />
            <br />
            <asp:Button ID="backbtn" runat="server" Text="back" OnClick="backbtn_Click" />
        </div>
    </form>
</body>
</html>
