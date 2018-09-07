<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="All-Memeber-List.aspx.cs" Inherits="Admin_All_Memeber_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-12">
        <div class="col-md-3">
            <asp:DropDownList ID="ddlmonth" runat="server">
                <asp:ListItem>Nov</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-3">
            <asp:DropDownList ID="ddlyear" runat="server">
                <asp:ListItem>2017</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="col-md-12">
    <table cellpadding="0" cellspacing="0" border="0" class="dataTable" id="example">
    <thead>
        <tr>
            <th>id</th>
            <th>Name</th>
            <th>Address</th>
            <th>Mobile</th>
            <th>Spon</th>
            <th>DateEntry</th>
            <th>Assign Id</th>
        </tr>
    </thead>
    <tbody>
        <asp:ListView ID="ListView1" runat="server" OnItemDataBound="ListView1_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("id") %>
                    </td>
                    <td>

                          <asp:HiddenField ID="hfid" Value='<%#Eval("id") %>' runat="server" />
                    <%#Eval("name") %> <%#Eval("Rel") %> <%#Eval("father") %>
                    </td>
                    <td><%#Eval("address") %></td>
                    <td><%#Eval("mobile") %></td>
                    <td><%#Eval("spon") %></td>
                    <td><%#Eval("date_entry") %></td>
                    <td>
                           <asp:TextBox ID="txtid" runat="server" placeholder="Leader Id" style="font-size: 16px;
    color: green;
    font-weight: bold;"></asp:TextBox>
                    </td>
                    
                </tr>
            </ItemTemplate>
        </asp:ListView>
       
        </tbody>
        </table>
</div>



    <asp:GridView Visible="false" ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Id" />
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:HiddenField ID="hfid" Value='<%#Eval("id") %>' runat="server" />
                    <%#Eval("name") %> <%#Eval("Rel") %> <%#Eval("father") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="address" HeaderText="Address" />
            <asp:BoundField DataField="mobile" HeaderText="Mobile" />
            <asp:BoundField DataField="spon" HeaderText="Sponser" />
            <asp:BoundField DataField="date_entry" HeaderText="DOJ" />
            <asp:TemplateField HeaderText="Assign Id">
                <ItemTemplate>
                 <%--   <asp:TextBox ID="txtid" runat="server" placeholder="Leader Id" style="font-size: 16px;
    color: green;
    font-weight: bold;"></asp:TextBox>--%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnupdate" runat="server" OnClick="btnupdate_Click" Text="Update Data" />




            <link rel="stylesheet" type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.0/css/jquery.dataTables.css" />
      <link rel="stylesheet" type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.0/css/jquery.dataTables_themeroller.css" />


        <script type="text/javascript" charset="utf8" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.7.1.min.js"></script>
        <script type="text/javascript" charset="utf8" src="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.0/jquery.dataTables.min.js"></script>
    <script>$(document).ready(function() {
    $('#example').dataTable({"sPaginationType": "full_numbers"});
});</script>
</asp:Content>

