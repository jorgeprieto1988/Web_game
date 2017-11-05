<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="FriendList.aspx.cs" Inherits="FriendList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        FRIEND LIST
    <p>
        Your friends</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="email2" HeaderText="Friend players" SortExpression="email2" />
                <asp:Buttonfield Buttontype="Link" CommandName="Send" Text="Send a message"/>
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
    </p>
            <div ><div style="left: auto; float: left;"><p align="left" style="width: 200px; left: auto"> Add a friend </p></div><div align="center" style="right: auto; width: 200px; float: right;"><p align="right">Deleting a friend</p></div></div></div>
            <div style="float: left"><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></div>
            <div style="float: right"><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></div>
    
    </p>
            <div><div style="float: right"><asp:Button ID="Button2" runat="server" Text="Borrar amigo" OnClick="Button2_Click" /></div></div>
        <div style="float: left"><asp:Button ID="Button1" runat="server" Text="Añadir amigo" OnClick="Button1_Click" />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False" BackColor="Black" CssClass="dynamic highlighted"></asp:Label>
            <div><asp:Label ID="Label2" runat="server" Text="Label" Visible="False" BackColor="Black" CssClass="dynamic highlighted"></asp:Label></div>
        </div>
        
        
    </p>
    </asp:Content>

