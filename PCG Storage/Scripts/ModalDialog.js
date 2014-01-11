$(document).ready(function () {
    $("#modalPanelFailedClose").click(function () {
        HideModalPanel("modalPanelFailed");
    });
});

function HideModalPanel(panel)
{
    $("div[id$='" + panel + "']").hide();
}