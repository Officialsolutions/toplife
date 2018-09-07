<%@ Page Language="C#" AutoEventWireup="true" CodeFile="punjdirect.aspx.cs" Inherits="Client_punjdirect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        @font-face
    {
        font-family:myfont;
        src:url(chatrik.ttf);   
    }
    </style>
</head>
<body onload="window.print()">
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="GridView1" runat="server"  Width="100%" CssClass="grid" HeaderStyle-CssClass="gridhead" AutoGenerateColumns="false">
          <Columns>
              <asp:BoundField DataField="S.No" HeaderText="S.No" />
              <asp:BoundField DataField="UserId" HeaderText="UserId" />
              <asp:BoundField DataField="DOJ" HeaderText="DOJ" />
              <asp:TemplateField HeaderText="Name">
                  <ItemTemplate>
                      
                      <asp:Label ID="lblpname" runat="server" Text='<%#Eval("pname") %>' style="font-family:myfont"></asp:Label> <asp:Label ID="Label3" runat="server" Text='<%#Eval("rel") %>'></asp:Label> <asp:Label ID="Label4" runat="server" Text='<%#Eval("pfather") %>' style="font-family:myfont"></asp:Label>
                     
                   </ItemTemplate>
              </asp:TemplateField >
               <asp:BoundField DataField="Mobile No." HeaderText="Mobile No" />
              <asp:BoundField DataField="MOBILE2" HeaderText="MOBILE2" />
               <asp:TemplateField HeaderText="Address">
                  <ItemTemplate>
                     
                      <asp:Label ID="lblaname" runat="server" Text='<%#Eval("paddress") %>' style="font-family:myfont"></asp:Label>
                      
                   </ItemTemplate>
              </asp:TemplateField >
               <asp:BoundField DataField="INS" HeaderText="INS" />
               <asp:BoundField DataField="PREV" HeaderText="PREV" />
               <asp:BoundField DataField="CUR" HeaderText="CUR" />
              
          </Columns>
    </asp:GridView>
    </div>
    </form>
</body>
</html>
