<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="Player.aspx.cs" Inherits="Player" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="1" style="float:left; width: 300px; height: 370px;">
        <p>
            <asp:Label ID="Label1" runat="server" Text="Label" Font-Names="Algerian" Font-Size="XX-Large"></asp:Label>
            <br />
            <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" />
            <br />
        </p>
            <table style="width: 70%; height: 145px;">
                <tr>
                    <td class="auto-style1">Health: </td>
                    <td>
                        <asp:Label ID="healthp1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Attack:</td>
                    <td>
                        <asp:Label ID="attackp1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Defense:</td>
                    <td>
                        <asp:Label ID="defensep1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Experience:</td>
                    <td>
                        <asp:Label ID="experiencep1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Level:</td>
                    <td>
                        <asp:Label ID="levelp1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Gold:</td>
                    <td>
                        <asp:Label ID="goldp1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Points:</td>
                    <td>
                        <asp:Label ID="pointsp1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
    </div>




    <div id="2" style="float:right; width: 300px; height: 370px;">
        <p>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Lista de objetos comprados: "></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <br />
            <br />
            <br />
        </p>

        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <a class ="btn ranking" href="Ranking.aspx" style="border: medium solid #FF0000; background-color: #C0C0C0"> Ranking </a>
            <br />
            <br />
            <a class="btn contact" href="Battle.aspx" style="border: medium solid #FF0000; background-color: #C0C0C0">   FIGTH!!   </a></asp:Panel>
        </p>
    </div>
   
</asp:Content>

