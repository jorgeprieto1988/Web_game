<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="Shop.aspx.cs" Inherits="Shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #moneybag1 {
            margin-left: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="moneybag1">
        &nbsp;
        <asp:ImageButton ID="ImageButton2" runat="server" src ="images/100.png" OnClick="ImageButton2_Click"/>
        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton3" runat="server" src ="images/200.png" OnClick="ImageButton3_Click"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton4" runat="server" src ="images/500.png" OnClick="ImageButton4_Click"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton5" runat="server" src ="images/1000.png" OnClick="ImageButton5_Click"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        <br />
        <asp:ImageButton ID="ImageButton6" runat="server" src ="images/PoloBlanca.png" OnClick="ImageButton6_Click"/>
        <br />
    </div>
    </asp:Content>

