<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="Battle.aspx.cs" Inherits="Battle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #div3 {
            width: 238px;
        }
        .auto-style1 {
            width: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="div1" style="float: left; height: 200px; width: 350px">
        <br />
        <div id="div3" style="float: left; height: 130px; width: 130px">
            <asp:Label ID="Label1" runat="server" Text="Jugador1" Font-Size="X-Large"></asp:Label>
            <br />
            <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" />
        </div>
        <div id="div4" style="float: right; height: 164px; width: 200px">
            <table style="width: 98%; height: 145px;">
                <tr>
                    <td class="auto-style1">health</td>
                    <td>
                        <asp:Label ID="healthp1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">attack</td>
                    <td>
                        <asp:Label ID="attackp1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">defense</td>
                    <td>
                        <asp:Label ID="defensep1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">experience</td>
                    <td>
                        <asp:Label ID="experiencep1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">level</td>
                    <td>
                        <asp:Label ID="levelp1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">gold</td>
                    <td>
                        <asp:Label ID="goldp1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">points</td>
                    <td>
                        <asp:Label ID="pointsp1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
       
    <div id="div2" style=" float: right; height: 200px; width: 350px">
        <br />
        <div id="div5" style="float: right; height: 130px; width: 130px">
            <asp:Label ID="Label2" runat="server" Text="Jugador2" style="float: right" Font-Size="X-Large"></asp:Label>
            <br />
            <asp:Image ID="Image2" runat="server" Height="100px" Width="100px" style="float: right" />
        </div>
        <div id="div6" style="float: right; height: 161px; width: 200px">
            <table style="width: 98%; height: 145px;">
                <tr>
                    <td class="auto-style1">health</td>
                    <td>
                        <asp:Label ID="healthp2" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">attack</td>
                    <td>
                        <asp:Label ID="attackp2" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">defense</td>
                    <td>
                        <asp:Label ID="defensep2" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">experience</td>
                    <td>
                        <asp:Label ID="experiencep2" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">level</td>
                    <td>
                        <asp:Label ID="levelp2" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">gold</td>
                    <td>
                        <asp:Label ID="goldp2" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">points</td>
                    <td>
                        <asp:Label ID="pointsp2" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <div id="div7" style="height: 200px; width: 750px;">
        <div id="div8" style="float:left; height: 150px; width: 450px">
             <asp:Image ID="Image3" runat="server" src="images/and_the_winner_is.png" Height="139px" Width="495px" />
        </div>
        <div id="div9" style="float:right; height: 170px; width: 250px">
            <div id="div10" style="float:left; height: 100px; width: 100px">
                <asp:Image ID="Image4" runat="server" Height="100px" Width="100px"/>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div id="div11" style="height: 50px; width: 100px">
                <asp:Label ID="Label3" runat="server" Text="GANADOR" Font-Italic="True" Font-Size="XX-Large"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

