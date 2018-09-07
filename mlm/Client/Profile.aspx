<%@ Page Language="C#" MasterPageFile="~/Client/MasterPage.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Client_Default2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">


        function printTbl() {
            var TableToPrint = document.getElementById('cliebttable');
            newWin = window.open("");
            newWin.document.write(TableToPrint.outerHTML);
            newWin.print();
            newWin.close();
        }
    </script>
    <style>
    @font-face
    {
        font-family:myfont;
        src:url(chatrik.ttf);   
    }
    </style>


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <table cellpadding="0" cellspacing="0" border="0" class="client_table" width="900px" id="clienttable">
        <tr class="form-group">
            <td class="my-table-td">Proposer ID</td>
            <td class="my-table-td">
                <asp:TextBox CssClass="my-textbox form-control" ID="TextBox11" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td class="my-table-td">Proposer Name</td>
            <td class="my-table-td">
                <asp:TextBox CssClass="my-textbox t-color form-control" ID="TextBox12" runat="server" Enabled="false"></asp:TextBox>
                <asp:TextBox ID="txtproname" runat="server" Enabled="false" style="font-family:myfont" class="my-textbox t-color form-control"></asp:TextBox>
            </td>
        </tr>
        <tr class="form-group">
            <td class="my-table-td">Sponser ID</td>
            <td class="my-table-td">
                <asp:TextBox CssClass="my-textbox form-control" ID="TextBox13" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td class="my-table-td">Sponser Name</td>
            <td class="my-table-td">
                <asp:TextBox CssClass="my-textbox form-control" ID="TextBox14" runat="server" Enabled="false"></asp:TextBox>
                <asp:TextBox CssClass="my-textbox form-control" ID="txtpspon" style="font-family:myfont" runat="server" Enabled="false"></asp:TextBox>
                
            </td>
        </tr>
        <tr class="form-group">
            <td colspan="4" style="background: #222; color: #fff;" class="my-table-header" align="center">Personal Profile</td>
        </tr>
        <tr class="form-group">
            <td class="my-table-td">ID</td>
            <td class="my-table-td">
                <asp:TextBox CssClass="my-textbox t-color form-control" ID="TextBox15" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td class="my-table-td">Date of Joining</td>
            <td class="my-table-td">
                <asp:TextBox CssClass="my-textbox form-control" ID="TextBox16" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr class="form-group">
            <td class="my-table-td">Name</td>
            <td class="my-table-td">
                <asp:TextBox CssClass="my-textbox t-color form-control" ID="txtname" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtpname" style="font-family:myfont" CssClass="my-textbox t-color form-control" runat="server"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtname" ErrorMessage="Enter Name" ValidationGroup="aa">*</asp:RequiredFieldValidator>
            </td>
            <td class="my-table-td">
                <asp:DropDownList ID="DropDownList5" runat="server" Width="200px"
                    CssClass="my-textbox">
                    <asp:ListItem Value="S/O">S/O</asp:ListItem>
                    <asp:ListItem Value="D/O">D/O</asp:ListItem>
                    <asp:ListItem Value="W/O">W/O</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="my-table-td">
                <asp:TextBox CssClass="my-textbox t-color form-control" ID="TextBox2" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtppf" style="font-family:myfont" CssClass="my-textbox t-color form-control" runat="server"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="TextBox2" ErrorMessage="Enter Father Name" ValidationGroup="aa">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="form-group">
            <td class="my-table-td">Mobile</td>
            <td class="my-table-td">
                <asp:TextBox CssClass="my-textbox form-control" ID="txtmobile"
                    runat="server" MaxLength="10"></asp:TextBox>
            </td>
            <td class="my-table-td">Mobile2</td>
            <td class="my-table-td">
                <asp:TextBox CssClass="my-textbox form-control" ID="TextBox8"
                    runat="server" MaxLength="10"></asp:TextBox>
            </td>
        </tr>
        <tr class="form-group">
            <td class="my-table-td">E-Mail</td>
            <td class="my-table-td">
                <asp:TextBox CssClass="my-textbox form-control" ID="txtemail" runat="server"></asp:TextBox>
            </td>
            <td class="my-table-td">PAN</td>
            <td class="my-table-td">
                <asp:TextBox CssClass="my-textbox form-control" ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="form-group">
            <td class="my-table-td">ADDRESS</td>
            <td class="my-table-td">
                <asp:TextBox CssClass="my-textbox form-control" ID="TextBox6" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtpadd" runat="server" CssClass="my-textbox form-control" style="font-family:myfont"></asp:TextBox>
            </td>
            <td class="my-table-td">TEHSIL</td>
            <td class="my-table-td">
                <asp:TextBox CssClass="my-textbox form-control" ID="TextBox9" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="form-group">
            <td class="my-table-td">CITY</td>
            <td class="my-table-td">
                <asp:TextBox CssClass="my-textbox form-control" ID="TextBox10" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtpcity" runat="server" style="font-family:myfont" CssClass="my-textbox t-color form-control"></asp:TextBox>
            </td>
            <td class="my-table-td">State</td>
            <td class="my-table-td">
                <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"
                    CssClass="combo form-control" Width="164px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Select an State" ValidationGroup="aa" Text="*" ControlToValidate="DropDownList3"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="form-group">
            <td class="my-table-td">DIST</td>
            <td class="my-table-td">
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="combo form-control" Width="164px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Select an District" ValidationGroup="aa" Text="*" ControlToValidate="DropDownList2"></asp:RequiredFieldValidator>
            </td>
            <td class="my-table-td">DOB</td>
            <td class="my-table-td">
                <asp:TextBox CssClass="input_box_text_pwd form-control" ID="txtdob" placeholder="MM/DD/YYYY" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                    Enabled="True" TargetControlID="txtdob"></cc1:CalendarExtender>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                    ControlToValidate="txtdob" ErrorMessage="Enter DOB"
                    ValidationGroup="aa">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtdob"
                    ErrorMessage="Only Date" ValidationExpression="^([1-9]|0[1-9]|1[012])[- /.]([1-9]|0[1-9]|[12][0-9]|3[01])[- /.][0-9]{4}$"
                    ValidationGroup="aa" ForeColor=""></asp:RegularExpressionValidator>

            </td>
            <td class="my-table-td"></td>
            <td class="my-table-td"></td>
        </tr>
        <tr class="form-group">
            <td colspan="4" style="background: #222; color: #fff" class="my-table-header" align="center">Account information</td>
        </tr>
        <tr class="form-group">
            <td class="my-table-td">Account Number</td>
            <td class="my-table-td">
                <asp:TextBox CssClass="my-textbox form-control" ID="TextBox3"
                    runat="server"></asp:TextBox>
            </td>
            <td class="my-table-td">Your Bank</td>
            <td class="my-table-td">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px"
                    CssClass="my-textbox form-control">
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
        <tr class="form-group">
            <td class="my-table-td">Branch Address</td>
            <td class="my-table-td">
                <asp:TextBox CssClass="my-textbox form-control" ID="TextBox4"
                    runat="server"></asp:TextBox>
            </td>
            <td class="my-table-td">Branch IFSC</td>
            <td class="my-table-td">
                <asp:TextBox CssClass="my-textbox form-control" ID="TextBox5"
                    runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="form-group">
            <td colspan="4" class="my-table-header" align="center">Nominee Detail</td>
        </tr>
        <tr class="form-group">
            <td class="my-table-td">Nominee Name</td>
            <td class="my-table-td">
                <asp:TextBox CssClass="my-textbox form-control" ID="TextBox7"
                    runat="server"></asp:TextBox>
                <asp:TextBox CssClass="my-textbox form-control" ID="txtpnomi" style="font-family:myfont"
                    runat="server"></asp:TextBox>
            </td>
            <td class="my-table-td">Relation</td>
            <td class="my-table-td">
                <asp:DropDownList ID="DropDownList4" runat="server" Width="200px"
                    CssClass="my-textbox">
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
        <tr class="form-group">

            <td align="center" colspan="4">
                <asp:Button CssClass="lb-buttion btn-theme-dark" ID="Button1" runat="server" Text="SUBMIT"
                    OnClick="Button1_Click" ValidationGroup="aa" />
            </td>

        </tr>
        <tr class="form-group">
            <td colspan="4" align="center">
                <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True"
                    Font-Size="Large" ForeColor="#FF0066"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="aa" HeaderText="Following Error Occurs.." ShowMessageBox="true" ShowSummary="false" />
            </td>
        </tr>
    </table>
    <button onclick="printTbl()">Print this page</button>
</asp:Content>

