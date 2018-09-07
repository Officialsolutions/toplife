<%@ Page Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Profile1.aspx.cs" Inherits="Client_Default2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager>
  
  
   <table cellpadding="0" cellspacing="0" border="0" class="client_table" width="500px" id="clienttable">
                	<tr>
                    	<td class="commont_title" colspan="2">
                        	Bank Detials
                        </td>
                    </tr>
                    <tr>
                    	<td>
                        	Your Bank
                        </td>
                        <td>
                        	<asp:DropDownList ID="DropDownList1" runat="server" Width="200px" >
            <asp:ListItem Value=""></asp:ListItem>
            <asp:ListItem Value="Amcore Financial Inc.">Amcore Financial Inc.</asp:ListItem>
            <asp:ListItem Value="ALLAHABAD BANK">ALLAHABAD BANK</asp:ListItem>
            <asp:ListItem Value="ANDHRA BANK">ANDHRA BANK</asp:ListItem>
            <asp:ListItem Value="AXIS BANK LTD&lt;">AXIS BANK LTD</asp:ListItem>
            <asp:ListItem Value="BANK OF AMERICA">BANK OF AMERICA</asp:ListItem>
            <asp:ListItem Value="BANK OF BAHRAIN AND KUWAIT&lt;">BANK OF BAHRAIN AND KUWAIT</asp:ListItem>
            <asp:ListItem Value="BANK OF BARODA">BANK OF BARODA</asp:ListItem>
            <asp:ListItem Value="BANK OF CEYLON">BANK OF CEYLON</asp:ListItem>
            <asp:ListItem Value="BANK OF INDIA">BANK OF INDIA</asp:ListItem>
            <asp:ListItem Value="BANK OF MAHARASHTRA">BANK OF MAHARASHTRA</asp:ListItem>
            <asp:ListItem Value="BANK OF NOVA SCOTIA">BANK OF NOVA SCOTIA</asp:ListItem>
            <asp:ListItem Value="BANK OF RAJASTHAN">BANK OF RAJASTHAN</asp:ListItem>
            <asp:ListItem Value="BARCLAYS BANK PLC">BARCLAYS BANK PLC</asp:ListItem>
            <asp:ListItem Value="BK OF TOKYO MITSUBISHI UFJ LTD">BK OF TOKYO MITSUBISHI UFJ LTD</asp:ListItem>
            <asp:ListItem Value="BNP PARIBAS">BNP PARIBAS</asp:ListItem>
            <asp:ListItem Value="CANARA BANK">CANARA BANK</asp:ListItem>
            <asp:ListItem Value="CATHOLIC SYRIAN BANK LTD">CATHOLIC SYRIAN BANK LTD</asp:ListItem>
            <asp:ListItem Value="CENTRAL BANK OF INDIA">CENTRAL BANK OF INDIA</asp:ListItem>
            <asp:ListItem Value="CHINATRUST COMMERCIAL BANK">CHINATRUST COMMERCIAL BANK</asp:ListItem>
            <asp:ListItem Value="CITI BANK">CITI BANK</asp:ListItem>
            <asp:ListItem Value="CITY UNION BANK">CITY UNION BANK</asp:ListItem>
            <asp:ListItem Value="CORPORATION BANK">CORPORATION BANK</asp:ListItem>
            <asp:ListItem Value="CREDIT AGRICOLE CORPORATE AND INVESTMENT BANK">CREDIT AGRICOLE 
              CORPORATE AND INVESTMENT BANK</asp:ListItem>
            <asp:ListItem Value="DBS BANK">DBS BANK</asp:ListItem>
            <asp:ListItem Value="DENA BANK">DENA BANK</asp:ListItem>
            <asp:ListItem Value="DEUTSCHE BANK LTD">DEUTSCHE BANK LTD</asp:ListItem>
            <asp:ListItem Value="DEVELOPMENT CREDIT BANK">DEVELOPMENT CREDIT BANK</asp:ListItem>
            <asp:ListItem Value="DHANALAKSHMI BANK LTD">DHANALAKSHMI BANK LTD</asp:ListItem>
            <asp:ListItem Value="FEDERAL BANK LTD.">FEDERAL BANK LTD.</asp:ListItem>
            <asp:ListItem Value="HDFC BANK LTD.">HDFC BANK LTD.</asp:ListItem>
            <asp:ListItem Value="HONGKONG SHANGHAI BKG CORPN">HONGKONG SHANGHAI BKG CORPN</asp:ListItem>
            <asp:ListItem Value="ICICI BANK LTD">ICICI BANK LTD</asp:ListItem>
            <asp:ListItem Value="IDBI LTD.">IDBI LTD.</asp:ListItem>
            <asp:ListItem Value="INDIAN BANK">INDIAN BANK</asp:ListItem>
            <asp:ListItem Value="INDIAN OVERSEAS BANK">INDIAN OVERSEAS BANK</asp:ListItem>
            <asp:ListItem Value="INDUSIND BANK LTD.">INDUSIND BANK LTD.</asp:ListItem>
            <asp:ListItem Value="ING VYSYA BANK LTD.">ING VYSYA BANK LTD.</asp:ListItem>
            <asp:ListItem Value="JAMMU AND KASHMIR BANK">JAMMU AND KASHMIR BANK</asp:ListItem>
            <asp:ListItem Value="JPMORGAN CHASE BANK, N A">JPMORGAN CHASE BANK, N A</asp:ListItem>
            <asp:ListItem Value="KARNATAKA BANK LTD">KARNATAKA BANK LTD</asp:ListItem>
            <asp:ListItem Value="KARUR VYSYA BANK LTD">KARUR VYSYA BANK LTD</asp:ListItem>
            <asp:ListItem Value="KOTAK MAHINDRA BANK LTD">KOTAK MAHINDRA BANK LTD</asp:ListItem>
            <asp:ListItem Value="KRUNG THAI BANK PCL">KRUNG THAI BANK PCL</asp:ListItem>
            <asp:ListItem Value="MASHREQ BANK">MASHREQ BANK</asp:ListItem>
            <asp:ListItem Value="MIZUHO CORPORATE BANK LTD&lt;">MIZUHO CORPORATE BANK LTD</asp:ListItem>
            <asp:ListItem Value="OMAN INTERNATIONAL BANK SAOG">OMAN INTERNATIONAL BANK SAOG</asp:ListItem>
            <asp:ListItem Value="ORIENTAL BANK OF COMMERCE">ORIENTAL BANK OF COMMERCE</asp:ListItem>
            <asp:ListItem Value="PUNJAB AND SIND BANK">PUNJAB AND SIND BANK</asp:ListItem>
            <asp:ListItem Value="PUNJAB NATIONAL BANK">PUNJAB NATIONAL BANK</asp:ListItem>
            <asp:ListItem Value="RATNAKAR BANK LIMITED">RATNAKAR BANK LIMITED</asp:ListItem>
            <asp:ListItem Value="ROYAL BANK OF SCOTLAND N.V.">ROYAL BANK OF SCOTLAND N.V.</asp:ListItem>
            <asp:ListItem Value="SHINHAN BANK">SHINHAN BANK</asp:ListItem>
            <asp:ListItem Value="SOCIETE GENERALE&lt;">SOCIETE GENERALE</asp:ListItem>
            <asp:ListItem Value="SOUTH INDIAN BANK">SOUTH INDIAN BANK</asp:ListItem>
            <asp:ListItem Value="ST.BANK OF BIKANER AND JAIPUR">ST.BANK OF BIKANER AND JAIPUR</asp:ListItem>
            <asp:ListItem Value="STANDARD CHARTERED BANK LTD.">STANDARD CHARTERED BANK LTD.</asp:ListItem>
            <asp:ListItem Value="STATE BANK OF HYDERABAD">STATE BANK OF HYDERABAD</asp:ListItem>
            <asp:ListItem Value="STATE BANK OF INDIA">STATE BANK OF INDIA</asp:ListItem>
            <asp:ListItem Value="STATE BANK OF MAURITIUS">STATE BANK OF MAURITIUS</asp:ListItem>
            <asp:ListItem Value="STATE BANK OF MYSORE">STATE BANK OF MYSORE</asp:ListItem>
            <asp:ListItem Value="STATE BANK OF PATIALA">STATE BANK OF PATIALA</asp:ListItem>
            <asp:ListItem Value="STATE BANK OF TRAVANCORE">STATE BANK OF TRAVANCORE</asp:ListItem>
            <asp:ListItem Value="SYNDICATE BANK">SYNDICATE BANK</asp:ListItem>
            <asp:ListItem Value="TAMILNAD MERCANTILE BANK LTD">TAMILNAD MERCANTILE BANK LTD</asp:ListItem>
            <asp:ListItem Value="THE LAXMI VILAS BANK LTD">THE LAXMI VILAS BANK LTD</asp:ListItem>
            <asp:ListItem Value="UCO BANK">UCO BANK</asp:ListItem>
            <asp:ListItem Value="UNION BANK OF INDIA">UNION BANK OF INDIA</asp:ListItem>
            <asp:ListItem Value="UNITED BANK OF INDIA">UNITED BANK OF INDIA</asp:ListItem>
            <asp:ListItem Value="VIJAYA BANK">VIJAYA BANK</asp:ListItem>
            <asp:ListItem Value="YES BANK LTD">YES BANK LTD</asp:ListItem>
          </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                    	<td>
                        	Account Number:
                        </td>
                        <td>
                        	<asp:TextBox CssClass="textbox" ID="txtemail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                    	<td>
                        	Branch Address
                        </td>
                        <td>
                        	<asp:TextBox CssClass="textbox" ID="TextBox1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                    	<td>
                        	Branch IFSC Code
                        </td>
                        <td>
                        	<asp:TextBox CssClass="textbox" ID="TextBox3" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                    	<td>
                        </td>
                    	<td align="left">
                         <asp:Button CssClass="lb-buttion" ID="Button1" runat="server" Text="Update" 
                  onclick="Button1_Click" ValidationGroup="aa" />
                        </td>
                        
                    </tr>
                     <tr>
                    	<td colspan="2" align="center">
                        	   <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" 
                  Font-Size="Large" ForeColor="#FF0066"></asp:Label>
                        </td>
                    </tr>
                </table>
  
  
  
</asp:Content>
