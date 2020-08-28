<%@ Page Title="GoogleMaps" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Web_Client.About" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

   <style>
        
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
        font-family: Montserrat;
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
        font-family: Montserrat;
        font-size: 13px;
        font-weight: 300;
      }
      html, body {
        height: 100%;
        margin: 0;
        padding: 0;
      }
      #map {
        border-radius: 15px;
        height: 800px;
        width: 100%;
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
      .input{
          text-align: center; 
          border: none; 
          border-bottom: 1px solid #707070;
      }
      .input:focus{
          outline: 0;
          border-color: #5FAD81;
      }
      .button{
          background-color: #5FAD81;
          box-shadow: 1px 1px #7B1957;
          border:none;
          color: white;
          border-radius: 5px;
      }
    </style>

    <div style="margin: 2em 0 4px 0; display: flex;">
        <div style="margin-right:2em">
            <asp:Label runat="server" Text="Départ" style="margin-right:.5em"></asp:Label>
            <asp:TextBox ID="Depart" placeholder="123 Jean Moulin" onfocus="this.placeholder=''" onblur="this.placeholder = '123 Jean Moulin'" runat="server" CssClass="input">
            </asp:TextBox>
        </div>
        <div style="margin-right:2em">
            <asp:Label runat="server" Text="" style="margin-right:.5em">Destination</asp:Label>
            <asp:TextBox ID="Arrive" placeholder="123 Jean Moulin" onfocus="this.placeholder=''" onblur="this.placeholder = '123 Jean Moulin'" runat="server" CssClass="input">
            </asp:TextBox>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Valider" CssClass="button" OnClick="ValidateForm"/>
    </div>

    <div id="map"></div>
    
    <script>
        function initMap() {

            //Rue Geo Chavez, Lyon

            //Rue de la Barre, Lyon

            var originAddress = "<%=this.originAddress%>";
            var destinationAddress = "<%=this.destinationAddress%>";
            var lat1 = "<%=this.lat1%>";
            var lng1 = "<%=this.lng1%>";
            var lat2 = "<%=this.lat2%>";
            var lng2 = "<%=this.lng2%>";

            lat1 = lat1.replace(',', '.');
            lng1 = lng1.replace(',', '.');
            lat2 = lat2.replace(',', '.');
            lng2 = lng2.replace(',', '.');

            try {
                var latlng1 = new google.maps.LatLng(parseFloat(lat1), parseFloat(lng1));
                var latlng2 = new google.maps.LatLng(parseFloat(lat2), parseFloat(lng2));
            }
            finally {

            }

          var directionsService = new google.maps.DirectionsService;
          var directionsDisplay = new google.maps.DirectionsRenderer;

          var map = new google.maps.Map(document.getElementById('map'), {
            mapTypeControl: false,
          zoom: 14,
              center: { lat: 45.75, lng: 4.85 }
          });
          //new AutocompleteDirectionsHandler(map);

         var request = {
            origin: originAddress,
            destination: destinationAddress,
             travelMode: 'WALKING',
            waypoints: [
                {
                  location: latlng1,
                },{
                  location: latlng2,
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
            src="https://maps.googleapis.com/maps/api/js?key=...&libraries=places&callback=initMap">
    </script>
    
</asp:Content>
