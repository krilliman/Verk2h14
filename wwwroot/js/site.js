// Write your JavaScript code.
console.log("js up and running");

/*
$("#PayButton").click(function(){
})
*/
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
    $("#CheckOutForm").submit(function(e){
        var Counter = 0;
        var check = true;
        $("input:radio").each(function(){
            var name = $(this).attr("name");
            Counter++;
            if($("input:radio[name="+name+"]:checked").length == 0){
                check = false;
            }
        });
        var AddressClass = $("#UserAddresses").hasClass("hidden");
        var PaymentClass = $("#UserPayments").hasClass("hidden");
        if(!check && !AddressClass && !PaymentClass){
            e.preventDefault();
            alert('Please Select An Option');
        }
        else if(Counter == 0 && !AddressClass){
            e.preventDefault();
            alert('Please Select An Option');
        }
        else if(Counter == 0 && !PaymentClass){
            e.preventDefault();
            alert('Please Select An Option');
        }
    });   
    $("#MyPayments").click(function(){
        console.log("PaymentButton clicked")
        $("#UserPayments").removeClass("hidden");
        $("#NewPayment").addClass("hidden");
    })
    $("#ToggleNewPayment").click(function(){
        $("#NewPayment").removeClass("hidden");
        $("#UserPayments").addClass("hidden");
    })
    $("#MyAddresses").click(function(){
        $("#UserAddresses").removeClass("hidden");
        $("#NewAddress").addClass("hidden");
    })
    $("#ToggleNewAddress").click(function(){
        $("#UserAddresses").addClass("hidden");
        $("#NewAddress").removeClass("hidden");
    })
    $("#CreateAddress").click(function(){
        console.log("clicked");
        $("#AddAddressDiv").removeClass("hidden");
        $("#CreateAddress").hide();
    })
    $("#CreatePayment").click(function(){
        $("#AddPaymentDiv").removeClass("hidden");
        $("CreatePayment").hide();
    })
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
                var category = "<a class=\"dropdown-item\" href=\"/Category/SubCategory/" + data[i].id + "\" >" + data[i].name + "</a>"; // held thetta thurfi ad vera svona thvi aspdotid hledst bara a fyrsta loadi?
                $("#cat-list").append(category);
            }
        })
            .fail(function (err) {
                alert(err);
            })
    })   

var $divs = $("div.list-items1");
$('#order-button1').on('click', function () {
    var nameOrder= $divs.sort(function (a, b) {
        return $(a).data('sort-name') < $(b).data('sort-name') ? -1 : 1;
    });
    
    $("#ordered-list").html(nameOrder);
});

$('#order-button2').on('click', function () {
    var nameOrder= $divs.sort(function (a, b) {
        return $(a).data('sort-name') > $(b).data('sort-name') ? -1 : 1;
    });
    
    $("#ordered-list").html(nameOrder);
});

$('#order-button3').on('click', function () {   
    var ratingOrder = $divs.sort(function (a, b) {
        return $(a).data('sort-rating') > $(b).data('sort-rating') ? -1 : 1;
    });
    $("#ordered-list").html(ratingOrder);
});




})




