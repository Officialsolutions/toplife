<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="transfer-report.aspx.cs" Inherits="Client_transfer_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="align-content: center;" class="content-table">
        <tr>
            <td style="text-align: center;">
        
                    <asp:GridView ID="GridView1" runat="server" Width="750px" CssClass="grid" HeaderStyle-CssClass="gridhead" AutoGenerateColumns="false" >
                        <Columns>
                            <asp:TemplateField HeaderText="SR">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="tto" HeaderText="Transfer To" />
                            <asp:BoundField DataField="Reason" HeaderText="Reason" />
                             <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>

                                    <asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("date")).ToString("dd/MM/yyyy") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <%-- <asp:BoundField DataField="DATE" HeaderText="DATE" />--%>
                        </Columns>
                    </asp:GridView>
              </td>
        </tr>
    </table>
</asp:Content>

