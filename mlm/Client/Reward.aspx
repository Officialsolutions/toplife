<%@ Page Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Reward.aspx.cs" Inherits="Client_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpedding="0" cellspacing="0">
	<tr>
		<td height="20px">
		</td>
	</tr>
</table>
<table width="100%" class="my-table" id="reward_top">
<tr>
	<td height="20px">
	</td>
</tr>
<tr>
<td class="my-table-header" align="center">My Active Left</td>
<td class="my-table-header" align="center">My Active Right</td>
</tr>
<tr>
<td class="my-table-td-center" align="center"><asp:Label ID="Label33" runat="server" Text="Label"></asp:Label>
     <b>Active Id :</b> <%=ActiveidL %>

</td>
<td class="my-table-td-center" align="center"><asp:Label ID="Label34" runat="server" Text="Label"></asp:Label>

       <b>Active Id :</b> <%=Activeid %>
</td>
</tr>
<tr>
	<td height="20px">
	</td>
</tr>
</table>
<table cellpedding="0" cellspacing="0">
	<tr>
		<td height="20px">
		</td>
	</tr>
</table>
  
			 
			 <table cellpadding="0" cellspacing="0" border="0" width="100%" align="center" class="payment_report_table">
                  	<tr class="table_title">
                    	<td>
                        	Sr No.
                        </td>
                        <td>
                        	Team Size
                        </td>
                        <td>
                        	Rewards
                        </td>
                        <td>
                        	Achievement
                        </td>
                        <td>
                        	Paid</td>
                        <td>
                        	Date</td>
                    </tr>
                    <tr class="table_data">
                    	<td>
                        	1
                        </td>
                        <td>
                        	4 Direct Proposer (Star DIstributor) </td>
                        <td>
                        	Dinner Set
                        </td>
                        <td>
                        	<asp:Label ID="Label9" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                        <td>
                        	<asp:Label ID="Label10" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                        <td>
                        	<asp:Label ID="Label3" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                    </tr>
                    <tr class="table_data">
                    	<td>
                        	2
                        </td>
                        <td>
                        	30+30 (Silver Distributor)</td>
                        <td>
                        	40" LED</td>
                        <td>
                        	<asp:Label ID="Label11" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                        <td>
                        	<asp:Label ID="Label12" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                        <td>
                        	<asp:Label ID="Label4" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                    </tr>
                    <tr class="table_data">
                    	<td>
                        	3
                        </td>
                        <td>
                        	125+125 (Gold Distributor)</td>
                        <td>
                        	Pulsar Bike</td>
                        <td>
                        	<asp:Label ID="Label13" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                        <td>
                        	<asp:Label ID="Label14" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                        <td>
                        	<asp:Label ID="Label5" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                    </tr>
                    <tr class="table_data">
                    	<td>
                        	4
                        </td>
                        <td>
                        	500+500 (Star Gold Distributor)</td>
                        <td>
                        	Bullet Bike
                        </td>
                        <td>
                        	<asp:Label ID="Label15" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                        <td>
                        	<asp:Label ID="Label16" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                        <td>
                        	<asp:Label ID="Label6" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                    </tr>
                    <tr class="table_data">
                    	<td>
                        	5
                        </td>
                        <td>
                        	1000+1000 (Ruby Distributor)</td>
                        <td>
                        	Alto
                        <td>
                        	<asp:Label ID="Label17" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                        <td>
                        	<asp:Label ID="Label18" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                        <td>
                        	<asp:Label ID="Label7" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                    </tr>
                    <tr class="table_data">
                    	<td>
                        	6
                        </td>
                        <td>
                        	2050+2050 (Star Ruby Distributor)</td>
                        <td>
                        	Swift</td>
                        <td>
                        	<asp:Label ID="Label19" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                        <td>
                        	<asp:Label ID="Label20" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                        <td>
                        	<asp:Label ID="Label8" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                    </tr>
                    <tr class="table_data">
                    	<td>
                        	7
                        </td>
                        <td>
                        	3200+3200 (Diamond Distributor)</td>
                        <td>
                        	 V.Brezza</td>
                        <td>
                        	<asp:Label ID="Label21" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                        <td>
                        	<asp:Label ID="Label22" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                        <td>
                        	<asp:Label ID="Label25" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                    </tr>
                     <tr class="table_data">
                    	<td>
                        	8
                        </td>
                        <td>
                        	10000+10000 (Star Diamond Distributor)</td>
                        <td>
                        	 XUV</td>
                        <td>
                        	<asp:Label ID="Label23" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                        <td>
                        	<asp:Label ID="Label24" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                        <td>
                        	<asp:Label ID="Label26" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                    </tr>
                     <tr class="table_data">
                    	<td>
                        	9
                        </td>
                        <td>
                        	25000+25000 (Toplife King Distributor)</td>
                        <td>
                        	 Fortuner</td>
                        <td>
                        	<asp:Label ID="Label1" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                        <td>
                        	<asp:Label ID="Label2" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                        <td>
                        	<asp:Label ID="Label27" runat="server" CssClass="input-admin" Text="NO"></asp:Label>
                        </td>
                    </tr>
                  </table>
    left=<%=rl %>,right=<%=rr %>
</asp:Content>

