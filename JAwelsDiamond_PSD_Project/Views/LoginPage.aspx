<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="JAwelsDiamond_PSD_Project.Views.LoginPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        
        <div style="width:300px; margin:auto; padding-top:50px;">
            <h2>Login</h2>
            
            
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            <div>
                <asp:Label ID="lblEmail" runat="server" Text="Email:" AssociatedControlID="txtEmail" />
                
                <asp:TextBox ID="txtEmail" runat="server" />
                
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Email is required." ForeColor="Red" Display="Dynamic" />
            </div>
            <div style="margin-top:10px;">
                <asp:Label ID="lblPassword" runat="server" Text="Password:" AssociatedControlID="txtPassword" />
                
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
                
                
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="Password is required." ForeColor="Red" Display="Dynamic" />
            </div>


            <div style="margin-top:10px;">
                <asp:CheckBox ID="chkRememberMe" runat="server" Text="Remember Me" />
            </div>


            <div style="margin-top:20px; justify-content:space-between;">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                <asp:LinkButton ID="makeAccountLink" runat="server" OnClick="makeAccountLink_Click">Make new account</asp:LinkButton>
            </div>
        </div>

    </form>
</body>
</html>