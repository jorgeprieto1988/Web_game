<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="firsthero1.aspx.cs" Inherits="firsthero1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="441px" Width="826px">
        <table style="width:100%; height: 314px;">
            <tr>
                <td rowspan="3" 
                    class="style3">
                    &nbsp;</td>
                <td class="style4" rowspan="3"  style="background-image: url('images/Warrior.png'); background-repeat: no-repeat;" >
                    <br />
                    <br />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button2" runat="server" BackColor="#FFFFCC" 
                        BorderColor="#666666" BorderStyle="Inset" Font-Bold="True" 
                        Font-Names="Castellar" ForeColor="#333333" Height="63px" 
                        Text="Create your hero" Width="208px" PostBackUrl="~/createhero.aspx" OnClick="Button2_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style3
        {
            width: 343px;
        }
        .style4
        {
            width: 245px;
        }
    </style>
</asp:Content>


