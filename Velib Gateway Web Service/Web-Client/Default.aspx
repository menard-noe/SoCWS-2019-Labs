<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web_Client._Default" %>


<asp:Content ID="a" runat="server" ContentPlaceHolderID="MainContent">

    <link rel="stylesheet" type="text/css" href="Styles/home-page.css" runat="server"/>
 
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="IndexChanged">
    </asp:DropDownList>

      <asp:DropDownList ID="DropDownList2" runat="server">
    </asp:DropDownList>

</asp:Content>



