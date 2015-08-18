<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.ascx.cs" Inherits="CustomWidget.ChangePassword" %>
<%@ Register Assembly="Tavisca.Templar.WebControls" Namespace="Tavisca.Templar.WebControls" TagPrefix="gtc" %>

<asp:Panel ID="ChangePasswordPanel" runat="server" Visible="false">
    <asp:Table ID="Table1" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>
                <gtc:TemplarLabel runat="server" Text="Change Password" ID="ChangePwdHeader"></gtc:TemplarLabel></asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="CurrentPwd" Text="Current Password" runat="server"></asp:Label></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="CurrentPwdBox" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="ChangePwdGroup" ControlToValidate="CurrentPwdBox" ForeColor="Red" runat="server" ErrorMessage="Please Insert Current Password"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="NewPwd" Text="New Password" runat="server"></asp:Label></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="NewPwdBox" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ChangePwdGroup" ControlToValidate="NewPwdBox" ForeColor="Red" runat="server" ErrorMessage="Please Insert New Password"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="ConfirmPwd" Text="Confirm Password" runat="server"></asp:Label></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="ConfirmPwdBox" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="ChangePwdGroup" ControlToValidate="ConfirmPwdBox" ForeColor="Red" runat="server" ErrorMessage="Please Confirm Password"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPwdBox" ControlToValidate="ConfirmPwdBox" Display="Dynamic" ErrorMessage="The Confirm Password must match the New Password entry." ValidationGroup="ChangePwdGroup" ForeColor="Red"></asp:CompareValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>&nbsp;</asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="ChangePwdSubmit" runat="server" ValidationGroup="ChangePwdGroup" Text="Change Password" OnClick="ChangePwdButton_Click"></asp:Button>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="SuccessField" Text="Password Changed Successfully" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="FailureField" Text="Something went wrong" runat="server" Visible="false"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Panel>
