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
                <asp:GridView ID="OrdersGV" runat="server" AutoGenerateColumns="False" OnRowCommand="OrdersGV_RowCommand" OnRowDataBound="OrdersGV_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                        <asp:BoundField DataField="Transaction Date" HeaderText="Transaction Date" />
                        <asp:BoundField DataField="PaymentMethod" HeaderText="Payment Method" />
                        <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnView" runat="server" Text="View Details" CommandName="View" CommandArgument='<%# Eval("TransactionID") %>' />
                            <asp:Button ID="btnConfirm" runat="server" Text="Confirm" CommandName="Confirm" CommandArgument='<%# Eval("TransactionID") %>' Visible="false" />
                            <asp:Button ID="btnReject" runat="server" Text="Reject" CommandName="Reject" CommandArgument='<%# Eval("TransactionID") %>' Visible="false" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    </Columns>
            </asp:GridView>
                <br />
                <br />
                <asp:Button ID="backbtn" runat="server" Text="Back" OnClick="Backbtn_Click" />

        </div>
    </form>

</body>
</html>