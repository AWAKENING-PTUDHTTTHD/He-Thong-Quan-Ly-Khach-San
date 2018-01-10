
$(function () {

    // 1. Simulate preLoad Screen
//    $("#loaderbody").addClass('hide');


//    $(document).bind('ajaxStart', function () {
//        $("#loaderbody").removeClass('hide');
//    }).bind('ajaxStop', function () {
//        $("#loaderbody").addClass('hide');
//    });
//});

//$(document).ready(function() {
//    $('#loaderbody').addClass('hide');
//    $(document).ajaxStart(function () {
//        $('#loaderbody').removeClass('hide');
//    }).ajaxStop(function () {
//        $('#loaderbody').addClass('hide');
    //    });

    // 2. Binding Description textArea
    //1. binding textArea length
    $("#characterLeft").text('140 characters left');
    // count character left
    $("#message").keydown(function () {
        var maxLenght = 140;
        var CurrentLength = $(this).val().length;
        if (CurrentLength >= maxLenght) {
            $("#characterLeft").text('You have reached the limit');
            // highlight notification
            $("#characterLeft").addClass('red');
            $('#btnSubmit').addClass('disable');
        }
        else {
            $("#characterLeft").text(maxLenght - CurrentLength + ' characters left');
            $('#characterLeft').removeClass('red');
            $("#btnSubmit").removeClass('disable');
        }
    });

    //2. reset Form
    //$('#btnReset').click(function () {
    //    $('#form ')[0].reset();
    //});


});




function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}

