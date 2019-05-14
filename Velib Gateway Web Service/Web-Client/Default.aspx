<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web_Client._Default" %>


<asp:Content ID="a" runat="server" ContentPlaceHolderID="MainContent">
    
    <link rel="stylesheet" type="text/css" href="Styles/home.css" runat="server"/>
        
    <asp:Button ID="Button1" runat ="server" Text="Voir les villes" class="btn" CssClass="show-btn" OnClick="Validate" Visible="True"/>

    <div id="info" class="list-wrapper">
        <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="true" CssClass="listBox cities" Visible="false" OnSelectedIndexChanged="IndexChanged">
        </asp:ListBox>
        <asp:ListBox ID="ListBox2" runat="server" AutoPostBack="true" CssClass="listBox stations" Visible="false" OnSelectedIndexChanged="StationChanged">
        </asp:ListBox>
        <asp:TextBox ID="TextBox" runat="server" AutoPostBack="true" CssClass="textBox infos" Visible="false" Text=".">
        </asp:TextBox>
    </div>

    <script>
        function click_btn() {
            document.getElementById("MainContent_Button1").click()
        }
        window.onload = click_btn;
    </script>
</asp:Content>



