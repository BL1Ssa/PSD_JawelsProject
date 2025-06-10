<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Master Page/Site.Master" CodeBehind="AddJewel.aspx.cs" Inherits="jawels_project_2.Views.AddJewel" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <h2>Add Jewel</h2>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <table>
            <tr>
                <td>Jewel Name:</td>
                <td>
                    <asp:TextBox ID="txtJewelName" runat="server" MaxLength="25" />
                    <asp:RequiredFieldValidator ID="rfvJewelName" runat="server" ControlToValidate="txtJewelName"
                        ErrorMessage="Jewel name is required." ForeColor="Red" Display="Dynamic" />
                    <asp:CustomValidator ID="cvJewelName" runat="server" ControlToValidate="txtJewelName"
                        OnServerValidate="cvJewelName_ServerValidate" ErrorMessage="Name must be 3-25 characters." ForeColor="Red" Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td>Category:</td>
                <td>
                    <asp:DropDownList ID="ddlCategory" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategory"
                        InitialValue="" ErrorMessage="Category is required." ForeColor="Red" Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td>Brand:</td>
                <td>
                    <asp:DropDownList ID="ddlBrand" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvBrand" runat="server" ControlToValidate="ddlBrand"
                        InitialValue="" ErrorMessage="Brand is required." ForeColor="Red" Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td>Price ($):</td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice"
                        ErrorMessage="Price is required." ForeColor="Red" Display="Dynamic" />
                    <asp:RangeValidator ID="rvPrice" runat="server" ControlToValidate="txtPrice"
                        MinimumValue="26" MaximumValue="10000" Type="Double"
                        ErrorMessage="Price must be greater than $25." ForeColor="Red" Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td>Release Year:</td>
                <td>
                    <asp:TextBox ID="txtReleaseYear" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvReleaseYear" runat="server" ControlToValidate="txtReleaseYear"
                        ErrorMessage="Release year is required." ForeColor="Red" Display="Dynamic" />
                    <asp:CustomValidator ID="cvReleaseYear" runat="server" ControlToValidate="txtReleaseYear"
                        OnServerValidate="cvReleaseYear_ServerValidate" ErrorMessage="Release year must be less than current year." ForeColor="Red" Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:right;">
                    <asp:Button ID="btnAddJewel" runat="server" Text="Add Jewel" OnClick="btnAddJewel_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" />
                </td>
            </tr>
        </table>
</asp:Content>