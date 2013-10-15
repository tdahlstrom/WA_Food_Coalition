function addFoodBank() {
    var source = {
        'Name': $("#inputName").val(),
        'Email': $("#inputEmail").val(),
        'Address': $("#inputAddress").val(),
        'rangeInMeters': 3.4
    }
    //FoodBank = { Name: $("#inputName").val(), Email: $("#inputEmail").val(), Address: $("#inputAddress").val(), rangeInMeters: 3.4 };
    //alert(JSON.stringify({ Name: $("#inputName").val(), Email: $("#inputEmail").val(), rangeInMeters: parseInt($("inputRadius").val()) * 1609.34 }));
    var radiusInMeters = parseInt($("inputRadius").val()) * 1609.34;
    $.ajax({
        url: "/api/FoodBank",
        type: "POST",
        data: source,
        success: function (json) {
            alert("Foodbank added successfully");
        },
        error: function(err) {
            $("#addingError").HTML += ": " + err.responseText;
            $("#addingError").show;
        }
    });
    return false;
}

$(document).ready(function () {
    $("#addingError").hide();
    $("#addFoodBank").click(addFoodBank);
});
