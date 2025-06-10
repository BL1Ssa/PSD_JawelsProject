<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Master Page/Site.Master" CodeBehind="RegisterPage.aspx.cs" Inherits="jawels_project_2.Views.Register" %>

<asp:Content ID="Content7" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <h1>Register</h1>
            <br />

            <asp:Label ID="emaillbl" runat="server" Text="Email"></asp:Label>
            <br />
            <asp:TextBox ID="emailtb" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="namelbl" runat="server" Text="Username"></asp:Label>
            <br />
            <asp:TextBox ID="nametb" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="passwordlbl" runat="server" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="passwordtb" runat="server" TextMode="Password"></asp:TextBox>
            <br />

            <asp:Label ID="confpassbl" runat="server" Text="Confirm Password"></asp:Label>
            <br />
            <asp:TextBox ID="confpasstb" runat="server" TextMode="Password"></asp:TextBox>
            <br />

            <asp:Label ID="genderlbl" runat="server" Text="Gender"></asp:Label>
            <br />
            <asp:RadioButtonList ID="genderRadio" runat="server">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:RadioButtonList>
            <br />
            
            <asp:Label ID="calendarlbl" runat="server" Text="Date of Birth"></asp:Label>
            <br />
            <asp:Calendar ID="dateCalendar" runat="server"></asp:Calendar>
            <br />


            <asp:Label ID="messagelbl" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />
            <asp:Button ID="registerbtn" runat="server" Text="Register" OnClick="registerbtn_Click" />

        </div>
</asp:Content>