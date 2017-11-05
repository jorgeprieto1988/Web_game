<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel2" runat="server" Height="357px">
     <div style="height: 355px">
     <div id="registerleft"></div>
     <div id="registerright">
         <table style="width: 100%; height: 283px; margin-left: 0px;" align="center">
             <tr>
                 <td colspan="2" valign="middle" align="center">
                    GET READY FOR THE BATTLE!
                     &nbsp;</td>
                 <td align="center" valign="middle">
                     &nbsp;</td>
             </tr>
             <tr>
                 <td align="right" class="style4">
                     <asp:Label ID="Label1" runat="server" Text="Email:"></asp:Label>
                 </td>
                 <td align="left" class="style5">
                     <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                 </td>
                 <td align="left" class="style3">
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                         ControlToValidate="TextBox5" ErrorMessage="*Email is required" 
                         ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                         ErrorMessage="*Valid mail is required" ForeColor="Red" 
                         ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                         ControlToValidate="TextBox5"></asp:RegularExpressionValidator>
                 </td>
             </tr>
             <tr>
                 <td align="right" class="style4">
                     <asp:Label ID="Label2" runat="server" Text="Nickname:"></asp:Label>
                 </td>
                 <td align="left" class="style5">
                     <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                 </td>
                 <td align="left" class="style3">
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                         ControlToValidate="TextBox2" ErrorMessage="*Nickname is required" 
                         ForeColor="Red"></asp:RequiredFieldValidator>
                     <br />
                 </td>
             </tr>
                 <tr>
                 <td align="right" class="style4">
                     <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
                     </td>
                 <td align="left" class="style5">
                     <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                     </td>
                     <td align="left" class="style3">
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                             ControlToValidate="TextBox3" ErrorMessage="*Password is required" 
                             ForeColor="Red"></asp:RequiredFieldValidator>
                          
                      <br />
                     </td>
             </tr>
                 <tr>
                 <td align="right" class="style4">
                     <asp:Label ID="Label4" runat="server" Text="Confirm Password:"></asp:Label>
                     </td>
                 <td align="left" class="style5">
                     <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
                     </td>
                     <td align="left" class="style3">
                         <asp:CompareValidator ID="CompareValidator1" runat="server" 
                             ControlToValidate="TextBox3" ControlToCompare="TextBox4"  
                             ErrorMessage="*Password doesn't match" ForeColor="Red"></asp:CompareValidator>
                         <br />
                     </td>
             </tr>
             <tr>
                 <td align="center" class="style2" colspan="3">
                     <asp:Label ID="Label5" runat="server" Text="Label" Visible="false"></asp:Label><br />
                     <asp:Button ID="Button1" runat="server" BorderColor="#999999" 
                         BorderStyle="Solid" Text="Enviar" OnClick="Button1_Click" />
                 </td>
             </tr>
         </table>
         </div>

     </div>
 
    </asp:Panel>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style2
        {
        }
        .style3
        {
            width: 203px;
        }
        .style4
        {
            width: 191px;
        }
        .style5
        {
            width: 155px;
        }
        </style>
</asp:Content>


