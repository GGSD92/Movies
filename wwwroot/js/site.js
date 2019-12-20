// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getData(url, successMessage, successCallback) {
    $("#myModal").show();
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (successMessage !== null) {
                //showNotification("Exito.", successMessage, '');
            }
            successCallback(data);
        },
        error: function (response) {
            //showNotification("Error.", response.responseText, '');
        },
        complete: function () {
            $('#myModal').hide();
        }

       
    });
}

function saveFormData(isNew, controllerName, iconUrl) {
   
    $("myModal").show();

    var url = isNew ? "/" + controllerName + "/SaveAdd/" : "/" + controllerName + "/SaveEdit/";
    console.log(url);
    var successMessage = isNew ? "Se agrego el registro satisfactoriamente." : "Se actualizo el registro satisfactoriamente.";

    $.ajax({
        url: url,
        type: "POST",
        data: $('#form-edit').serialize(),
        dataType: 'html',
        headers: { RequestVerificationToken: $('input:hidden[name="__RequestVerificationToken"]').val() },
        success: function (response) {
            $("#tableData").html(response);   
        },
        error: function (response) {
            //showNotification("Error.", response.responseText, iconUrl);
        },
        complete: function () {
         $('#myModal').modal("hide");
        }
    });
}



function deleteRecordConfirmed(controllerName, id) {
    //$("#myModal").show();
    $.ajax({
        url: "/" + controllerName + "/Delete?id=" + id,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            //showNotification("Exito.", "Se elimino el registro satisfactoriamente.", '');
            $("#tableData").html(response);
        },
        complete: function () {
            $('#myModal').hide();
        }
    });
}



function toggleModificationModal() {
    $("#myModal").toggle();
}

function onLoadModificationModalSuccess(response) {
    $("#modalbody").html(response);
    $("#myModal").modal();
}

function onLoadAddModal(url) {
    $("#modalbody").load(url);
    $("#myModal").modal();
}




