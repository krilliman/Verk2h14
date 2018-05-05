// Write your JavaScript code.
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