// Write your JavaScript code.

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
        $.get("../../Category/GetMainCategoryList", function (data, status) {
            for (var i = 0; i < data.length; i++) {
                var category = "<li><a href=\"/Category/SubCategory/" + data[i].id + "\" >" + data[i].name + "</a></li>"; // held thetta thurfi ad vera svona thvi aspdotid hledst bara a fyrsta loadi?
                $("#cat-list").append(category);

                $("#cat-link").one("click", function () {
                    $.get("../../Category/AllSubCategories/@data[i].id", function (subData, status) {
                        for (var i = 0; i < subData.length; i++) {
                            var subCategory = "<li><a href=\"/Category/SubCategory/" + subData[i].id + "\" >" + subData[i].name + "</a></li>"; // held thetta thurfi ad vera svona thvi aspdotid hledst bara a fyrsta loadi?
                            $("#cat-list").append(category);
                        }
                    })
                })
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




