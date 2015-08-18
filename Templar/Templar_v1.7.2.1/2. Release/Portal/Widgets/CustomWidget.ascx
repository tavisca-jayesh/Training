<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomWidget.ascx.cs" Inherits="CustomWidget.CustomWidget" %>
<%@ Register Assembly="Tavisca.Templar.WebControls" Namespace="Tavisca.Templar.WebControls" TagPrefix="gtc" %>

<asp:Panel ID="pnlSettings" runat="server" Visible="false">
    <gtc:TemplarLabel ID="Calculator" runat="server" Text="Calculator"></gtc:TemplarLabel>
    <gtc:TemplarCheckBoxList ID="CalculatorType" runat="server">
        <asp:ListItem Text="simple" Value="1"></asp:ListItem>
        <asp:ListItem Text="scientific" Value="2"></asp:ListItem>
    </gtc:TemplarCheckBoxList>

    <gtc:TemplarCheckBoxList ID="BgColor" runat="server">
        <asp:ListItem Text="Red" Value="Red"></asp:ListItem>
        <asp:ListItem Text="Green" Value="Green"></asp:ListItem>
        <asp:ListItem Text="Blue" Value="Blue"></asp:ListItem>
    </gtc:TemplarCheckBoxList>

    <asp:Table ID="Table1" runat="server" Visible="true">
        <asp:TableRow>
            <asp:TableHeaderCell>
                <asp:TextBox ID="OutputBox" runat="server" Text="0"></asp:TextBox>
            </asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <gtc:TemplarButton ID="num1" runat="server" Text="1" /></asp:TableCell>
            <asp:TableCell>
                <gtc:TemplarButton ID="num2" runat="server" Text="2" /></asp:TableCell>
            <asp:TableCell>
                <gtc:TemplarButton ID="num3" runat="server" Text="3" /></asp:TableCell>
            <asp:TableCell>
                <gtc:TemplarButton ID="plus" runat="server" Text="+" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <gtc:TemplarButton ID="num4" runat="server" Text="4" /></asp:TableCell>
            <asp:TableCell>
                <gtc:TemplarButton ID="num5" runat="server" Text="5" /></asp:TableCell>
            <asp:TableCell>
                <gtc:TemplarButton ID="num6" runat="server" Text="6" /></asp:TableCell>
            <asp:TableCell>
                <gtc:TemplarButton ID="minus" runat="server" Text="-" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <gtc:TemplarButton ID="num7" runat="server" Text="7" /></asp:TableCell>
            <asp:TableCell>
                <gtc:TemplarButton ID="num8" runat="server" Text="8" /></asp:TableCell>
            <asp:TableCell>
                <gtc:TemplarButton ID="num9" runat="server" Text="9" /></asp:TableCell>
            <asp:TableCell>
                <gtc:TemplarButton ID="multiply" runat="server" Text="*" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <gtc:TemplarButton ID="num0" runat="server" Text="0" /></asp:TableCell>
            <asp:TableCell>
                <gtc:TemplarButton ID="decimal" runat="server" Text="." /></asp:TableCell>
            <asp:TableCell>
                <gtc:TemplarButton ID="divide" runat="server" Text="/" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table ID="Table2" runat="server" Visible="true">
        <asp:TableRow>
            <asp:TableCell>
                <gtc:TemplarButton ID="tan" runat="server" Text="tan" /></asp:TableCell>
            <asp:TableCell>
                <gtc:TemplarButton ID="cos" runat="server" Text="cos" /></asp:TableCell>
            <asp:TableCell>
                <gtc:TemplarButton ID="sin" runat="server" Text="sin" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <gtc:TemplarButton ID="sqrt" runat="server" Text="sqrt" /></asp:TableCell>
            <asp:TableCell>
                <gtc:TemplarButton ID="log" runat="server" Text="log" /></asp:TableCell>
            <asp:TableCell>
                <gtc:TemplarButton ID="ln" runat="server" Text="ln" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <gtc:TemplarButton ID="square" runat="server" Text="X^2" /></asp:TableCell>
            <asp:TableCell>
                <gtc:TemplarButton ID="pi" runat="server" Text="Pi" /></asp:TableCell>
            <asp:TableCell>
                <gtc:TemplarButton ID="factorial" runat="server" Text="X!" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Panel>
<%--<gtc:TemplarLabel ID="Tlabel" runat="server" Text="Name" ></gtc:TemplarLabel>--%>
