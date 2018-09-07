<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="SaleHistory.aspx.cs" Inherits="Admin_SaleHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Sale History</h2>
    <div class="col-md-12">

        
        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Date</th>
                    <th>Product Name</th>
                    <th>Serial No.</th>
                    <th>Quantity</th>
                    <th>MRP</th>
                    <th>BV</th>

                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>

                        <td>
                            <%#Convert.ToDateTime(Eval("date")).ToString("dd/MM/yyyy") %></td>
                        <td>
                            <%#Eval("name") %></td>
                        <td>
                            <%#Eval("serial") %></td>
                        <td>
                            <%#Eval("qty") %></td>
                        <td>
                            <%#Eval("mrp") %></td>
                        <td>
                            <%#Eval("bv") %></td>




                </ItemTemplate>
            </asp:ListView>
        </table>


    </div>
</asp:Content>

