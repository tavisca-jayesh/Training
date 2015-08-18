<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddRemark.ascx.cs" Inherits="CustomWidget.AddRemark" %>
<%@ Register Assembly="Tavisca.Templar.WebControls" Namespace="Tavisca.Templar.WebControls" TagPrefix="gtc" %>

<asp:Panel ID="AddRemarkPanel" runat="server" Visible="false">
    <asp:Table ID="Table1" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell><gtc:TemplarLabel ID="AddRemarkHeader" runat="server" Text="Add Remark"></gtc:TemplarLabel></asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="SelectEmployee" Text="Select Employee" runat="server"></asp:Label></asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="EmployeeList" runat="server" OnSelectedIndexChanged="EmployeeList_SelectedIndexChanged" ValidationGroup="AddRemark">
            </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="RemarkLabel" Text="Remark" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <textarea id="RemarkText" runat="server" style="height: 100px; width:200px;" required="required"></textarea>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>&nbsp;</asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="AddRemarkSubmit" runat="server" ValidationGroup="AddRemark" Text="Submit" OnClick="RemarkSubmitButton_Click"></asp:Button>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="SuccessField" Text="Remark Added Successfully" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="FailureField" Text="Something went wrong" runat="server" Visible="false"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Panel>
