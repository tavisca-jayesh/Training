<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="CustomWidget.Login" %>
<%@ Register Assembly="Tavisca.Templar.WebControls" Namespace="Tavisca.Templar.WebControls" TagPrefix="gtc" %>

<asp:Panel ID="LoginPanel" runat="server" Visible="false">
    <asp:Table runat="server" Visible="true">
        <asp:TableRow>
            <asp:TableHeaderCell> Login Widget</asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <gtc:TemplarLabel ID="UserId" Text="User Id:" runat="server"></gtc:TemplarLabel>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="UserIdBox" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <gtc:TemplarLabel ID="Password" Text="Password:" runat="server"></gtc:TemplarLabel>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="PwdBox" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:CheckBox ID="RememberMe" runat="server" />
                <asp:Label ID="RemMe" Text="Remember Me" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="SubmitLogin" runat="server" Text="Login" OnClick="SubmitLogin_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="FailureField" Text="Something went wrong" runat="server" Visible="false"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

</asp:Panel>
