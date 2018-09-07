<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Direct.aspx.cs" Inherits="Client_Default2" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 615px;
        }
    </style>
    <style>
    @font-face
    {
        font-family:myfont;
        src:url(chatrik.ttf);   
    }
        .a {
            font-family:myfont;
        }
    .design{
           position: relative;
    top: -61PX;
    RIGHT: 668PX;
    }
    .design table tbody tr {
    display: inline;
    font-size:20px;
    color:white;

}
        .design table tbody tr td {
            background:green;
        }
    </style>
    </asp:Content>   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
 <table cellpedding="0" cellspacing="0">
	<tr>
		<td height="20px">

		</td>
        <td height="20px" class="auto-style1">

		</td>
        <td height="20px">
            <div class="design">
                <asp:RadioButtonList ID="ddlview" OnSelectedIndexChanged="ddlview_SelectedIndexChanged1" AutoPostBack="true" runat="server">
                    <asp:ListItem Selected="True">English</asp:ListItem>
                    <asp:ListItem>Punjabi</asp:ListItem>
                </asp:RadioButtonList>
		    
            </div>
		</td>
	</tr>
</table>
	<form id="pnlContents2" >
<asp:Panel id="pnlContents" runat = "server">
	  <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" Width="100%" CssClass="grid" HeaderStyle-CssClass="gridhead" AutoGenerateColumns="false">
          <Columns>
              <asp:BoundField DataField="S.No" HeaderText="S.No" />
              <asp:BoundField DataField="UserId" HeaderText="UserId" />
              <asp:BoundField DataField="DOJ" HeaderText="DOJ" />
              <asp:TemplateField HeaderText="Name">
                  <ItemTemplate>
                      <asp:Panel ID="pneng" runat="server">
                      <asp:Label ID="lblname" runat="server" Text='<%#Eval("Name") %>'></asp:Label> <asp:Label ID="lbltype" runat="server" Text='<%#Eval("rel") %>'></asp:Label> <asp:Label ID="Label1" runat="server" Text='<%#Eval("father") %>'></asp:Label>
                      </asp:Panel>
                      <asp:Panel ID="pnp" runat="server" Visible="false">
                      <asp:Label ID="lblpname" runat="server" Text='<%#Eval("pname") %>'  CssClass="a"></asp:Label> <asp:Label ID="Label3" runat="server" Text='<%#Eval("rel") %>'></asp:Label> <asp:Label ID="Label4" runat="server" Text='<%#Eval("pfather") %>' style="font-family:myfont"></asp:Label>
                      </asp:Panel>
                   </ItemTemplate>
              </asp:TemplateField >
               <asp:BoundField DataField="Mobile No." HeaderText="Mobile No" />
              <asp:BoundField DataField="MOBILE2" HeaderText="MOBILE2" />
               <asp:TemplateField HeaderText="Address">
                  <ItemTemplate>
                      <asp:HiddenField ID="hfreg" Value='<%#Eval("UserId") %>' runat="server" />
                      <asp:Panel ID="pnea" runat="server">
                      <asp:Label ID="lblename" runat="server" Text='<%#Eval("Address") %>'></asp:Label> 
                      </asp:Panel>
                      <asp:Panel ID="pnpa" runat="server" Visible="false">
                      <asp:Label ID="lblaname" runat="server" Text='<%#Eval("paddress") %>' style="font-family:myfont"></asp:Label>
                          <asp:HiddenField ID="hfin" runat="server" Value='<%#Eval("ins") %>' />
                      </asp:Panel>
                   </ItemTemplate>
              </asp:TemplateField >
               <asp:BoundField DataField="INS" HeaderText="INS" />
               <asp:BoundField DataField="PREV" HeaderText="PREV" />
               <asp:BoundField DataField="CUR" HeaderText="CUR" />
              
          </Columns>
    </asp:GridView>
</asp:Panel>
 <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn-d" OnClientClick = "return PrintPanel();" />
     <a href="punjdirect.aspx" target="_blank" class=" btn-d">Print Punjabi</a>
</form>
</asp:Content>

