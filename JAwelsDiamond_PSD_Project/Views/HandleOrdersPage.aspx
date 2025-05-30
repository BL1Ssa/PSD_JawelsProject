<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HandleOrdersPage.aspx.cs" Inherits="JAwelsDiamond_PSD_Project.Views.HandleOrders" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Handle Orders</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="False" OnRowCommand="gvOrders_RowCommand">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction Id" />
                <asp:BoundField DataField="UserID" HeaderText="User Id" />
                <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <%# 
                            Eval("Status").ToString() == "Payment Pending" 
                                ? "<asp:LinkButton runat='server' CommandName='ConfirmPayment' CommandArgument='" + Eval("TransactionId") + "'>Confirm Payment</asp:LinkButton>"
                            : Eval("Status").ToString() == "Shipment Pending"
                                ? "<asp:LinkButton runat='server' CommandName='ShipPackage' CommandArgument='" + Eval("TransactionId") + "'>Ship Package</asp:LinkButton>"
                            : Eval("Status").ToString() == "Arrived"
                                ? "Waiting user confirmation..."
                            : ""
                        %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>