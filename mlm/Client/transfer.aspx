<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="transfer.aspx.cs" Inherits="Client_transfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager>
  
  
   <table cellpadding="0" cellspacing="0" border="0" class="client_table" width="500px" id="clienttable">
                	<tr>
                    	<td class="commont_title" colspan="2">
                        Transfer Installment
                        </td>
                    </tr>
                    <tr>
                    	<td>
                        	Transfer To:
                        </td>
                        <td>
                        	<asp:TextBox CssClass="textbox" ID="txtto" runat="server" OnTextChanged="txtto_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:Label ID="lblname" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                    	<td>
                        	Reason
                        </td>
                        <td>
                        	<asp:TextBox CssClass="textbox" ID="txtreason" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                   
                    <tr>
                    	<td>
                        </td>
                    	<td align="left">
                         <asp:Button CssClass="lb-buttion" ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
                        </td>
                        
                    </tr>
             
                </table>
</asp:Content>

