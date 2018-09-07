<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="transfer-report.aspx.cs" Inherits="Admin_transfer_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-12">


        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Transfer From</th>
                    <th>Transfer To</th>
                    <th>Date</th>
                    <th>Reason</th>

                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Container.DataItemIndex+1 %>
                        </td>

                        <td>
                            <%#Eval("tfrom") %>
                        </td>
                        <td>
                            <%#Eval("tto") %>
                        </td>
                        <td>
                            <asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("date")).ToString("dd/MM/yyyy") %>'></asp:Label>
                            <%--<%#Eval("date") %>--%>
                        </td>
                        <td>
                            <%#Eval("Reason") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </table>


    </div>
</asp:Content>

