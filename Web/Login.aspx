<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .leadrace {
            margin-top: 0px;
        }
        .leadname {<a href="Login.aspx">Login.aspx</a>
            margin-bottom: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="imagelogin" style="float: left; margin-left: 600px;">    
        <h1 style="margin-left: 10px; margin-bottom: 4px;">
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Log in</h1>
        <br />
        <p style="margin-left: 90px; margin-top: 0px;" class="leaduser">Nickname 
            <asp:TextBox style="margin-left: 27px" ID="TextBox1" runat="server" Width="115px">
            </asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;</p>
        <p style="margin-left: 90px; margin-top: 0px;" class="leaduser">&nbsp;
            <asp:RequiredFieldValidator style="background-color:#000000;" ID="RequiredFieldValidator1" runat="server" 
                         ControlToValidate="TextBox1" ErrorMessage="*Nickname is required" 
                         ForeColor="Red">
            </asp:RequiredFieldValidator>
        </p>
        
        <p style="margin-left: 90px; margin-bottom: 8px;" class="leadpassword">Password 
            <asp:TextBox style="margin-left: 27px; margin-bottom: 0px;" ID="TextBox2" TextMode="Password" runat="server" Width="115px"></asp:TextBox>

            &nbsp;&nbsp;&nbsp;&nbsp;</p>
        <p style="margin-left: 90px; margin-bottom: 8px;" class="leadpassword">&nbsp;<asp:RequiredFieldValidator style="background-color:#000000;" ID="RequiredFieldValidator2" runat="server" 
                         ControlToValidate="TextBox2" ErrorMessage="*Password is required" 
                         ForeColor="Red">
            </asp:RequiredFieldValidator>

            &nbsp;</p>
        <p style="margin-left: 160px">
            <asp:Button style="margin-left: 10px" ID="Button1" runat="server" Text="LOG IN" Font-Bold="True" Font-Names="Cambria" Font-Size="Small" ForeColor="Black" OnClick="Button1_Click" Width="80px" BackColor="#FFFF99" BorderColor="#660033" BorderStyle="Solid" />
        </p>
      
    </div>
       

    


</asp:Content>