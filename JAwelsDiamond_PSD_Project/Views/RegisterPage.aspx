<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="JAwelsDiamond_PSD_Project.Views.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Register Page</h1>
                <br />
            <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
                    <br />
            <asp:TextBox ID="EmailTb" runat="server"></asp:TextBox>
                <br />
            <asp:Label ID="Label2" runat="server" Text="Username"></asp:Label>
                    <br />
            <asp:TextBox ID="UsernameTb" runat="server"></asp:TextBox>
                <br />
            <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
                    <br />
            <asp:TextBox ID="PasswordTb" runat="server"></asp:TextBox>
                <br />
            <asp:Label ID="Label4" runat="server" Text="Confirm Password"></asp:Label>
                    <br />
            <asp:TextBox ID="ConfirmPasswordTb" runat="server"></asp:TextBox>
               <br />
            <asp:Label ID="Label5" runat="server" Text="Gender"></asp:Label>
                    <br />
            <asp:TextBox ID="GenderTb" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
