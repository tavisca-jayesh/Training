<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.ascx.cs" Inherits="CustomWidget.AddEmployee" %>
<%@ Register Assembly="Tavisca.Templar.WebControls" Namespace="Tavisca.Templar.WebControls" TagPrefix="gtc" %>

<asp:Panel ID="AddEmpPanel" runat="server" Visible="false">
    <asp:Table ID="Table1" runat="server">
        <asp:TableHeaderRow>
           <asp:TableHeaderCell><gtc:TemplarLabel runat="server" Text="Add Employee" ID="TemplarLabel1"></gtc:TemplarLabel></asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label Text="Title" runat="server"></asp:Label></asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TitleBox" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="AddEmployee" ControlToValidate="TitleBox" ForeColor="Red" runat="server" ErrorMessage="Please Insert Title"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="FirstName" Text="First Name" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="FirstNameBox" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="AddEmployee" ControlToValidate="FirstNameBox" ForeColor="Red" runat="server" ErrorMessage="Please Insert First Name"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LastName" Text="Last Name" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="LastNameBox" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="AddEmployee" ControlToValidate="LastNameBox" ForeColor="Red" runat="server" ErrorMessage="Please Insert Last Name"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Email" Text="Email-Id" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="EmailBox" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="AddEmployee" ControlToValidate="EmailBox" ForeColor="Red" runat="server" ErrorMessage="Please Insert Email"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Phone" Text="Phone Number" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="PhoneBox" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="AddEmployee" ControlToValidate="PhoneBox" ForeColor="Red" runat="server" ErrorMessage="Please Insert Phone Number"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Role" Text="Role" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="RoleBox" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="AddEmployee" ControlToValidate="RoleBox" ForeColor="Red" runat="server" ErrorMessage="Please Insert Role"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>&nbsp;</asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="AddEmpSubmit" runat="server" ValidationGroup="AddEmployee" Text="Submit" OnClick="EmpSubmitButton_Click"></asp:Button>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="SuccessField" Text="Employee Added Successfully" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="FailureField" Text="Something went wrong" runat="server" Visible="false"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Panel>
