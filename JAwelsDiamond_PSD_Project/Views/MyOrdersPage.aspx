<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyOrdersPage.aspx.cs" Inherits="JAwelsDiamond_PSD_Project.Views.MyOrdersPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>My Orders</h1>
                <asp:GridView ID="OrdersGV" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="OrdersGV_SelectedIndexChanged" OnRowCommand="OrdersGV_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                        <asp:BoundField DataField="Transaction Date" HeaderText="Transaction Date" />
                        <asp:BoundField DataField="PaymentMethod" HeaderText="Payment Method" />
                        <asp:TemplateField HeaderText="Status">
                           <ItemTemplate>
                                <asp:Label ID="lblPending" runat="server" Text="Pending" Visible="false" CssClass="text-muted" />
                                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" CommandName="Confirm" Visible="false" />
                                <asp:Button ID="btnReject" runat="server" Text="Reject" CommandName="Reject" Visible="false" />
                           </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField Text="View Details" />
                    </Columns>
            </asp:GridView>

        </div>
    </form>

</body>
</html>
