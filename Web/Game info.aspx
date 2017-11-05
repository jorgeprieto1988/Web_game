<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Game info.aspx.cs" Inherits="Gameinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel2" runat="server">
        GAME INFO<br />
        <br />
        Battles<br /> The battles will be between two characters, and the winner of this battle will depend on the attributes of each player and luck. When the life of a character is zero, this character will lose the battle. Although battles are not visible they are resolved in turns.<br />
        <br />
        Luck<br /> The luck will be a random value between zero and ten, the damage dealt will be your damage plus the random value achieved.<br />
        <br />
        Shop<br /> &nbsp;&nbsp;&nbsp; Real life items:<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; This items will be bought at the store and will be associated to the account, not to the character.<br />
        <br />
        &nbsp;&nbsp;&nbsp; In-game items:<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; This items will be bought in game and will be associated to the character.<br />
        <br />
        Friend list:<br /> You will be able to add or delete users.<br />
        <br />
        Messages:<br /> You can send or recieve messages from the users.<br /> </asp:Panel>
    <p>
        <br />
    </p>
    </asp:Content>

