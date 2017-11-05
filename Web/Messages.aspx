<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.master" AutoEventWireup="true" CodeFile="Messages.aspx.cs" Inherits="Messages" %>

<script runat="server">

</script>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height: 101px">
    </div>
    <div style="background-color: #000000; height: 242px; width: 697px; margin-left: 100px;">
        <div style="height: 45px">
            <asp:Button ID="Button2" runat="server" Height="23px" 
                PostBackUrl="~/inbox.aspx" Text="Inbox" Width="133px" OnClick="Button2_Click" />
        </div>
        <div style="height: 46px">
            To:<br />
&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        &nbsp;
            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="email" DataValueField="email">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADAdatabase_FINAL %>" SelectCommand="SELECT [email] FROM [player]"></asp:SqlDataSource>
        </div>
        <div style="height: 115px" align="center">
            <asp:TextBox ID="TextBox1" runat="server" Height="107px" TextMode="MultiLine" 
                Width="433px"></asp:TextBox>
        </div>
        <div style="height: 36px" align="center">
            <asp:Button ID="Button1" runat="server" Text="Send" OnClick="Button1_Click1" />
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
            <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Red" BackColor="Black" Visible="False"></asp:Label>
        </div>
    </div>
</asp:Content>

