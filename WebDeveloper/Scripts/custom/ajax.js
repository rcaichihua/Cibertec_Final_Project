//(function () {
//    var promise
//})();

function getResource(address) {
    var promise = $.ajax({
        url: address,
        statusCode: {
            404: function () {
                alert("page not found");
            }
        }
    });
    promise.done(function(response)
    {
        var dialog = $("#divDialog");
        if (dialog)
        {
            dialog.html(response).dialog();            
        }        
    });

}