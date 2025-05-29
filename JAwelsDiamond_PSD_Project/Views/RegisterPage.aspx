<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="JAwelsDiamond_PSD_Project.Views.RegisterPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register - JAwels & Diamonds</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Register</h2>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="error" />

            <table>
                <tr>
                    <td>Email:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server"
                            ControlToValidate="txtEmail" ErrorMessage="Email is required." Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="RegexEmail" runat="server"
                            ControlToValidate="txtEmail"
                            ErrorMessage="Invalid email format."
                            ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" Display="Dynamic" />
                        <asp:CustomValidator ID="CustomEmail" runat="server" 
                            ControlToValidate="txtEmail"
                            OnServerValidate="CustomEmail_ServerValidate"
                            ErrorMessage="Email already exists." Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>Username:</td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server"
                            ControlToValidate="txtUsername" ErrorMessage="Username is required." Display="Dynamic" />
                        <asp:CustomValidator ID="CustomUsername" runat="server"
                            ControlToValidate="txtUsername"
                            OnServerValidate="CustomUsername_ServerValidate"
                            ErrorMessage="Username must be 3-25 characters." Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server"
                            ControlToValidate="txtPassword" ErrorMessage="Password is required." Display="Dynamic" />
                        <asp:CustomValidator ID="CustomPassword" runat="server"
                            ControlToValidate="txtPassword"
                            OnServerValidate="CustomPassword_ServerValidate"
                            ErrorMessage="Password must be 8-20 alphanumeric characters." Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>Confirm Password:</td>
                    <td>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword" runat="server"
                            ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm password is required." Display="Dynamic" />
                        <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                            ControlToValidate="txtConfirmPassword"
                            ControlToCompare="txtPassword"
                            ErrorMessage="Passwords do not match." Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>Gender:</td>
                    <td>
                        <asp:RadioButtonList ID="rblGender" runat="server">
                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server"
                            ControlToValidate="rblGender" InitialValue="" ErrorMessage="Gender is required." Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>Date of Birth:</td>
                    <td>
                        <asp:TextBox ID="txtDOB" runat="server" placeholder="yyyy-MM-dd" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDOB" runat="server"
                            ControlToValidate="txtDOB" ErrorMessage="Date of Birth is required." Display="Dynamic" />
                        <asp:CustomValidator ID="CustomDOB" runat="server"
                            ControlToValidate="txtDOB"
                            OnServerValidate="CustomDOB_ServerValidate"
                            ErrorMessage="Date of Birth must be before 01/01/2010." Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
