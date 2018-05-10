// Write your JavaScript code.
console.log("js up and running");
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

$("#MyPayments").click(function(){
    console.log("PaymentButton clicked")
    $("#UserPayments").show();
    $("#NewPayment").hide();

})
$("#ToggleNewPayment").click(function(){
    $("#NewPayment").show();
    $("#UserPayments").hide();
})
$("#MyAddresses").click(function(){
    $("#UserAddresses").show();
    $("#NewAddress").hide();
})
$("#ToggleNewAddress").click(function(){
    $("#UserAddresses").hide();
    $("#NewAddress").show();
})
/*
$("#AddToWishList").click(function(){
    $.get("AddToWishList", function(data, status){
        if(data == 0){
            var MarkUp = "RemoveFromWishList";
        }
        else{
            var MarkUp = "AddToWishList";
        }
        $("#AddToWishList").value(MarkUp);
        $("#AddToWishList").toggleClass("WishListButton");
    })
})
*/
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
    /*
    $("#FilterByName").click(function(){
        console.log("clicked before filter");
        $.get("Home/FilterByName", function(data,status){
            console.log("clicked");
            var markup = "";
            for(var i = 0; i < data.length; i++){
                markup = "<a asp-action=""Details"" asp-controller=""Book"" asp-route-id="data[i].ID" asp-route-userid=""1""> </a>";
                //markup = "<p>Book Rateing: @book.Rating.ToString("0.0")</p>"
            }
            $("#BooksIndex").html(markup);
        }).fail(function (err) {
            alert("Something Went Wrong");
            console.log(err);
        })
    })

    */
    /////////////

    $('#testTop10-carousel').carousel({
        pause: "hover",
        interval: 4000,
      });


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
})




