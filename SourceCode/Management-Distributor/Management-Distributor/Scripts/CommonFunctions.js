var custom_ajax_timeout = 120000; // 2 min

function LoadingAjax(url, dataPost, beforesend, onsuccess, onerror)
{
    $.ajax({

        url: url,
        data: dataPost,
        dataType: json,
        contentType: 'application/json;charset=utf-8',
        type: "POST",
        async: true,
        timeout: custom_ajax_timeout,
        beforeSend: function () { beforesend(); },
        success: function (data) { if (data.d != null) { onsuccess(data) } },
        error: function () { onerror }

    });
}