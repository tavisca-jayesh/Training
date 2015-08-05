<%--<%@ Page Language="C#" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>How to use MultiView control in asp.net</title>
</head>
<body style="padding: 25px">
    <form id="form1" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">

            <Triggers>

                <asp:AsyncPostBackTrigger ControlID="linkButton1" EventName="Click" />

                <asp:AsyncPostBackTrigger ControlID="linkButton2" EventName="Click" />

                <asp:AsyncPostBackTrigger ControlID="linkButton2" EventName="Click" />

            </Triggers>

            <ContentTemplate>
                <asp:Panel ID="pnlWishList" DefaultButton="lnkWishList" runat="server">

                    <asp:LinkButton ID="lnkWishList" runat="server">HELL</asp:LinkButton>

                    <script runat="server">
                        protected void Page_Load(object sender, System.EventArgs e)
                        {
                            if (!Page.IsPostBack)
                            {
                                MultiView1.ActiveViewIndex = 0;
                            }
                        }

                        void NextImage(object sender, System.EventArgs e)
                        {
                            MultiView1.ActiveViewIndex += 1;
                        }
                        void PrevImage(object sender, System.EventArgs e)
                        {
                            MultiView1.ActiveViewIndex -= 1;
                        }

                        protected void Page_PreRender(object sender, System.EventArgs e)
                        {
                            Label1.Text = "Beautiful birds images : " +
                                (MultiView1.ActiveViewIndex + 1).ToString() +
                                " of " + MultiView1.Views.Count.ToString();
                        }
                    </script>


                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <div>
                        <h2 style="color: MidnightBlue; font-style: italic;">How to use MultiView
                        </h2>

                        <asp:Label
                            ID="Label1"
                            runat="server"
                            Font-Bold="true"
                            Font-Names="Comic Sans MS"
                            ForeColor="Crimson"
                            Font-Italic="true"
                            Font-Size="X-Large" />
                        <br />
                        <asp:LinkButton ID="linkButton1" runat="server" Text="LinkButton1" />
                        <br />
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <asp:Image
                                    ID="Image1"
                                    runat="server"
                                    ImageUrl="~/Images/orderedList0.png"
                                    Height="300" />
                                <br />
                                <asp:Button
                                    ID="Button1"
                                    runat="server"
                                    Text="Next Image"
                                    OnClick="NextImage"
                                    Font-Bold="true"
                                    ForeColor="Navy"
                                    Height="45"
                                    Width="150" />

                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <br />
                                <asp:LinkButton ID="linkButton2" runat="server" Text="LinkButton2" />
                                <br />
                                <asp:Image
                                    ID="Image2"
                                    runat="server"
                                    ImageUrl="~/Images/orderedList1.png"
                                    Height="300" />
                                <br />
                                <asp:Button
                                    ID="Button2"
                                    runat="server"
                                    Text="Next Image"
                                    OnClick="NextImage"
                                    Font-Bold="true"
                                    ForeColor="Navy"
                                    Height="45"
                                    Width="150" />
                                <asp:Button
                                    ID="Button5"
                                    runat="server"
                                    Text="Prev Image"
                                    OnClick="PrevImage"
                                    Font-Bold="true"
                                    ForeColor="Navy"
                                    Height="45"
                                    Width="150" />
                            </asp:View>
                            <asp:View ID="View3" runat="server">
                                <br />
                                <asp:LinkButton ID="linkButton3" runat="server" Text="LinkButton3" />
                                <br />
                                <asp:Image
                                    ID="Image3"
                                    runat="server"
                                    ImageUrl="~/Images/orderedList2.png"
                                    Height="300" />
                                <br />
                                <asp:Button
                                    ID="Button3"
                                    runat="server"
                                    Text="Next Image"
                                    OnClick="NextImage"
                                    Font-Bold="true"
                                    ForeColor="Navy"
                                    Height="45"
                                    Width="150" />
                                <asp:Button
                                    ID="Button6"
                                    runat="server"
                                    Text="Prev Image"
                                    OnClick="PrevImage"
                                    Font-Bold="true"
                                    ForeColor="Navy"
                                    Height="45"
                                    Width="150" />
                            </asp:View>
                            <asp:View ID="View4" runat="server">
                                <asp:Image
                                    ID="Image4"
                                    runat="server"
                                    ImageUrl="~/Images/orderedList3.png"
                                    Height="300" />
                                <br />
                                <asp:Button
                                    ID="Button4"
                                    runat="server"
                                    Text="Next Image"
                                    OnClick="NextImage"
                                    Font-Bold="true"
                                    ForeColor="Navy"
                                    Height="45"
                                    Width="150" />
                                <asp:Button
                                    ID="Button7"
                                    runat="server"
                                    Text="Prev Image"
                                    OnClick="PrevImage"
                                    Font-Bold="true"
                                    ForeColor="Navy"
                                    Height="45"
                                    Width="150" />
                            </asp:View>
                            <asp:View ID="View5" runat="server">
                                <asp:Image
                                    ID="Image5"
                                    runat="server"
                                    ImageUrl="~/Images/orderedList4.png"
                                    Height="300" />
                                <br />
                                <span style="width: 150px">&nbsp</span>
                                <asp:Button
                                    ID="Button8"
                                    runat="server"
                                    Text="Prev Image"
                                    OnClick="PrevImage"
                                    Font-Bold="true"
                                    ForeColor="Navy"
                                    Height="45"
                                    Width="150" />
                            </asp:View>
                        </asp:MultiView>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

</body>
</html>--%>
