<%@ Page Title="Home" Language="C#" MasterPageFile="~/Views/Master Page/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="JAwelsDiamond_PSD_Project.Views.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Welcome To Jawels & Diamonds</h1>

    <asp:Repeater ID="rptJewel" runat="server">
        <ItemTemplate>
            <div style="border: 1px solid #ccc; padding: 10px; margin-bottom: 10px;">
                <strong>Jewel ID:</strong> <%# Eval("JewelID") %>
                <br />
                <strong>Name:</strong> <%# Eval("JewelName") %>
                <br />
                <strong>Price:</strong> $<%# Eval("JewelPrice") %><br /><a href='<%# "ShowDetails.aspx?id=" + Eval("JewelID") %>'>View Details</a>
            </div>
            <div>
                <h3><%# Eval("JewelName") %></h3>
                <p>Price: <%# Eval("JewelPrice") %></p>
                <p>Release Year: <%# Eval("JewelReleaseYear") %></p>
                    <asp:Button 
                            ID="btnDetail" 
                            runat="server" 
                            Text="View Details" 
                            PostBackUrl='<%# "ShowDetails.aspx?JewelID=" + Eval("JewelID") %>' />
               </div>
        
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
