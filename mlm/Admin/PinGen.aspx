<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="PinGen.aspx.cs" Inherits="Admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table class="my-table" width="100%" id="pin-gen">
 <tr>
        <td height="20px">
        </td>
</tr>
    <tr>
            <td colspan="7" class="my-table-header" align="center" style="font-size:20px">
            Pin Generate
            </td>
     </tr>
     <tr>
        <td height="20px">
        </td>
</tr>
        <tr>
            <td class="my-table-td">
                Pin Type
            </td>
            <td class="my-table-td">
                <asp:DropDownList ID="DropDownList1" CssClass="my-textbox" runat="server">
                    <asp:ListItem Selected="True" Value="0">0</asp:ListItem>
                </asp:DropDownList>
            </td>
			<td class="my-table-td">
                <span>Pins</span></td>
            <td class="my-table-td">
                <asp:TextBox ID="TextBox2" CssClass="my-textbox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="TextBox2" ErrorMessage="Please Enter Password" 
                ValidationGroup="aa">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="TextBox2" ErrorMessage="Please Enter only Numerics" 
                ValidationExpression="^\d+$" ValidationGroup="aa">*</asp:RegularExpressionValidator>
            </td>
			<td colspan="2" class="my-table-td-center">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
           <td class="my-table-td-center" width="300px">
                    <asp:Button ID="Button1" runat="server" Text="Generate" CssClass="lb-buttion" onclick="Button1_Click" 
                ValidationGroup="aa" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                ShowMessageBox="True" ShowSummary="False" ValidationGroup="aa" />
            </td>
        </tr>
    </table>
                <asp:GridView ID="GridView1" runat="server" align="center" Caption='<table width="100%"><tr><td align="center" style="font-size:20px">Un-Used Pins</td></tr></table>' CssClass="my-grid"  BorderColor="#fc6701" 
                                            CaptionAlign="Top" HorizontalAlign="Center" Width="100%" DataKeyNames="PIN" 
                                            EnableModelValidation="True" onrowupdating="GridView1_RowUpdating" HeaderStyle-CssClass="gridhead">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update">Click</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <SelectedRowStyle
                                                BorderStyle="Dotted" BorderWidth="1px" />
                                        </asp:GridView>
                                        </asp:Content>

