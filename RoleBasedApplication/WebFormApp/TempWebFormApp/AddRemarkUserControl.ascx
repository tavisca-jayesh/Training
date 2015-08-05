<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddRemarkUserControl.ascx.cs" Inherits="TempWebFormApp.AddRemarkUserControl" %>

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
            Employee-Id</td>
        <td class="auto-style6">
            <asp:TextBox id="EmployeeIdText" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style2">
            <asp:RequiredFieldValidator ID="RequiredEmployeeId" ForeColor="Red" ControlToValidate="EmployeeIdText" runat="server" ErrorMessage="Please insert Employee Id"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">
            Remark</td>
        <td class="auto-style6">
            <textarea id="RemarkText" runat="server" name="S1" style="height: 99px; width:200px;"></textarea></td>
        <td class="auto-style2">
            <asp:ImageButton ID="ImageButton1" runat="server" Height="34px" ImageUrl="Images/sub21.gif" Width="92px" OnClick="ImageButton1_Click" />
        </td>
    </tr>
</table>

