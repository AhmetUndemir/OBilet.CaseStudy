
$(document).ready(function () {

	$("#changeInfo").on('click', function (ev) {

		var fromBusLocation = $("#frombuslocation option:selected").text();
		var toBusLocation = $("#tobuslocation option:selected").text();
		if (fromBusLocation == toBusLocation) {
			warningAlert("İşlem Başarısız", "Hem başlangıç hem de varış yeri olarak aynı konumu seçilemez", "Tamam");
			return;
		}
		exchange();
	});
});


function warningAlert(title, message, buttonText = "Kapat") {
	swal({
		title: title,
		text: message,
		icon: "warning",
		button: buttonText,
	});
}


function exchange() {
	var co = $("#frombuslocation").val();
	var coText = $("#frombuslocation option:selected").text();
	var co_2 = $("#tobuslocation").val();
	var co_2Text = $("#tobuslocation option:selected").text();

	var toSpan = $('#tobuslocation_chosen a span');
	var result = $(toSpan).text(coText);
	var resultValues = $(toSpan).val(co);
	var fromSpan = $('#frombuslocation_chosen a span');
	var result1 = $(fromSpan).text(co_2Text);
	var result1Value = $(fromSpan).val(co_2);

	$("#frombuslocation option:selected").val(result1Value.val());
	$("#frombuslocation option:selected").text(result1.text());
	$("#tobuslocation option:selected").val(resultValues.val());
	$("#tobuslocation option:selected").text(result.text());
}

$(function () {
	$('#today').css("background-color", "white");
	$('#tomorrow').css("background-color", "grey");
	var tomorrow = new Date();
	tomorrow.setDate(tomorrow.getDate() + 1);
	$("#date").value = tomorrow.toDateString();
});

$("#date").flatpickr({
	enableTime: true,
	locale: "tr",
	dateFormat: "D M d Y",
	minDate: "today"
});

$("#today").click(function () {
	$('#today').css("background-color", "grey");
	$('#tomorrow').css("background-color", "white");
	var date = new Date();
	$("#date").val(date.toDateString());
});

$("#tomorrow").click(function () {
	$('#today').css("background-color", "white");
	$('#tomorrow').css("background-color", "grey");
	var tomorrow = new Date();
	tomorrow.setDate(tomorrow.getDate() + 1);
	$("#date").val(tomorrow.toDateString());
});

$(function () {
	$("#frombuslocation").chosen();
	$(".chosen-single").css("border", "0");
	$("#tobuslocation").chosen();
	$(".chosen-single").css("border", "0");
});

$("#submit").click(function () {

	var fromBusLocation = $("#frombuslocation option:selected").val();
	var toBusLocation = $("#tobuslocation option:selected").val();
	if (fromBusLocation == "" && toBusLocation == "") {
		$("#frombuslocationvalidation").show();
		$("#tobuslocationvalidation").show();
		return false;
	}
	else if (fromBusLocation == "") {
		$("#frombuslocationvalidation").show();
		$("#tobuslocationvalidation").hide();
		return false;
	}
	else if (toBusLocation == "") {
		$("#tobuslocationvalidation").show();
		$("#frombuslocationvalidation").hide();
		return false;
	}
});

$(function () {

	var originLocationText = $("#originlocation").val();
	var originLocationId = $("#originlocationid").val();
	var destinationLocationText = $("#destinationlocation").val();
	var destinationLocationId = $("#destinationlocationid").val();

	var date = new Date();
	if (originLocationText != "" && destinationLocationText != "" && $("#departure").val() != "") {
		var toSpan = $('#tobuslocation_chosen a span');
		var result = $(toSpan).text(destinationLocationText);
		var resultValues = $(toSpan).val(originLocationId);
		var fromSpan = $('#frombuslocation_chosen a span');
		var result1 = $(fromSpan).text(originLocationText);
		var result1Value = $(fromSpan).val(destinationLocationId);

		$("#frombuslocation option:selected").val(result1Value.val());
		$("#frombuslocation option:selected").text(result1.text());
		$("#tobuslocation option:selected").val(resultValues.val());
		$("#tobuslocation option:selected").text(result.text());

		var departure = $("#departure").val().split(' ')[0].split('.');
		departure = departure[1] + "." + departure[0] + "." + departure[2]
		departure = new Date(departure);
		$("#date").val(departure.toDateString());
	}
	else {
		date = new Date();
		date.setDate(date.getDate() + 1);
		$("#date").val(date.toDateString());
	}
});