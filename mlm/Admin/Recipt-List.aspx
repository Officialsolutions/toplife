<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Recipt-List.aspx.cs" Inherits="Admin_Recipt_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        table#ctl00_ContentPlaceHolder1_chkp tbody tr {
    display: inline;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="SNO">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField DataField="SR" HeaderText="Billno" />
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="name" HeaderText="Name" />
             <asp:BoundField DataField="father" HeaderText="Father" />
             <asp:BoundField DataField="address" HeaderText="Address" />
             <asp:BoundField DataField="mobile" HeaderText="Mobile" />
           <asp:TemplateField HeaderText="Date">
               <ItemTemplate>
                  
                   <asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("DATE_ENTRY")).ToString("dd/MM/yyyy") %>'></asp:Label>
               </ItemTemplate>
           </asp:TemplateField>
           <%-- <asp:BoundField DataField="DATE_ENTRY" HeaderText="Date" />--%>
            <asp:TemplateField HeaderText="Amount">
                <ItemTemplate>
                    <asp:HiddenField ID="hfid" Value='<%#Eval("id") %>' runat="server" />
                    <asp:Label ID="lbltotal" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:Label ID="lblprice" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="col-md-8">
         <b>Pending Receipt</b>
    <asp:CheckBoxList ID="chkp" runat="server"></asp:CheckBoxList>
    <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click" />
    </div>
    <div class="col-md-4">
        <table style="width: 100%;">
            <tr>
                <td>Total Amount=<%=Finaltotal %></td>
              
            </tr>
            <tr>
                <td>Total2= <%= countdata %></td>
               
            </tr>
            <tr>
                <td>Balance= <%=balance %></td>
               
            </tr>
        </table>
        <%--<span style="    position: relative;
    left: 584px;
    font-size: 14px;
    font-weight: bold;"></span> .
    <span style="position: relative;
    left: 488px;
    font-size: 14px;
    top: 20px;
    font-weight: bold;"></span>
    <span style="    position: absolute;
    right: 125px;
    bottom: 8px;
    font-size: 14px;
    font-weight: bold;"></span>--%>
    </div>
   
 
</asp:Content>

