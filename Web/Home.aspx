<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
        NEWS<br />
        <br />
        06/05/2014 - Website created<br /> 07/05/2014 - Private part created<br /> 08/05/2014 - Minor bug fixed<br />
        <br />
        Top players<br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="name" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="name" HeaderText="name" ReadOnly="True" SortExpression="name" />
                <asp:BoundField DataField="race" HeaderText="race" SortExpression="race" />
                <asp:BoundField DataField="health" HeaderText="health" SortExpression="health" />
                <asp:BoundField DataField="attack" HeaderText="attack" SortExpression="attack" />
                <asp:BoundField DataField="defense" HeaderText="defense" SortExpression="defense" />
                <asp:BoundField DataField="experience" HeaderText="experience" SortExpression="experience" />
                <asp:BoundField DataField="level" HeaderText="level" SortExpression="level" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADAdatabase_FINAL %>" SelectCommand="SELECT [name], [race], [health], [attack], [defense], [experience], [level] FROM [character] ORDER BY [level] DESC"></asp:SqlDataSource>
    </asp:Panel>
</asp:Content>



