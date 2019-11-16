
$(document).ready(function () {
    $("#menu").menu();
    $("#one").click(function () {
        var item = $("#value1").html();
        $("#Title").val(item.toString());
        $("#index").html(item);
    });
    

});


