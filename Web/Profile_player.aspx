<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="Profile_player.aspx.cs" Inherits="Profile_player" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Algerian" Font-Size="XX-Large" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Email: " Font-Bold="True"></asp:Label>
        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Gems: " Font-Bold="True"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Banned times: " Font-Bold="True"></asp:Label>
        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        <br />
    
    <div id="1" style="float:left; width: 400px; height: 200px;">
        <div id="2" style="float:left; width: 170px; height: 70px;">
            <br />
            <asp:Button ID="Button1" runat="server" BackColor="#FFFFCC" 
                            BorderColor="#666666" BorderStyle="Inset" Font-Bold="True" 
                            Font-Names="Castellar" ForeColor="#333333" Height="50px" 
                            Text="Your hero" Width="150px" PostBackUrl="~/Player.aspx" OnClick="Button1_Click" />
        </div>

        <div id="3" style="float:right; width: 170px; height: 70px;">
            <br />
            <asp:Button ID="Button2" runat="server" BackColor="#FFFFCC" 
                            BorderColor="#666666" BorderStyle="Inset" Font-Bold="True" 
                            Font-Names="Castellar" ForeColor="#333333" Height="50px" 
                            Text="Shop" Width="150px" PostBackUrl="~/Shop.aspx" OnClick="Button2_Click" />
        </div>

        <div id="4" style="float:left; width: 170px; height: 70px;">
            <br />
            <asp:Button ID="Button3" runat="server" BackColor="#FFFFCC" 
                            BorderColor="#666666" BorderStyle="Inset" Font-Bold="True" 
                            Font-Names="Castellar" ForeColor="#333333" Height="50px" 
                            Text="Delete hero" Width="150px" PostBackUrl="~/Profile_player.aspx" OnClick="Button3_Click" />
        </div>
    </div>
</asp:Content>

