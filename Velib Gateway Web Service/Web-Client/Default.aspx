<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web_Client._Default" %>

<asp:Content ID="a" runat="server" ContentPlaceHolderID="MainContent">


    <!--<div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>
    -->

    <asp:Button ID = "Button1" runat ="server" Text="Validate" class="btn" OnClick="Validate"/>

    <asp:TextBox ID ="TextBox1" runat ="server" TextMode="MultiLine"> 
        
    </asp:TextBox>


    </asp:Content>


