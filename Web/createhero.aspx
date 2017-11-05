<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="createhero.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 150px;
            height: 117px;
        }
        .style9
        {
            width: 133px;
        }
        .style10
        {
            width: 128px;
        }
        .style11
        {
            width: 127px;
        }
        .style18
        {
            width: 140px;
        }
        .style21
        {
            width: 724px;
        }
        .style22
        {
            width: 133px;
            height: 121px;
        }
        .auto-style1 {
            height: 59px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="491px">
        <table cellspacing="10px" 
            style="width: 100%; height: 471px; margin-left: 100px;" align="center">
            <tr>
                <td class="style22" style="border: medium ridge #999999">
                    <img alt="elf" class="style1" src="images/elf.png" />
                </td>
                <td class="style22" style="border: medium ridge #999999">
                    <img alt="human" class="style1" src="images/human.jpg" />
                </td>
                <td class="style22" style="border: medium ridge #999999">
                    <img alt="orc" class="style1" src="images/orc.jpg" />
                </td>
                <td class="style22" style="border: medium ridge #999999">
                    <img alt="dwarf" class="style1" src="images/dwarf.jpg" />
                </td>
                <td class="style22" style="border: medium ridge #999999">
                    <img alt="elf" class="style1" src="images/elf.jpg" />
                </td>
            </tr>
            <tr>
                <td class="style9" 
                    
                    style="border: medium ridge #999999; color: #000000; font-family: Algerian;" 
                    align="center" bgcolor="#666666">
                    Dark elf<br /> Stats:<br /> ATK&nbsp;&nbsp;&nbsp; 30<br /> DEF&nbsp;&nbsp;&nbsp; 1<br /> HP&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 29<br />
                    <asp:RadioButton ID="DarkElf" runat="server" GroupName="Selectheroe" 
                        TextAlign="Left" />
                </td>
                <td class="style10" 
                    
                    style="border: medium ridge #999999; color: #000000; font-family: Algerian;" 
                    align="center" bgcolor="#666666">
                    Human<br /> Stats:<br /> ATK&nbsp;&nbsp;&nbsp; 20<br /> DEF&nbsp;&nbsp;&nbsp; 10<br /> HP&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 30<br /> <asp:RadioButton ID="Human" runat="server" 
                        GroupName="Selectheroe" />
                </td>
                <td class="style11" 
                    
                    style="border: medium ridge #999999; color: #000000; font-family: Algerian;" 
                    align="center" bgcolor="#666666">
                    Orc<br /> Stats:<br /> ATK&nbsp;&nbsp;&nbsp; 22<br />
                    DEF&nbsp;&nbsp;&nbsp; 8<br /> HP&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 30<br />
                    <asp:RadioButton ID="Orc" runat="server" GroupName="Selectheroe" />
                </td>
                <td class="style18" 
                    
                    style="border: medium ridge #999999; color: #000000; font-family: Algerian;" 
                    align="center" bgcolor="#666666">
                    Dwarf<br /> Stats:<br /> ATK&nbsp;&nbsp;&nbsp; 15<br /> DEF&nbsp;&nbsp;&nbsp; 15<br /> HP&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 30<br />
                    <asp:RadioButton ID="Dwarf" runat="server" GroupName="Selectheroe" />
                </td>
                <td class="style21" 
                    
                    style="border: medium ridge #999999; color: #000000; font-family: Algerian;" 
                    align="center" bgcolor="#666666">
                    Elf<br /> Stats:<br /> ATK&nbsp;&nbsp;&nbsp; 30<br /> DEF&nbsp;&nbsp;&nbsp; 5<br /> HP&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 25<br />
                    <asp:RadioButton ID="Elf" runat="server" GroupName="Selectheroe" />
                </td>
            </tr>
            <tr>
                <td colspan="5" align="center" class="auto-style1">
                    &nbsp;<asp:Label ID="Label1" runat="server" Font-Names="Algerian" ForeColor="Black" 
                        Text="Name your hero:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Font-Names="Algerian" ForeColor="Black" Visible="false"
                        Text="Select a Race"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator style="background-color:#000000;" ID="RequiredFieldValidator2" runat="server" 
                         ControlToValidate="TextBox1" ErrorMessage="*Nickname is required" 
                         ForeColor="Red">
            </asp:RequiredFieldValidator>
                    <br />
                </td>
                
            </tr>
            <tr>
                <td align="center" colspan="5">
                    <asp:Button ID="Button1" runat="server" Text="Fight" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

