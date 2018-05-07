// Write your JavaScript code.
$("#CreatePayment").click(function(){
    console.log("clicked");
    $("#AddPaymentDiv").show();
    $("#CreatePayment").hide();
})
$("#CreateAddress").click(function(){
    console.log("clicked");
    $("#AddAddressDiv").show();
    $("#CreateAddress").hide();
})
$(document).ready(function () {

    $("#payment-info").click(function () {
        console.log("clicked");
        $.get("PaymentIfno", function (data, status) {
            var markup = "<tbody><tr><th>Nafn</th><th>Tegund</th><th>Notandi</th><th>Síða</th></tr>";
            for (var i = 0; i < data.length; i++) {
                markup += "<tr><td>" + data[i].name + "</td><td>" + data[i].type + "</td><td>" + data[i].creator + "</td><td><a href=\"" + data[i].linkName + "\">Link</a></td></tr>";
            }
            markup += "</tbody>";
            $("#index-table").html(markup);
        }).fail(function (err) {
            alert("Something Went Wrong");
            console.log(err);
        })
    })


    $("#cat-link").one("click", function () {
        $.get("../../Category/GetMainCategoryListJson", function (data, status) {
            for (var i = 0; i < data.length; i++) {
                var category = "<li><a href=\"/Category/SubCategory/" + data[i].id + "\" >" + data[i].name + "</a></li>"; // held thetta thurfi ad vera svona thvi aspdotid hledst bara a fyrsta loadi?
                $("#cat-list").append(category);
            }
        })
            .fail(function (err) {
                alert(err);
            })
    })
        .fail(function (err) {
            alert(err);
        })
   
})




