<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Downline.aspx.cs" Inherits="Client_Default2" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <style>
    @font-face
    {
        font-family:myfont;
        src:url(chatrik.ttf);   
    }
      .design{
           position: relative;
    top: -69PX;
    RIGHT: 392PX;
    }
    .design table tbody tr {
    display: inline;
    font-size:20px;
    color:white;

}
        .design table tbody tr td{
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

<table cellpadding="0" cellspacing="0">
	<tr>
		<td height="20px">
            <table align="center" width="850px" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="ll" 
                            AutoPostBack="True" oncheckedchanged="RadioButton1_CheckedChanged" 
                            Text="All" Checked="True"/>
                            </td>
                    <td align="center">
                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="ll" 
                            AutoPostBack="True" oncheckedchanged="RadioButton2_CheckedChanged" 
                            Text="Left" />
                    </td>
                    <td align="center">
                        <asp:RadioButton ID="RadioButton3" runat="server" GroupName="ll" 
                            AutoPostBack="True" oncheckedchanged="RadioButton3_CheckedChanged" 
                            Text="Right" />
                    </td>
                    <td align="center">
                       <div class="design">
                <asp:RadioButtonList ID="ddlview" OnSelectedIndexChanged="ddlview_SelectedIndexChanged1" AutoPostBack="true" runat="server">
                    <asp:ListItem Selected="True">English</asp:ListItem>
                    <asp:ListItem>Punjabi</asp:ListItem>
                </asp:RadioButtonList>
		    
            </div>
                    </td>
                </tr>
                </table>
		</td>
	</tr>
</table>
	<form id="pnlContents" >
<asp:Panel id="pnlContents" runat = "server">
	 <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="grid f-size" HeaderStyle-CssClass="gridhead" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
         <Columns>
             <asp:BoundField DataField="SNO" HeaderText="S.No" />
             <asp:BoundField DataField="User ID" HeaderText="User ID" />
             <asp:TemplateField HeaderText="Name">
                 <ItemTemplate>
                     <asp:HiddenField ID="hfid" Value='<%#Eval("User ID") %>' runat="server" />
                     <asp:Panel ID="pneng" runat="server">
                      <asp:Label ID="lblname" runat="server" Text='<%#Eval("Name") %>'></asp:Label> <asp:Label ID="lbltype" runat="server" Text='<%#Eval("rel") %>'></asp:Label> <asp:Label ID="Label1" runat="server" Text='<%#Eval("father") %>'></asp:Label>
                      </asp:Panel>
                      <asp:Panel ID="pnp" runat="server" Visible="false">
                      <asp:Label ID="lblpname" runat="server" Text='<%#Eval("pname") %>' style="font-family:myfont"></asp:Label> <asp:Label ID="Label3" runat="server" Text='<%#Eval("rel") %>'></asp:Label> <asp:Label ID="Label4" runat="server" Text='<%#Eval("pfather") %>' style="font-family:myfont"></asp:Label>
                      </asp:Panel>
                 </ItemTemplate>

             </asp:TemplateField>
              <asp:BoundField DataField="Mobile" HeaderText="Mobile No" />
              <asp:BoundField DataField="MOBILE2" HeaderText="MOBILE2" />
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
             <asp:BoundField DataField="D-O-J" HeaderText="D-O-J" />
             <asp:BoundField DataField="Proposer ID" HeaderText="Proposer ID" />
             <asp:TemplateField HeaderText="Proposer Name" >
                 <ItemTemplate>
                      <asp:Panel ID="pnengp" runat="server">
                      <asp:Label ID="lblnamep" runat="server" Text='<%#Eval("Proposer Name") %>'></asp:Label>
                      </asp:Panel>
                      <asp:Panel ID="pnpp" runat="server" Visible="false">
                      <asp:Label ID="lblpnamep" runat="server" Text='<%#Eval("ProposerPname") %>' style="font-family:myfont"></asp:Label> 
                      </asp:Panel>
                 </ItemTemplate>
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
               <%--<asp:BoundField DataField="INS" HeaderText="INS" />
               <asp:BoundField DataField="PREV" HeaderText="PREV" />--%>
               
         </Columns>
    </asp:GridView>
</asp:Panel>
 <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn-d" OnClientClick = "return PrintPanel();" />
        <a href="punjdown.aspx" target="_blank" class=" btn-d">Print Punjabi</a>
</form>
</asp:Content>

