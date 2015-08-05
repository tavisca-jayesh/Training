<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginUserControl.ascx.cs" Inherits="TempWebFormApp.LoginUserControl" %>

<asp:Panel ID="Panel1" runat="server" Height="375px" Width="417px">

    <br />
    <table style="width: 100%; height: 177px;">
        <tr>
            <td>Login</td>
            <td>
                <asp:TextBox ID="UserId" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserId" ErrorMessage="Please Enter the User Name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password" ErrorMessage="Please Enter the Password" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="PasswordValidator" runat="server" ControlToValidate="Password"
                    ErrorMessage="Password should be atleast 7 characters long and should contain at least one number"
                    ForeColor="Red"
                    ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{7,})$">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="Submit" runat="server" Text="Login" OnClick="Submit_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Panel>
