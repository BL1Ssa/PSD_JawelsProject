<%@ Page Title="Home" Language="C#" MasterPageFile="~/Views/Master Page/Site.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="JAwelsDiamond_PSD_Project.Views.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Welcome To Jawels & Diamonds</h1>

    <asp:Repeater ID="rptJewels" runat="server">
        <ItemTemplate>
            <div>
                <h3><%# Eval("JewelName") %></h3>
                <p>Price: <%# Eval("JewelPrice") %></p>
                <p>Release Year: <%# Eval("JewelReleaseYear") %></p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>