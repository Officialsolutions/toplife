<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Leader-List.aspx.cs" Inherits="Client_Leader_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style>
    @font-face
    {
        font-family:myfont;
        src:url(chatrik.ttf);   
    }
    .a {
            font-family:myfont;
        }
         </style>
        <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h3>View Leader</h3>
    <hr />
   <asp:RadioButtonList ID="ddlview" OnSelectedIndexChanged="ddlview_SelectedIndexChanged" AutoPostBack="true" runat="server">
                    <asp:ListItem Selected="True">English</asp:ListItem>
                    <asp:ListItem>Punjabi</asp:ListItem>
                </asp:RadioButtonList>
    <div class="row">
          <asp:Panel id="pnlContents" runat = "server">
    <asp:GridView ID="gvdata" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowEditing="gvdata_RowEditing" OnRowCancelingEdit="gvdata_RowCancelingEdit" OnRowUpdating="gvdata_RowUpdating" OnRowDataBound="gvdata_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="SNo">
                <ItemTemplate>
                     <%#Container.DataItemIndex+1 %> 
                </ItemTemplate>
            </asp:TemplateField>
<%--            <asp:BoundField DataField="month" HeaderText="Month" />--%>
            <asp:BoundField DataField="memberid" HeaderText="Id" />
          
            <asp:TemplateField HeaderText="Name">
                 <ItemTemplate>
                     <asp:HiddenField ID="mid" runat="server" Value='<%#Eval("memberid") %>' />
                     <asp:Panel ID="pneng" runat="server">
                      <asp:Label ID="lblname" runat="server" Text='<%#Eval("Name") %>'></asp:Label> <asp:Label ID="lbltype" runat="server" Text='<%#Eval("rel") %>'></asp:Label> <asp:Label ID="Label1" runat="server" Text='<%#Eval("father") %>'></asp:Label>
                      </asp:Panel>
                      <asp:Panel ID="pnp" runat="server" Visible="false">
                      <asp:Label ID="lblpname" runat="server" Text='<%#Eval("pname") %>' style="font-family:myfont"></asp:Label> <asp:Label ID="Label3" runat="server" Text='<%#Eval("rel") %>'></asp:Label> <asp:Label ID="Label4" runat="server" Text='<%#Eval("pfather") %>' style="font-family:myfont"></asp:Label>
                      </asp:Panel>
                 </ItemTemplate>

             </asp:TemplateField>
            
          
            <asp:BoundField DataField="mobile" HeaderText="Mobile" />
            <asp:BoundField DataField="mobile2" HeaderText="Mobile2" />
            <asp:TemplateField HeaderText="Address">
                  <ItemTemplate>
                      <asp:Panel ID="pnea" runat="server">
                      <asp:Label ID="lblename" runat="server" Text='<%#Eval("Address") %>'></asp:Label> 
                      </asp:Panel>
                      <asp:Panel ID="pnpa" runat="server" Visible="false">
                      <asp:Label ID="lblaname" runat="server" Text='<%#Eval("paddress") %>' style="font-family:myfont"></asp:Label>
                      </asp:Panel>
                   </ItemTemplate>
              </asp:TemplateField >
              <asp:TemplateField HeaderText="Status" >
                <ItemTemplate>
                   
                    <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status") %>' CssClass="a"></asp:Label>
                </ItemTemplate>
                  <EditItemTemplate>
                       <asp:HiddenField ID="hfid" runat="server" Value='<%#Eval("id") %>' />
                      <asp:TextBox ID="txtst" runat="server" CssClass="a"
                          Text='<%# Eval("status")%>'></asp:TextBox>
                  </EditItemTemplate>
              </asp:TemplateField>
            <asp:TemplateField HeaderText="Ins">
                <ItemTemplate>
                    <asp:Label ID="lblins" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pre">
                <ItemTemplate>
                    <asp:Label ID="lblpre" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cur">
                <ItemTemplate>
                    <asp:Label ID="lblcur" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                 
                    <asp:LinkButton ID="lnkdelete" Visible="false" CommandArgument='<%#Eval("id") %>' OnClick="lnkdelete_Click" runat="server">Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>
    </asp:GridView>
            </asp:Panel>
         <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
             <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
             <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td style="width: 19px;"><%=pres %></td>
            <td style="    width: 121px;"><%=curnt %></td>
        </tr>
       
    </table>
        </div>
    <div class="row">
     <a href="Leader-Punj.aspx" target="_blank" class=" btn-d">Print Punjabi</a>
        <asp:Button ID="btnPrint" class="btn-d" runat="server" Text="Print English" OnClientClick = "return PrintPanel();" />
        </div>

</asp:Content>

