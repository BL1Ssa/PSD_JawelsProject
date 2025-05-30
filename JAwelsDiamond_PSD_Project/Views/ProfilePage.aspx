<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="JAwelsDiamond_PSD_Project.Views.ProfilePage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile - JAwels & Diamonds</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Profile Information</h2>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" EnableViewState="false" />
            <table>
                <tr>
                    <td>Email:</td>
                    <td><asp:Label ID="lblEmail" runat="server" /></td>
                </tr>
                <tr>
                    <td>Username:</td>
                    <td><asp:Label ID="lblUsername" runat="server" /></td>
                </tr>
                <tr>
                    <td>Gender:</td>
                    <td><asp:Label ID="lblGender" runat="server" /></td>
                </tr>
                <tr>
                    <td>Date of Birth:</td>
                    <td><asp:Label ID="lblDOB" runat="server" /></td>
                </tr>
            </table>
            <hr />
            <h3>Change Password</h3>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="error" />
            <table>
                <tr>
                    <td>Old Password:</td>
                    <td>
                        <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="rfvOldPassword" runat="server"
                            ControlToValidate="txtOldPassword" ErrorMessage="Old password is required." Display="Dynamic" />
                        <asp:CustomValidator ID="cvOldPassword" runat="server"
                            ControlToValidate="txtOldPassword" OnServerValidate="cvOldPassword_ServerValidate"
                            ErrorMessage="Old password is incorrect." Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>New Password:</td>
                    <td>
                        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server"
                            ControlToValidate="txtNewPassword" ErrorMessage="New password is required." Display="Dynamic" />
                        <asp:CustomValidator ID="cvNewPassword" runat="server"
                            ControlToValidate="txtNewPassword" OnServerValidate="cvNewPassword_ServerValidate"
                            ErrorMessage="New password must be 8-25 alphanumeric characters." Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>Confirm Password:</td>
                    <td>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server"
                            ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm password is required." Display="Dynamic" />
                        <asp:CompareValidator ID="cvConfirmPassword" runat="server"
                            ControlToValidate="txtConfirmPassword" ControlToCompare="txtNewPassword"
                            ErrorMessage="Passwords do not match." Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>