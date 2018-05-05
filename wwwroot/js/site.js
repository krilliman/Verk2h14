// Write your JavaScript code.

$( document ).ready(function() {

$("#payment-info").click(function(){
    console.log("clicked");
    $.get("PaymentIfno" , function(data, status){
        var markup = "<tbody><tr><th>Nafn</th><th>Tegund</th><th>Notandi</th><th>Síða</th></tr>";
        for(var i = 0; i < data.length; i++){
            markup += "<tr><td>" +data[i].name + "</td><td>" + data[i].type + "</td><td>" + data[i].creator + "</td><td><a href=\""+ data[i].linkName +"\">Link</a></td></tr>";
        }
        markup += "</tbody>";
        $("#index-table").html(markup);
    }).fail(function(err){
        alert("Something Went Wrong");
        console.log(err);
    })
})

    $("#cat-link").one("click", function () {
        $.get("Category/AllCategories", function(data, status) {
            var catList = "testlinkFromJS";
            $("#cat-list").append(catList);
            
            for (var i = 0; i < data.length; i++) {
                var category = "<li>" + data[i].name + "</li>";
                $("#cat-list").append(category);
            }
            // $("#cat-link").prop('disabled', true);
        })
        .fail(function(err) {
            alert("err");
        })
    })
    










