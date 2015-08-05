<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HRHome.aspx.cs" Inherits="TempWebFormApp.HRHome" %>

<%@ Register Src="~/AddEmployeeUserControl.ascx" TagPrefix="uc2" TagName="AddEmployeeUserControl" %>
<%@ Register Src="~/AddRemarkUserControl.ascx" TagPrefix="uc3" TagName="AddRemarkUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <!------------------------------------------------------------------------------------>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">

        <Triggers>

            <asp:AsyncPostBackTrigger ControlID="linkButton1" EventName="Click" />

            <asp:AsyncPostBackTrigger ControlID="linkButton2" EventName="Click" />

        </Triggers>

        <ContentTemplate>
            <asp:Panel ID="pnlWishList" DefaultButton="lnkWishList" runat="server">

                <asp:LinkButton ID="lnkWishList" runat="server"></asp:LinkButton>
                <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

                <div>
                    <h2 style="color: MidnightBlue; font-style: italic;">How to use MultiView
                    </h2>
                    <asp:Label ID="Label1" runat="server" />
                    <br />

                    <%--<ul class="nav nav-tabs">--%>
                    <%--<li><a data-toggle="tab" href="#AddEmployee" >Add Employee</a></li>--%>

                    <%--<li><a data-toggle="tab" href="#AddRemark" onclick="RemarkView">Add Remark</a></li>--%>
                    <%--</ul>--%>

                    <!--- View 1 -->
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View1" runat="server">
                            <%--<div id="Div1">--%>
                            <%--class="tab-pane fade in active"--%>
                            <asp:Button ID="Employee" runat="server" Text="Add Remark" OnClick="RemarkView" />
                            <asp:Button ID="Remark1" runat="server" Text="Add Employee" BackColor="#0000ff"/>
                            <br />
                            <asp:LinkButton ID="linkButton1" runat="server" Text="LinkButton1" />
                            <uc2:AddEmployeeUserControl runat="server" ID="AddEmployeeUserControl1" Visible="true" />
                            <%--</div>--%>
                        </asp:View>

                        <!--- View 2 -->

                        <asp:View ID="View2" runat="server">
                            <asp:Button ID="Remark" runat="server" Text="Add Employee" OnClick="EmployeeView" />
                            <asp:Button ID="Employee1" runat="server" Text="Add Remark" BackColor="#0000ff"/>
                            <br />
                            <%--<div id="Div2">--%>
                            <%--class="tab-pane fade"--%>
                            <asp:LinkButton ID="linkButton2" runat="server" Text="LinkButton2" />
                            <uc3:AddRemarkUserControl runat="server" ID="AddRemarkUserControl1" Visible="true" />
                            <%--</div>--%>
                        </asp:View>
                    </asp:MultiView>

                </div>

            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!---------------------------------------------------------------------------------
    <div class="container">
        <ul class="nav nav-tabs">
            <li><a data-toggle="tab" href="#AddEmployee">Add Employee</a></li>
            <li><a data-toggle="tab" href="#AddRemark">Add Remark</a></li>
        </ul>

        <div class="tab-content">

            <%--<div id="AddEmployee" class="tab-pane fade in active">
                <uc2:AddEmployeeUserControl runat="server" ID="AddEmployeeUserControl" Visible="true" />
            </div>
            <div id="AddRemark" class="tab-pane fade">
                <uc3:AddRemarkUserControl runat="server" ID="AddRemarkUserControl" Visible="true" />
            </div>--%>
        </div>
    </div>--->
</asp:Content>
