function getFoodBanks() {
    $.getJSON("/api/FoodBank",
	function (data) {
	    // Loop through list of foodbanks
	    var html = $.map(data, function (item, i) {
	        return "<tr><td>" + item.Name + "</td><td>" + item.Email + "</td><td>" + item.rangeInMeters + "</td></tr>";
	    }).join("");
	    $("#foodbanks").append(html);
	});
}

$(document).ready(getFoodBanks);
