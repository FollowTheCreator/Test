$("#trueSelect").on("change", function () {
    $("#form0").submit();
    switch (this.value) {
        case "%":
            $("#falseSelect").find("#Habr").removeAttr("selected");
            $("#falseSelect").find("#Interfax").removeAttr("selected");
            $("#falseSelect").find("#all").attr("selected", true);
            break;
        case "Habr.com":
            $("#falseSelect").find("#all").removeAttr("selected");
            $("#falseSelect").find("#Interfax").removeAttr("selected");
            $("#falseSelect").find("#Habr").attr("selected", true);
            break;
        case "Interfax.by":
            $("#falseSelect").find("#Habr").removeAttr("selected");
            $("#falseSelect").find("#all").removeAttr("selected");
            $("#falseSelect").find("#Interfax").attr("selected", true);
            break;
    }
});
$("#trueRadio").find("input[name=sort]").on("click", function () {
    $("#form0").submit();
    $("#falseRadio").find("input[name=sort]").removeAttr("checked");
    (this.value == "date") ? $("#falseRadio").find("#date").attr("checked", true) : $("#falseRadio").find("#source").attr("checked", true)
});
$("#links").on("click", function () {
    $("body,html").animate({ "scrollTop": 0 }, 300);
})