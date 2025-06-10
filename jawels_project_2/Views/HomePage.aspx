<%@ Page Title="Home" Language="C#" MasterPageFile="~/Views/Master Page/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="jawels_project_2.Views.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Welcome To Jawels & Diamonds</h1>

    <asp:Repeater ID="rptJewels" runat="server">
        <ItemTemplate>
            <div>
                <h3><%# Eval("JewelName") %></h3>
                <p>Price: $<%# Eval("JewelPrice") %></p>
                <p>Release Year: <%# Eval("JewelReleaseYear") %></p>
                    <asp:Button 
                            ID="btnDetail" 
                            runat="server" 
                            Text="View Details" 
                            PostBackUrl='<%# "ShowDetails.aspx?JewelID=" + Eval("JewelID") %>' />
                    </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>