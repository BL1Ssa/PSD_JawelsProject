<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HandleOrders.aspx.cs" Inherits="JAwelsDiamond_PSD_Project.Views.HandleOrders" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Handle Orders</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Handle Orders</h2>
        
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>

        <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="False" 
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
                        <asp:Label ID="lblWaiting" runat="server" Text="Waiting user confirmation"
                            Visible='<%# Eval("TransactionStatus").ToString().ToLower() == "arrived" %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>



    </form>
</body>
</html>