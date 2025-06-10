<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Master Page/Site.Master" CodeBehind="Cart.aspx.cs" Inherits="jawels_project_2.Views.Cart" %>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <h2>My Cart</h2>

        <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" DataKeyNames="JewelID" OnRowCommand="gvCart_RowCommand">
            <Columns>
                <asp:BoundField DataField="JewelID" HeaderText="Jewel ID" />
                <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" />
                <asp:BoundField DataField="BrandName" HeaderText="Brand" />
                <asp:BoundField DataField="JewelPrice" HeaderText="Price" DataFormatString="{0:C}" />
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQty" runat="server" Text='<%# Bind("Quantity") %>' Width="50px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="UpdateItem" CommandArgument='<%# Container.DataItemIndex %>' />
                        <asp:Button ID="btnRemove" runat="server" Text="Remove" CommandName="RemoveItem" CommandArgument='<%# Container.DataItemIndex %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <br />
        <asp:Label ID="lblTotal" runat="server" Font-Bold="true" />

        <br /><br />
        Payment Method:
        <asp:DropDownList ID="ddlPaymentMethod" runat="server">
            <asp:ListItem Text="--Select Payment Method--" Value="" />
            <asp:ListItem Text="PayPal" Value="PayPal" />
            <asp:ListItem Text="Visa" Value="Visa" />
            <asp:ListItem Text="MasterCard" Value="MasterCard" />
        </asp:DropDownList>
        <asp:Label ID="lblPaymentError" runat="server" ForeColor="Red" Visible="false" />

        <br /><br />
        <asp:Button ID="btnClearCart" runat="server" Text="Clear Cart" OnClick="btnClearCart_Click" />
        <asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />

 </asp:Content>

