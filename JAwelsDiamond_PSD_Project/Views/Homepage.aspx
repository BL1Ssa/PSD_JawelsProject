<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="JAwelsDiamond_PSD_Project.Views.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="BtnRedirAddJewel" runat="server" Text="Add Jewel" PostBackUrl="~/Views/AddJewel.aspx" />
            <asp:Button ID="BtnRedirHandleOrder" runat="server" Text="Handle Jewel" PostBackUrl="~/Views/HandleOrders.aspx" />

            <asp:GridView ID="gvJewels" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="JewelID" HeaderText="Jewel ID" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlUpdate" runat="server"
                                NavigateUrl='<%# Eval("JewelID", "~/Views/UpdateJewel.aspx?id={0}") %>'
                                Text="Update" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>