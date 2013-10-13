<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Maps.aspx.cs" Inherits="API.Maps" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #map-canvas {
            height: 500px;
            margin: 0;
            padding: 0;
        }
        #map-canvas img {
            max-width: none;
        }
    </style>
</head>
<body>
    
    <div id="map-canvas"></div>
    
    <script src="Scripts/jquery-2.0.3.min.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    <script>
        var map;
        var openInfoWindow;
        
        function initialize() {
            var mapOptions = {
                zoom: 7,
                center: new google.maps.LatLng(47.22, -120.72),
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            map = new google.maps.Map($('#map-canvas')[0], mapOptions);
        }
        
        function showMarkers(locations) {
            locations.forEach(function (loc) {
                var marker = new google.maps.Marker({
                    position: new google.maps.LatLng(loc.Latitude, loc.Longitude),
                    map: map,
                    title: loc.Name,
                    animation: google.maps.Animation.DROP
                });

                var contentString = '<div><a href="/Location/Details/' + loc.ID + '">' + loc.Name + '</a>' +
                    '<p>' + loc.Address + '</p>' +
                    '<p>Description: ' + loc.Description + '</p>' +
                    '<p>Expiration Date: ' + loc.ExpirationDate + '</p>' +
                    '<p>Phone: ' + loc.Phone + '</p>' +
                    '<p>Email: ' + '<a href="emailto:' + loc.Email + '">' + loc.Email + '</a></p>' +
                    '</div>';
                var infowindow = new google.maps.InfoWindow({
                    content: contentString,
                });

                google.maps.event.addListener(marker, 'click', function () {
                    if (openInfoWindow != null) {
                        openInfoWindow.close();
                    }
                    openInfoWindow = infowindow;
                    infowindow.open(map, marker);
                });
            });
        }

        $(function () {
            initialize();
            $.get('/api/donation', function (data) {
                console.log(data);
                showMarkers(data);
            });
        })
    </script>
</body>
</html>
