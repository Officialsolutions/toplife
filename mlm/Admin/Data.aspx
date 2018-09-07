<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Data.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0" border="0" class="lgoin_area">
                	 <tr>
                    	<td height="20">
                        </td>
                    </tr>
                    <tr>
                    	<td valign="top" align="center">
                        	<table cellpadding="0" cellspacing="0" border="0" width="300px">
                            	<tr>
                                	<td align="center">
                                        <asp:Button ID="Button1" runat="server" Text="Download" CssClass="lb-buttion" onclick="Button1_Click"/>
                        			    
                        			</td>
                                </tr>
								<tr>
									<td height="20px">
									</td>
								</tr>
                            </table>
                        </td>
                    </tr>
                </table>
</asp:Content>

