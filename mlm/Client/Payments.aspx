<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Payments.aspx.cs" Inherits="Client_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents1.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
    <table style="align-content: center;" class="content-table">
        <tr>
            <td style="text-align: center;">
                <%--<form id="pnlContents" runat="server">--%>
                <asp:Panel ID="pnlContents1" runat="server">
                    <h2 style="text-align:center">Installment Delivery Ok</h2>
                    <asp:GridView ID="GridView1" runat="server" Width="750px" CssClass="grid" HeaderStyle-CssClass="gridhead" AutoGenerateColumns="false" OnRowCommand="Page_Load" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="SR">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="REC No.">
                                <ItemTemplate>
                                    <label><%# Eval("Rec") %></label> / <%#Eval("Name") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="Rec" HeaderText="REC No." />
                            <asp:BoundField DataField="DATE" HeaderText="DATE" />
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblpaid" runat="server" Text='<%#Eval("paid") %>' Visible="false"></asp:Label>
                                     <asp:LinkButton ID="lnktransfer" runat="server" CommandName="transfer" CommandArgument='<%#Eval("Rec") %>'>Transfer</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>

                <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn-d" OnClientClick="return PrintPanel();" Visible="false" />
                <%--  </form>--%>
                <asp:Panel ID="pnlproduct" runat="server">
                    <h2>Products</h2> 
                    <asp:GridView ID="GridView2" runat="server" Width="750px" CssClass="grid" HeaderStyle-CssClass="gridhead" AutoGenerateColumns="false" OnRowDataBound="GridView2_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="SR">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--   <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="30" />--%>
                            <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150" />
                             <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblqty" runat="server" Text='<%#Eval("qty") %>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Image">
                                <ItemTemplate>

                                    <img src='../uploadimage/<%#Eval("image") %>' width="80" />
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Price/Pic.">
                                <ItemTemplate>
                                    <asp:Label ID="lblmrp" runat="server" Text='<%#Eval("mrp") %>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BV">
                                <ItemTemplate>
                                    <asp:Label ID="lblbv" runat="server" Text='<%#Eval("bv") %>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>

                                    <asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("date")).ToString("dd/MM/yyyy") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total">
                                <ItemTemplate>
                                    <asp:Label ID="total" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BVTotal">
                                <ItemTemplate>
                                    <asp:Label ID="bvtotal" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>

</asp:Content>

