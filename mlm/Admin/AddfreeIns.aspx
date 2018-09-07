<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AddfreeIns.aspx.cs" Inherits="Admin_AddfreeIns" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="col-md-12">
          <div class="col-md-3">
              Value
                 <asp:TextBox ID="txtquery" runat="server"></asp:TextBox>
              </div>
           <div class="col-md-3">
               From Date
                  <asp:TextBox ID="txtdate1" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="true" TargetControlID="txtdate1" />
           </div>
          <div class="col-md-3">
              To Date
                <asp:TextBox ID="txtdate2" CssClass="input_box_text_pwd" runat="server" 
                   ></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txtdate2" />
              </div>
           <div class="col-md-3">
               <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn-d" OnClick="btnsubmit_Click" />
               </div>
        </div>

    <div class="col-md-12">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" >
             <Columns>
               <asp:TemplateField HeaderText="S No." >
                <ItemTemplate>
                   
                       <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                
              </asp:TemplateField>
              <asp:TemplateField HeaderText=" Id" >
                <ItemTemplate>
                   
                  <%#Eval("ID") %>
                </ItemTemplate>
                
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Name" >
                <ItemTemplate>
                   
                   <%#Eval("name") %>
                </ItemTemplate>
                
              </asp:TemplateField>
               <asp:TemplateField HeaderText=" Joining Date" >
                <ItemTemplate>
                   
                   <%#Eval("date_entry") %>
                </ItemTemplate>
                
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Sponser Id" >
                <ItemTemplate>
                  
                   <%#Eval("SPON") %>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Sponser Name" >
                <ItemTemplate>
                   
                   <%#Eval("Sponsname") %>
                </ItemTemplate>
                 </asp:TemplateField>
              <asp:TemplateField HeaderText="Joining Date" >
                <ItemTemplate>
                   
                   <%#Eval("spondate") %>
                </ItemTemplate>
                
              </asp:TemplateField>
                 <asp:TemplateField HeaderText="Joining Date" >
                <ItemTemplate>
                   
                   <%#Eval("cnt") %>
                </ItemTemplate>
                
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Action" >
                <ItemTemplate>

<%--                    <asp:LinkButton ID="lnkupdate" CommandName="Update" CommandArgument="<%#Eval("ID") %>" CssClass="gray" runat="server" >Update</asp:LinkButton>--%>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("id") %>' OnClick="LinkButton1_Click" >Update</asp:LinkButton>

                </ItemTemplate>
                
              </asp:TemplateField>
            </Columns>
            <FooterStyle ForeColor="Red" />
        </asp:GridView>
              
    </div>
 
</asp:Content>

