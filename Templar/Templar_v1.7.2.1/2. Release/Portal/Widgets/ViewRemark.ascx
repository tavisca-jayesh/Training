<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewRemark.ascx.cs" Inherits="CustomWidget.ViewRemark" %>
<%@ Register Assembly="Tavisca.Templar.WebControls" Namespace="Tavisca.Templar.WebControls" TagPrefix="gtc" %>

<asp:Panel ID="ViewRemarkPanel" runat="server" Visible="false">
    <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="True"  BorderStyle="None" Caption="Remarks" CaptionAlign="Top" Height="81px" PageSize="2" Width="381px" BackColor="White" BorderColor="#999999" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AllowCustomPaging="True">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />

        <PagerStyle VerticalAlign="Middle" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
</asp:Panel>
