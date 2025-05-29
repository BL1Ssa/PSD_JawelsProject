<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="JAwelsDiamond_PSD_Project.Views.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Register</h1>
            <br />

            <asp:Label ID="emaillbl" runat="server" Text="Email"></asp:Label>
            <br />
            <asp:TextBox ID="emailtb" runat="server" OnTextChanged="emailtb_TextChanged"></asp:TextBox>
            <br />

            <asp:Label ID="namelbl" runat="server" Text="Username"></asp:Label>
            <br />
            <asp:TextBox ID="nametb" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="passwordlbl" runat="server" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="passwordtb" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="confpassbl" runat="server" Text="Confirm Password"></asp:Label>
            <br />
            <asp:TextBox ID="confpasstb" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="genderlbl" runat="server" Text="Gender"></asp:Label>
            <br />
            <asp:RadioButtonList ID="genderRadio" runat="server" OnSelectedIndexChanged="genderRadio_SelectedIndexChanged">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:RadioButtonList>
            <br />
            
            <asp:Label ID="calendarlbl" runat="server" Text="Date of Birth"></asp:Label>
            <br />
            <asp:Calendar ID="dateCalendar" runat="server" OnSelectionChanged="dateCalendar_SelectionChanged"></asp:Calendar>
            <br />


            <asp:Label ID="messagelbl" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="registerbtn" runat="server" Text="Register" OnClick="registerbtn_Click" />

        </div>
        
    </form>
</body>
</html>
