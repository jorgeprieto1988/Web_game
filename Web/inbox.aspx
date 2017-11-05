<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="inbox.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height: 101px">
    </div>
    <div style="background-color: #000000; height: 242px; width: 697px; margin-left: 100px;">
        <div style="height: 45px">
            <asp:Button ID="Button2" runat="server" Height="23px" Text="Send a message" 
                Width="133px" PostBackUrl="~/Messages.aspx" />
        </div>
        
        <div style="height: 148px" align="center">
            <asp:GridView ID="GridView1" runat="server" BorderColor="#999999" 
                BorderStyle="Solid" Height="89px" Width="456px" AutoGenerateColumns="False"  BackColor="White" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="id_message" HeaderText="id_message" ReadOnly="True" SortExpression="id_message" Visible="False" />
                    <asp:BoundField DataField="sender" HeaderText="sender" ReadOnly="True" SortExpression="sender" />
                    <asp:BoundField DataField="receiver" HeaderText="receiver" ReadOnly="True" SortExpression="receiver" Visible="False" />
                    <asp:BoundField DataField="text" HeaderText="text" ReadOnly="True" SortExpression="text" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>            
        </div>
        <div style="height: 36px" align="center">
        </div>
    </div>
</asp:Content>

