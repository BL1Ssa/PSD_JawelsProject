<%@ Page Title="Jewel Details" Language="C#" MasterPageFile="~/Views/Master Page/Site.Master" AutoEventWireup="true" CodeBehind="ShowDetails.aspx.cs" Inherits="jawels_project_2.Views.ShowDetails" %>

<asp:Content ID="Content9" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Jewel Details</h2>

    <div id="jewelDetails" runat="server">
        <p><strong>Name:</strong> <asp:Label ID="lblName" runat="server" /></p>
        <p><strong>Category:</strong> <asp:Label ID="lblCategory" runat="server" /></p>
        <p><strong>Brand:</strong> <asp:Label ID="lblBrand" runat="server" /></p>
        <p><strong>Country:</strong> <asp:Label ID="lblCountry" runat="server" /></p>
        <p><strong>Class:</strong> <asp:Label ID="lblClass" runat="server" /></p>
        <p><strong>Price:</strong> $<asp:Label ID="lblPrice" runat="server" /></p>
        <p><strong>Release Year:</strong> <asp:Label ID="lblReleaseYear" runat="server" /></p>

        <!-- Customer Add to Cart -->
        <div id="customerActions" runat="server" visible="false">
            <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" OnClick="btnAddToCart_Click" />
        </div>

        <!-- Admin Edit/Delete -->
        <div id="adminActions" runat="server" visible="false">
            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        </div>
    </div>

    <div id="notFoundMessage" runat="server" visible="false">
        <p>Jewel not found!</p>
        <a href="Homepage.aspx">Back to Home</a>
    </div>
</asp:Content>
