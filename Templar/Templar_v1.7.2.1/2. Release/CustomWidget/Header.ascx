<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="CustomWidget.Header" %>
<%@ Register Assembly="Tavisca.Templar.WebControls" Namespace="Tavisca.Templar.WebControls" TagPrefix="gtc" %>

<asp:Panel ID="HeaderPanel" runat="server" Visible="false" BackColor="Black" >
    <asp:Label ID="PageHeader" runat="server" Text="Employee Management Service" ForeColor="LimeGreen"></asp:Label>
    <asp:Table ID="NavBar" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell>
                <asp:LinkButton ID="AddRemark" PostBackUrl="~/AddRemark" Text="Add Remark" runat="server" ForeColor="LimeGreen"></asp:LinkButton>
            </asp:TableCell>
            <asp:TableCell>
                <asp:LinkButton ID="AddEmployee" PostBackUrl="~/AddEmployee" Text="Add Employee" runat="server" ForeColor="LimeGreen"></asp:LinkButton>
            </asp:TableCell>
            <asp:TableCell>
                <asp:LinkButton ID="ChangePwd" PostBackUrl="~/ChangePwd" Text="Change Password" runat="server" ForeColor="LimeGreen"></asp:LinkButton>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="Logout" Text="Logout" runat="server" ForeColor="LimeGreen" BackColor="Black" OnClick="Logout_Click" />
            </asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Panel>
