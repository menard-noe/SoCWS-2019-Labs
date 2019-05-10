﻿<%@ Page Title="GoogleMaps" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Web_Client.About" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

    <h2><%: Title %>.</h2>
#   <style>
         .controls {
        margin-top: 10px;
        border: 1px solid transparent;
        border-radius: 2px 0 0 2px;
        box-sizing: border-box;
        -moz-box-sizing: border-box;
        height: 32px;
        outline: none;
        box-shadow: 0 2px 6px rgba(0, 0, 0, 0.3);
      }

      #origin-input,
      #destination-input {
        background-color: #fff;
        font-family: Roboto;
        font-size: 15px;
        font-weight: 300;
        margin-left: 12px;
        padding: 0 11px 0 13px;
        text-overflow: ellipsis;
        width: 200px;
      }

      #origin-input:focus,
      #destination-input:focus {
        border-color: #4d90fe;
      }

      #mode-selector {
        color: #fff;
        background-color: #4d90fe;
        margin-left: 12px;
        padding: 5px 11px 0px 11px;
      }

      #mode-selector label {
        font-family: Roboto;
        font-size: 13px;
        font-weight: 300;
      }
      #right-panel {
        font-family: 'Roboto','sans-serif';
        line-height: 30px;
        padding-left: 10px;
      }

      #right-panel select, #right-panel input {
        font-size: 15px;
      }

      #right-panel select {
        width: 100%;
      }

      #right-panel i {
        font-size: 12px;
      }
      html, body {
        height: 100%;
        margin: 0;
        padding: 0;
      }
      #map {
        height: 1000px;
        float: left;
        width: 70%;
      }
      #right-panel {
        margin: 20px;
        border-width: 2px;
        width: 20%;
        height: 400px;
        float: left;
        text-align: left;
        padding-top: 0;
      }
      #directions-panel {
        margin-top: 10px;
        background-color: #FFEE77;
        padding: 10px;
        overflow: scroll;
        height: 174px;
      }
    </style>

    <div>
        <asp:Label runat="server" Text="Depart"></asp:Label>
        <asp:TextBox ID="Depart" runat="server">
        </asp:TextBox>
        <asp:Label runat="server" Text="">Arrive</asp:Label>
        <asp:TextBox ID="Arrive" runat="server">
        </asp:TextBox>

        <asp:Button ID="Button1" runat="server" Text="Validate" OnClick="ValidateForm"/>
        <asp:TextBox ID="TextBox1" runat="server">
        </asp:TextBox>
    </div>

    <div id="map"></div>
    <div id="right-panel">
        <div style="display: none">
            <input id="origin-input" class="controls" type="text"
                   placeholder="Enter an origin location">

            <input id="origin-velib" class="controls" type="text"
                   placeholder="Enter a velib here">
            <input id="destination-velib" class="controls" type="text"
                   placeholder="Enter a velib here">
            <input id="destination-input" class="controls" type="text"
                   placeholder="Enter a destination location">

            <div id="mode-selector" class="controls">
                <input type="radio" name="type" id="changemode-walking" checked="checked">
                <label for="changemode-walking">Walking</label>

                <input type="radio" name="type" id="changemode-transit">
                <label for="changemode-transit">Transit</label>

                <input type="radio" name="type" id="changemode-driving">
                <label for="changemode-driving">Driving</label>
            </div>
        </div>
    </div>
    <script>
        function initMap() {
     
            var test = "<%=this.originAddress%>"

            window.alert(test);

          var directionsService = new google.maps.DirectionsService;
          var directionsDisplay = new google.maps.DirectionsRenderer;

          var map = new google.maps.Map(document.getElementById('map'), {
            mapTypeControl: false,
          zoom: 15,
              center: { lat: 49.44, lng: 1.09 }
          });
          //new AutocompleteDirectionsHandler(map);

         var request = {
            origin: 'Rouen',
            destination: 'Strasbourg',
             travelMode: 'WALKING',
            waypoints: [
                {
                  location: 'Paris',
                },{
                  location: '210 avenue Roumanille, Biot',
                }
             ]
         };

         directionsService.route(request, function(response, status) {
            if (status == 'OK') {
                directionsDisplay.setDirections(response);
        }
  });

          directionsDisplay.setMap(map);
}

    </script>
    <script async defer
            src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBYXWW2Y_IdfTYXyn-iep5hbHDdpOyTqwM&libraries=places&callback=initMap">
    </script>
    
</asp:Content>