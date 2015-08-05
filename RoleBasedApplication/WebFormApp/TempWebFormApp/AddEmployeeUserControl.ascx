<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEmployeeUserControl.ascx.cs" Inherits="TempWebFormApp.AddEmployeeUserControl" %>
<style type="text/css">
    .auto-style2 {
        width: 181px;
    }

    .auto-style3 {
        width: 340px;
    }

    .auto-style4 {
        width: 98px;
        height: 40px;
    }
</style>

<table style="width: 49%; height: 443px;">
    <tr>
        <td>Title</td>
        <td class="auto-style2">
            <asp:TextBox ID="TitleBox" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TitleBox" ForeColor="Red" runat="server" ErrorMessage="Please Insert Title"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>First Name</td>
        <td class="auto-style2">
            <asp:TextBox ID="FirstNameBox" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="FirstNameBox" ForeColor="Red" runat="server" ErrorMessage="Please Insert First Name"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Last Name</td>
        <td class="auto-style2">
            <asp:TextBox ID="LastNameBox" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="LastNameBox" ForeColor="Red" runat="server" ErrorMessage="Please Insert Last Name"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Email Id</td>
        <td class="auto-style2">
            <asp:TextBox ID="EmailBox" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="EmailBox" ForeColor="Red" runat="server" ErrorMessage="Please Insert Email Id"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Phone No</td>
        <td class="auto-style2">
            <asp:TextBox ID="PhoneBox" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="PhoneBox" ForeColor="Red" runat="server" ErrorMessage="Please Insert Phone Number"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style2">
            <asp:ImageButton ImageUrl="Images/sub21.gif" ID="EmpSubmitButton" runat="server" Height="34px" Width="92px" OnClick="EmpSubmitButton_Click"/>  <!--OnClick="ImageButton1_Click"-->
        </td>
        <td class="auto-style3">&nbsp;</td>
    </tr>
</table>

