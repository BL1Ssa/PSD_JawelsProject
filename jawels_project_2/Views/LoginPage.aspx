<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Views/Master Page/Site.Master" CodeBehind="LoginPage.aspx.cs" Inherits="jawels_project_2.Views.LoginPage" %>

<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
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
</asp:Content>