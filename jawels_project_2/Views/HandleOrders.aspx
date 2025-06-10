<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Master Page/Site.Master" CodeBehind="HandleOrders.aspx.cs" Inherits="jawels_project_2.Views.HandleOrders" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <h2>Handle Orders</h2>
        
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>

        <asp:GridView ID="gvOrders1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="TransactionID" OnRowCommand="changeOrderStatus">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction Id" />
                <asp:BoundField DataField="UserID" HeaderText="User Id" />
                <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
                
                <asp:TemplateField HeaderText="Actions">
                 <ItemTemplate>
                     <asp:Button ID="btnConfirmPayment" runat="server" Text="Confirm Payment"
                     CommandName="ConfirmPayment" CommandArgument='<%# Container.DataItemIndex %>'
                     Visible='<%# Eval("TransactionStatus").ToString().ToLower() == "payment pending" %>' />

                     <asp:Button ID="btnShipPackage" runat="server" Text="Ship Package"
                        CommandName="ShipPackage" CommandArgument='<%# Container.DataItemIndex %>'
                         Visible='<%# Eval("TransactionStatus").ToString().ToLower() == "shipment pending" %>' />

                     <asp:Label ID="lblWaiting" runat="server" Text="Waiting user confirmation..."
                        Visible='<%# Eval("TransactionStatus").ToString().ToLower() == "Arrived" %>' />

                  </ItemTemplate>
                </asp:TemplateField>

                
            </Columns>
        </asp:GridView>

</asp:Content>