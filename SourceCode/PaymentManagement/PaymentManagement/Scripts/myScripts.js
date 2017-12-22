/////// getInvoiceList
var invoices = []
//fetch categories from database
function loadInvoice(element) {
    if (invoices.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '/payment/getInvoice',
            success: function (data) {
                invoices = data;
                //render catagory
                renderInvoice(element);
            }
        })
    }
    else {
        //render catagory to the element
        renderInvoice(element);
    }
}

function renderInvoice(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(invoices, function (i, val) {
        $ele.append($('<option/>').val(val.InvoiceID).text(val.InvoiceName));
    })
}


/////// Require 
$(document).ready(function () {

    var oTable = $('#myDatatable').DataTable({
        "ajax": {
            "url": '/payment/getPayment',
            "type": "get",
            "datatype": "json"
        },
        "columns": [
            { "data": "InvoiceID", "autoWidth": true },
            { "data": "Amount", "autoWidth": true },
            { "data": "PaidDate", "autoWidth": true },
            { "data": "ExceedDate", "autoWidth": true },
            { "data": "Status", "autoWidth": true },
            { "data": "Note", "autoWidth": true },
            {
                "data": "PaymentID", "width": "50px", "render": function (data) {
                    return '<a class="popup" href="/payment/save/' + data + '">Edit</a>';
                }
            },
            {
                "data": "PaymentID", "width": "50px", "render": function (data) {
                    return '<a class="popup" href="/payment/delete/' + data + '">Delete</a>';
                }
            }
        ]
    })
    $('.tablecontainer').on('click', 'a.popup', function (e) {
        e.preventDefault();
        OpenPopup($(this).attr('href'));
    })


    function OpenPopup(pageUrl) {
        var $pageContent = $('<div/>');
        $pageContent.load(pageUrl, function () {
            $('#popupForm', $pageContent).removeData('validator');
            $('#popupForm', $pageContent).removeData('unobtrusiveValidation');
            $.validator.unobtrusive.parse('form');

        });

        $dialog = $('<div class="popupWindow" style="overflow:auto"></div>')
                  .html($pageContent)
                  .dialog({
                      draggable: false,
                      autoOpen: false,
                      resizable: false,
                      model: true,
                      title: 'Popup Dialog',
                      height: 550,
                      width: 600,
                      close: function () {
                          $dialog.dialog('destroy').remove();
                      }
                  })

        $('.popupWindow').on('submit', '#popupForm', function (e) {
            var url = $('#popupForm')[0].action;
            $.ajax({
                type: "POST",
                url: url,
                data: $('#popupForm').serialize(),
                success: function (data) {
                    if (data.status) {
                        $dialog.dialog('close');
                        oTable.ajax.reload();
                    }
                }
            })

            e.preventDefault();
        })
        $dialog.dialog('open');
    }
})