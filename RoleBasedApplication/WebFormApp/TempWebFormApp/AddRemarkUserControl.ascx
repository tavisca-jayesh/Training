<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddRemarkUserControl.ascx.cs" Inherits="EmployeeRemarkApp.UI.AddRemarkUserControl" %>

<style type="text/css">
    .auto-style2 {
        width: 30px;
    }
    .auto-style6 {
        width: 30px;
    }
</style>

<table style="width: 49%; height: 399px; padding: 0;">
    <tr>
        <td class="auto-style6">
            Employee-Name</td>
        <td class="auto-style6">
            <asp:DropDownList ID="EmployeeList" runat="server" OnSelectedIndexChanged="EmployeeList_SelectedIndexChanged">
            </asp:DropDownList>
    </tr>
    <tr>
        <td class="auto-style6">
            Remark</td>
        <td class="auto-style6">
            <textarea id="RemarkText" runat="server" name="S1" style="height: 99px; width:200px;"></textarea></td>
        <td class="auto-style2">
            <asp:ImageButton ID="AddRemarkButton" runat="server" Height="34px" ValidationGroup="AddRemark" ImageUrl="Images/sub21.gif" Width="92px" OnClick="AddRemarkButton_Click" />
        </td>
    </tr>
</table>

