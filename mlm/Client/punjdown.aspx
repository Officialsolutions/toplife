<%@ Page Language="C#" AutoEventWireup="true" CodeFile="punjdown.aspx.cs" Inherits="Client_punjdown" %>

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
    <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="grid f-size" HeaderStyle-CssClass="gridhead" AutoGenerateColumns="false" >
         <Columns>
             <asp:BoundField DataField="SNO" HeaderText="S.No" />
             <asp:BoundField DataField="User ID" HeaderText="User ID" />
             <asp:TemplateField HeaderText="Name">
                 <ItemTemplate>
                    
                      <asp:Label ID="lblpname" runat="server" Text='<%#Eval("pname") %>' style="font-family:myfont"></asp:Label> <asp:Label ID="Label3" runat="server" Text='<%#Eval("rel") %>'></asp:Label> <asp:Label ID="Label4" runat="server" Text='<%#Eval("pfather") %>' style="font-family:myfont"></asp:Label>
                     
                 </ItemTemplate>

             </asp:TemplateField>
              <asp:BoundField DataField="Mobile" HeaderText="Mobile No" />
              <asp:BoundField DataField="MOBILE2" HeaderText="MOBILE2" />
              <asp:TemplateField HeaderText="Address">
                  <ItemTemplate>
                      
                      <asp:Label ID="lblaname" runat="server" Text='<%#Eval("paddress") %>' style="font-family:myfont"></asp:Label>
                     
                   </ItemTemplate>
              </asp:TemplateField >
             <asp:BoundField DataField="D-O-J" HeaderText="D-O-J" />
             <asp:BoundField DataField="Proposer ID" HeaderText="Proposer ID" />
             <asp:TemplateField HeaderText="Proposer Name" >
                 <ItemTemplate>
                  
                      <asp:Label ID="lblpnamep" runat="server" Text='<%#Eval("ProposerPname") %>' style="font-family:myfont"></asp:Label> 
                     
                 </ItemTemplate>
             </asp:TemplateField>
               <asp:BoundField DataField="INS" HeaderText="INS" />
               <asp:BoundField DataField="PREV" HeaderText="PREV" />
               
         </Columns>
    </asp:GridView>
    </div>
    </form>
</body>
</html>
