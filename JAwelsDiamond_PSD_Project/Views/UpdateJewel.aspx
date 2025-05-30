<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateJewel.aspx.cs" Inherits="JAwelsDiamond_PSD_Project.Views.UpdateJewel" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Jewel</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Update Jewel</h2>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" Visible="false"></asp:Label>
        <div>
            <asp:Label Text="Jewel Name:" runat="server" AssociatedControlID="txtJewelName" />
            <asp:TextBox ID="txtJewelName" runat="server" MaxLength="25" />
            <asp:RequiredFieldValidator ID="rfvJewelName" runat="server" ControlToValidate="txtJewelName"
                ErrorMessage="Jewel Name is required." Display="Dynamic" ForeColor="Red" />
            <asp:CustomValidator ID="cvJewelName" runat="server" ControlToValidate="txtJewelName"
                OnServerValidate="cvJewelName_ServerValidate" ErrorMessage="Jewel Name must be 3-25 characters." Display="Dynamic" ForeColor="Red" />
        </div>
        <div>
            <asp:Label Text="Category:" runat="server" AssociatedControlID="ddlCategory" />
            <asp:DropDownList ID="ddlCategory" runat="server" />
            <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategory"
                InitialValue="" ErrorMessage="Category is required." Display="Dynamic" ForeColor="Red" />
        </div>
        <div>
            <asp:Label Text="Brand:" runat="server" AssociatedControlID="ddlBrand" />
            <asp:DropDownList ID="ddlBrand" runat="server" />
            <asp:RequiredFieldValidator ID="rfvBrand" runat="server" ControlToValidate="ddlBrand"
                InitialValue="" ErrorMessage="Brand is required." Display="Dynamic" ForeColor="Red" />
        </div>
        <div>
            <asp:Label Text="Price:" runat="server" AssociatedControlID="txtPrice" />
            <asp:TextBox ID="txtPrice" runat="server" />
            <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice"
                ErrorMessage="Price is required." Display="Dynamic" ForeColor="Red" />
            <asp:RangeValidator ID="rvPrice" runat="server" ControlToValidate="txtPrice"
                MinimumValue="26" MaximumValue="999999" Type="Integer"
                ErrorMessage="Price must be more than $25." Display="Dynamic" ForeColor="Red" />
        </div>
        <div>
            <asp:Label Text="Release Year:" runat="server" AssociatedControlID="txtReleaseYear" />
            <asp:TextBox ID="txtReleaseYear" runat="server" />
            <asp:RequiredFieldValidator ID="rfvReleaseYear" runat="server" ControlToValidate="txtReleaseYear"
                ErrorMessage="Release Year is required." Display="Dynamic" ForeColor="Red" />
            <asp:CustomValidator ID="cvReleaseYear" runat="server" ControlToValidate="txtReleaseYear"
                OnServerValidate="cvReleaseYear_ServerValidate" ErrorMessage="Invalid release year." Display="Dynamic" ForeColor="Red" />
        </div>
        <div>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnGoBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        </div>


    </form>
</body>
</html>