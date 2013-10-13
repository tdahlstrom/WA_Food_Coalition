$(document).ready(function() {
	var email = $("#changeEmail");
	var radius = $("#changeRadius");
	$("#settingsError").hide();
	$("#saveSettings").click(function(){
		if (email.attr("current") != email.val() 
			|| radius.attr("current") != radius.val()) {
			alert('woop');
			// make ajax request
		}
	});
	$("#cancelSettingChanges").click(function(){
		email.val(email.attr("current"));
		radius.val(radius.attr("current"));
	});
});