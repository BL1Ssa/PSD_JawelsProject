<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="JAwelsDiamond_PSD_Project.Views.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnGoToAddJewel" runat="server" Text="Add Jewel" PostBackUrl="~/Views/AddJewel.aspx" />
        </div>
    </form>
</body>
</html>