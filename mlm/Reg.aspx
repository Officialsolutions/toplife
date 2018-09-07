<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Reg.aspx.cs" Inherits="Default2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                
         <style>
		 	#reg_table{
				 box-shadow: 0 0 10px rgba(0, 0, 0, 0.4);
				 }
				 
				#reg_table .my-table-header {
  background: #364331 none repeat scroll 0 0;
  padding: 17px 0;
  color: #fff;
  font-size: 15px;
}

#reg_table .my-table-td {
  padding: 15px 19px;
}
				 
				 
				 
		 </style>     
         
         <table cellpadding="0" cellpadding="0">
         	 <tr>
          	<td height="20px">
            </td>
          </tr>
         </table>  
                
 <table cellpadding="0" cellspacing="0" border="0" class="my-table" id="reg_table">
     <tr>
        <td colspan="4" class="my-table-header" align="center">
            REGISTRATION FORM   
        </td>
    </tr>
    <tr>
          <td class="my-table-td">Proposer</td>
          <td class="my-table-td">
              <asp:TextBox  CssClass="my-textbox" ID="txtsponsor" runat="server" 
                  AutoPostBack="True" ontextchanged="txtsponsor_TextChanged"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                  ControlToValidate="txtsponsor" ErrorMessage="Enter Proposer" 
                  ValidationGroup="aa">*</asp:RequiredFieldValidator>
            </td>
          <td class="my-table-td">Pin</td>
          <td class="my-table-td">    
              <asp:TextBox CssClass="my-textbox" ID="txtfather0" runat="server" ></asp:TextBox>
          </td>
          </tr>
        <tr>
           <td colspan="4" align="left">
           <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF0066"></asp:Label>  
</td>
        </tr>
          <tr>
          <td class="my-table-td">Sponser</td>
          <td class="my-table-td" colspan="3">
              <asp:TextBox  CssClass="my-textbox" ID="TextBox12" runat="server" 
                  AutoPostBack="True" ontextchanged="txtupleg_TextChanged"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                  ControlToValidate="TextBox12" ErrorMessage="Enter Sponser" 
                  ValidationGroup="aa">*</asp:RequiredFieldValidator>
            </td>
           
          </tr>
          <tr>
          <td class="my-table-td" colspan="4"><asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF0066"></asp:Label>
          </td>
          </tr>
     <tr>
         <td class="my-table-td">Group Leader Id</td>
         <td>
             <asp:TextBox ID="txtgid" OnTextChanged="txtgid_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                  ControlToValidate="txtgid" ErrorMessage="Enter Group Leader" 
                  ValidationGroup="aa">*</asp:RequiredFieldValidator>
         </td>
         <td>
             <asp:Label ID="lblgname" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF0066"></asp:Label>
         </td>
     </tr>
        <tr>
           <td colspan="4" class="my-table-header" align="center">Personal Profile</td>
        </tr>
        <tr>
          <td class="my-table-td">
              Name</td>
          <td class="my-table-td">
              <asp:TextBox CssClass="my-textbox" ID="txtname" runat="server" style=" font-family: myFirstFont"></asp:TextBox>
              &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                  ControlToValidate="txtname" ErrorMessage="Enter Name" ValidationGroup="aa">*</asp:RequiredFieldValidator>
            </td>
          <td class="my-table-td">
                            <asp:DropDownList ID="DropDownList5" runat="server" Width="200px" 
                  CssClass="my-textbox" >
                            <asp:ListItem Value="S/O">S/O</asp:ListItem>
                            <asp:ListItem Value="D/O">D/O</asp:ListItem>
                            <asp:ListItem Value="W/O">W/O</asp:ListItem>
                    </asp:DropDownList>
</td>
          <td class="my-table-td">
              <asp:TextBox CssClass="my-textbox" ID="TextBox2" runat="server" style=" font-family: myFirstFont"></asp:TextBox>
              &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                  ControlToValidate="TextBox2" ErrorMessage="Enter Father Name" ValidationGroup="aa">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
          <td class="my-table-td">Mobile</td>
          <td class="my-table-td">
              <asp:TextBox CssClass="my-textbox" ID="txtmobile" 
                  runat="server" MaxLength="10"></asp:TextBox>
              &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                  ControlToValidate="txtmobile" ErrorMessage="Enter Mobile" ValidationGroup="aa">*</asp:RequiredFieldValidator>
            </td>
          <td class="my-table-td">Mobile 2</td>
          <td class="my-table-td">
              <asp:TextBox CssClass="my-textbox" ID="TextBox13" runat="server"></asp:TextBox>
            </td>
            </tr>
            <tr>
          <td class="my-table-td">E-Mail</td>
          <td class="my-table-td">
              <asp:TextBox CssClass="my-textbox" ID="txtemail" runat="server"></asp:TextBox>
            </td>
          <td class="my-table-td">Pin Code</td>
          <td class="my-table-td">
              <asp:TextBox CssClass="my-textbox" ID="TextBox14" runat="server"></asp:TextBox>
            </td>
            </tr>
        <tr>
          <td class="my-table-td">PAN</td>
          <td class="my-table-td">
              <asp:TextBox CssClass="my-textbox" ID="TextBox1" runat="server"></asp:TextBox>
            </td>
          <td class="my-table-td">ADDRESS</td>
          <td class="my-table-td">
              <asp:TextBox CssClass="my-textbox" ID="TextBox6" runat="server" style=" font-family: myFirstFont"></asp:TextBox>
              &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                  ControlToValidate="TextBox6" ErrorMessage="Enter Address" ValidationGroup="aa">*</asp:RequiredFieldValidator>
            </td>
            </tr>
        <tr>
          <td class="my-table-td">TEHSIL</td>
          <td class="my-table-td">
              <asp:TextBox CssClass="my-textbox" ID="TextBox9" runat="server"></asp:TextBox>
            </td>
          <td class="my-table-td">CITY</td>
          <td class="my-table-td">
              <asp:TextBox CssClass="my-textbox" ID="TextBox10" runat="server"></asp:TextBox>
            </td>
            </tr>
            <tr>
<td class="my-table-td">State</td>
<td class="my-table-td">
    <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList3_SelectedIndexChanged" 
        CssClass="combo" Width="164px">
    </asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Select an State" ValidationGroup="aa" Text="*" ControlToValidate="DropDownList3"></asp:RequiredFieldValidator>
</td>
          <td class="my-table-td">DIST</td>
          <td class="my-table-td">
    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="combo" Width="164px">
    </asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Select an District" ValidationGroup="aa" Text="*" ControlToValidate="DropDownList2"></asp:RequiredFieldValidator>
            </td>
            </tr>
            <tr>
          <td class="my-table-td">DOB</td>
          <td class="my-table-td"><asp:TextBox CssClass="input_box_text_pwd" ID="txtdob" placeholder="MM/DD/YYYY" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                    Enabled="True" TargetControlID="txtdob">
                </cc1:CalendarExtender>
          
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                  ControlToValidate="txtdob" ErrorMessage="Enter DOB" 
                  ValidationGroup="aa">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator 
                ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtdob" 
                ErrorMessage="Only Date" ValidationExpression="^([1-9]|0[1-9]|1[012])[- /.]([1-9]|0[1-9]|[12][0-9]|3[01])[- /.][0-9]{4}$" 
                ValidationGroup="aa" ForeColor=""></asp:RegularExpressionValidator>
          
            </td>
          <td class="my-table-td">Login ID</td>
          <td class="my-table-td"><asp:Label ID="Label5" runat="server"></asp:Label>  
              <asp:TextBox CssClass="my-textbox" ID="txtid" MaxLength="5"
                  runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtid" ErrorMessage="Only Numerics" 
                ValidationExpression="[0-9]*\.?[0-9]*" ValidationGroup="aa" ForeColor="">*</asp:RegularExpressionValidator>
            	<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                  ControlToValidate="txtid" ErrorMessage="Enter ID" 
                  ValidationGroup="aa">*</asp:RequiredFieldValidator>
            </td>
            </tr>
          <tr>
          <td class="my-table-td">Password</td>
          <td class="my-table-td">
              <asp:TextBox CssClass="my-textbox" 
                  ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                  ControlToValidate="txtpassword" ErrorMessage="Password" 
                  ValidationGroup="aa">*</asp:RequiredFieldValidator>
            </td>
          <td class="my-table-td">Re-Password</td>
          <td class="my-table-td">
              <asp:TextBox CssClass="my-textbox" 
                  ID="TextBox11" runat="server" TextMode="Password"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                  ControlToValidate="txtpassword" ErrorMessage="Password" 
                  ValidationGroup="aa">*</asp:RequiredFieldValidator>
            </td>
          </tr>
        <tr>
          <td colspan="4" class="my-table-header" align="center">Bank Profile</td>
        </tr>
        <tr>
          <td class="my-table-td">Account Number</td>
          <td class="my-table-td"><asp:TextBox CssClass="my-textbox" ID="TextBox3" 
                  runat="server"></asp:TextBox>
            </td>
          <td class="my-table-td">Your Bank</td>
          <td class="my-table-td">
              <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" 
                  CssClass="my-textbox" >
<asp:ListItem Value=""></asp:ListItem>
	<asp:ListItem Value="Amcore Financial Inc.">Amcore Financial Inc.</asp:ListItem>
	<asp:ListItem Value="ALLAHABAD BANK">ALLAHABAD BANK</asp:ListItem>
	<asp:ListItem Value="ANDHRA BANK">ANDHRA BANK</asp:ListItem>
	<asp:ListItem Value="AXIS BANK LTD">AXIS BANK LTD</asp:ListItem>
	<asp:ListItem Value="BANK OF AMERICA">BANK OF AMERICA</asp:ListItem>
	<asp:ListItem Value="BANK OF BAHRAIN AND KUWAIT">BANK OF BAHRAIN AND KUWAIT</asp:ListItem>
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
	<asp:ListItem Value="CREDIT AGRICOLE CORPORATE AND INVESTMENT BANK">CREDIT AGRICOLE CORPORATE AND INVESTMENT BANK</asp:ListItem>
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
	<asp:ListItem Value="MIZUHO CORPORATE BANK LTD">MIZUHO CORPORATE BANK LTD</asp:ListItem>
	<asp:ListItem Value="OMAN INTERNATIONAL BANK SAOG">OMAN INTERNATIONAL BANK SAOG</asp:ListItem>
	<asp:ListItem Value="ORIENTAL BANK OF COMMERCE">ORIENTAL BANK OF COMMERCE</asp:ListItem>
	<asp:ListItem Value="PUNJAB AND SIND BANK">PUNJAB AND SIND BANK</asp:ListItem>
	<asp:ListItem Value="PUNJAB NATIONAL BANK">PUNJAB NATIONAL BANK</asp:ListItem>
	<asp:ListItem Value="RATNAKAR BANK LIMITED">RATNAKAR BANK LIMITED</asp:ListItem>
	<asp:ListItem Value="ROYAL BANK OF SCOTLAND N.V.">ROYAL BANK OF SCOTLAND N.V.</asp:ListItem>
	<asp:ListItem Value="SHINHAN BANK">SHINHAN BANK</asp:ListItem>
	<asp:ListItem Value="SOCIETE GENERALE">SOCIETE GENERALE</asp:ListItem>
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
          <td class="my-table-td">Branch Address</td>
          <td class="my-table-td"><asp:TextBox CssClass="my-textbox" ID="TextBox4" 
                  runat="server"></asp:TextBox>
            </td>
          <td class="my-table-td">Branch IFSC</td>
          <td class="my-table-td"><asp:TextBox CssClass="my-textbox" ID="TextBox5" 
                  runat="server"></asp:TextBox>
            </td>
          </tr>
          <tr>
          <td colspan="4" class="my-table-header" align="center">Nominee Detail</td>
        </tr>
        <tr>
          <td class="my-table-td">Nominee Name</td>
          <td class="my-table-td"><asp:TextBox CssClass="my-textbox" ID="TextBox7" 
                  runat="server" style=" font-family: myFirstFont"></asp:TextBox>
              &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                  ControlToValidate="TextBox7" ErrorMessage="Enter Nominee" ValidationGroup="aa">*</asp:RequiredFieldValidator>
            </td>
          <td class="my-table-td">Relation</td>
          <td class="my-table-td">
              <asp:DropDownList ID="DropDownList4" runat="server" Width="200px" 
                  CssClass="my-textbox" >
	                    <asp:ListItem Value="WIFE">WIFE</asp:ListItem>
	                    <asp:ListItem Value="HUSBAND">HUSBAND</asp:ListItem>
	                    <asp:ListItem Value="BROTHER">BROTHER</asp:ListItem>
	                    <asp:ListItem Value="SISTER">SISTER</asp:ListItem>
	                    <asp:ListItem Value="FATHER">FATHER</asp:ListItem>
	                    <asp:ListItem Value="MOTHER">MOTHER</asp:ListItem>
	                    <asp:ListItem Value="SON">SON</asp:ListItem>
	                    <asp:ListItem Value="DAUGHTER">DAUGHTER</asp:ListItem>
                    </asp:DropDownList>
            </td>
          </tr>
          <tr>
          	<td colspan="4" align="center">
            	 <asp:Button CssClass="lb-buttion" ID="Button1" runat="server" Text="SUBMIT" 
                  onclick="Button1_Click" ValidationGroup="aa" Width="250px" />
            </td>
          </tr>
          <tr>
          	<td align="center" colspan="4" class="my-table-td-center">
            	  <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" 
                  Font-Size="Large" ForeColor="#FF0066"></asp:Label>  
            </td>
          </tr>
          <tr>
          	<td height="20px">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="aa" HeaderText="Following Error Occurs.." ShowMessageBox="true" ShowSummary="false" />
            </td>
          </tr>
      </table>
</asp:Content>

