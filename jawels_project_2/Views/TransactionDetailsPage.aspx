<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Master Page/Site.Master" CodeBehind="TransactionDetailsPage.aspx.cs" Inherits="jawels_project_2.Views.TransactionDetailsPage" %>


<asp:Content ID="Content10" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <h1>Transaction Details</h1>
            <br />

            <h3>Transaction ID</h3>
            <asp:Label ID="idlbl" runat="server" Text=""></asp:Label>
            
            <h3>Jewel Name</h3>
            <asp:Label ID="namelbl" runat="server" Text=""></asp:Label>
            
            <h3>Quantity</h3>
            <asp:Label ID="quantitylbl" runat="server" Text=""></asp:Label>

            <br />
            <br />
            <asp:Button ID="backbtn" runat="server" Text="back" OnClick="backbtn_Click" />
        </div>
</asp:Content>
