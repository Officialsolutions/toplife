<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Leader-search.aspx.cs" Inherits="Admin_Leader_search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        th {
    color: #555;
    font-weight: bold;
    border-top: 1px solid #222;
    background-color: #2F2F2F;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-12">
        <h3>Leader Search</h3>
        <hr />
    <table cellpadding="0" cellspacing="0" border="0" class="dataTable" id="example">
    <thead>
        <tr>
            <th>id</th>
            <th>Name</th>
            <th>Member</th>
            <th>MemberId</th>
            <th>Mobile</th>
            
        </tr>
    </thead>
    <tbody>
        <asp:ListView ID="ListView1" runat="server" >
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("id") %>
                    </td>
                    <td>

                    <%#Eval("name") %> 
                    </td>
                    <td><%#Eval("member") %></td>
                    <td><%#Eval("memberid") %></td>
                    <td><%#Eval("mobile") %></td>
                    
                    
                    
                </tr>
            </ItemTemplate>
        </asp:ListView>
       
        </tbody>
        </table>
</div>

      <link rel="stylesheet" type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.0/css/jquery.dataTables.css" />
      <link rel="stylesheet" type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.0/css/jquery.dataTables_themeroller.css" />


        <script type="text/javascript" charset="utf8" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.7.1.min.js"></script>
        <script type="text/javascript" charset="utf8" src="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.0/jquery.dataTables.min.js"></script>
    <script>$(document).ready(function() {
    $('#example').dataTable({"sPaginationType": "full_numbers"});
});</script>
</asp:Content>

