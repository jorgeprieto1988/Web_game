<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="Blacksmith.aspx.cs" Inherits="Blacksmith" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        BLACKSMITH
    <p>
        SHOP</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="name" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" ReadOnly="True" />
                <asp:BoundField HeaderText="gold" DataField="gold" SortExpression="gold" />
                <asp:BoundField HeaderText="extra_attack" DataField="extra_attack" SortExpression="extra_attack" />
                <asp:BoundField DataField="extra_health" HeaderText="extra_health" SortExpression="extra_health" />
                <asp:BoundField DataField="extra_defense" HeaderText="extra_defense" SortExpression="extra_defense" />
                     <asp:TemplateField>
        <ItemTemplate>
            <asp:Button ID="Buttonid" runat="server" CommandName="Buy" Text="Buy" OnClick="Button_click_event"></asp:Button>    
        </ItemTemplate>
 </asp:TemplateField>
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADAdatabase_FINAL %>" SelectCommand="SELECT * FROM [items_game]"></asp:SqlDataSource>
    </p>
    <p>
        Your Items</p>
    <asp:GridView ID="GridView2" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
        <Columns>
            <asp:BoundField HeaderText="name_it" DataField="name_it" SortExpression="name_it" />
                                 <asp:TemplateField>
        <ItemTemplate>
            <asp:Button ID="Buttonid2" runat="server" CommandName="Sell" Text="Sell" OnClick="Button_click_event2"></asp:Button>    
        </ItemTemplate>
 </asp:TemplateField>
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADAdatabase_FINAL %>" SelectCommand="SELECT [name_it] FROM [bag_character] WHERE ([name_ch] = @name_ch)">
            <SelectParameters>
                <asp:SessionParameter Name="name_ch" SessionField="Character" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        </asp:Content>

