<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyOrdersPage.aspx.cs" Inherits="JAwelsDiamond_PSD_Project.Views.MyOrdersPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="OrdersGV" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="TransactionId" HeaderText="Transaction ID" />
                    <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" />
                    <asp:BoundField DataField="PaymentMethod" HeaderText="Payment Method" />
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Button ID="ConfirmBtn" runat="server" Text="Confirm" Visible="false" class="positiveBtn"/>
                            <asp:Button ID="RejectBtn" runat="server" Text="Reject" Visible="false" class="negativeBtn"/>
                            <asp:Label ID="StatusLbl" runat="server" Text='<%# Eval("Status") %>' Visible="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField Text="View Details" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
