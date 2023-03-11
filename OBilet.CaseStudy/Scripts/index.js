$(document).ready(function () {
    debugger;
    $("#changeInfo").on('click', function (ev) {
        debugger;
        var a = $("#frombuslocation option:selected").text();
        var b = $("#tobuslocation option:selected").text();
        if (a == b) {
            alert("Hem başlangıç hem de varış yeri olarak aynı konumu seçilemez.");
        } else {
            swaper();
        }
    });
});

function swaper() {
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
    debugger;
    $('#today').css("background-color", "white");
    $('#tomorrow').css("background-color", "grey");
    var tomorrow = new Date();
    tomorrow.setDate(tomorrow.getDate() + 1);
    $("#date").value = tomorrow.toDateString();
});

$("#date").flatpickr({
    enableTime: true,
    locale:"tr",
    //dateFormat: "d F Y l",
    dateFormat: "D M d Y",
    minDate: "today"
});

$("#today").click(function () {
    debugger;
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
    debugger;
    var a = $("#frombuslocation option:selected").val();
    var b = $("#tobuslocation option:selected").val();
    if (a == "" && b == "") {
        $("#frombuslocationvalidation").show();
        $("#tobuslocationvalidation").show();
        return false;
    }
    else if (a == "") {
        $("#frombuslocationvalidation").show();
        $("#tobuslocationvalidation").hide();
        return false;
    }
    else if (b == "") {
        $("#tobuslocationvalidation").show();
        $("#frombuslocationvalidation").hide();
        return false;
    }
});

$(function () {
    debugger;
    var originvaltext = $("#originlocation").val();
    var originvalId = $("#originlocationid").val();
    var destinationText = $("#destinationlocation").val();
    var destinationid = $("#destinationlocationid").val();

    if (originvaltext != null && destinationText != null && $("#departure").val() != null) {
        var toSpan = $('#tobuslocation_chosen a span');
        var result = $(toSpan).text(destinationText); destinationText
        var resultValues = $(toSpan).val(originvalId);
        var fromSpan = $('#frombuslocation_chosen a span');
        var result1 = $(fromSpan).text(originvaltext);
        var result1Value = $(fromSpan).val(destinationid);

        $("#frombuslocation option:selected").val(result1Value.val());
        $("#frombuslocation option:selected").text(result1.text());
        $("#tobuslocation option:selected").val(resultValues.val());
        $("#tobuslocation option:selected").text(result.text());

        var departure = $("#departure").val();
        departure = new Date(departure).toLocaleString()
        var date = new Date(departure); 
        $("#date").val(date.toDateString());

    }
});