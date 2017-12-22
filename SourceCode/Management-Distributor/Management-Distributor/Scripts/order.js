var categories = [];

// fetch categories from Db
function LoadCategory(el) {
    if (categories.length === 0) {
        $.ajax({
            type: "GET",
            url: "Categories/LoadData",
            success: function (data) {
                Categories = data;
                // render categories
                renderCategory(el);
            }
        });
    } else {
        // render category to the element
        renderCategory(el);
    }
}

function renderCategory(el) {

    var $ele = $(el);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('select'));
    $.each(Categories, (i, val) => {
        $ele.append($('<option/>').val(val.CategoryID).text(val.CategoryName));
    });

}

//  fetch products cascade
function LoadProduct(categoryDropDown) {
    $.ajax({
        type: "GET",
        url: "Products/LoadData",
        data: { 'categoryID': $(categoryDropDown).val() },
        success: function (data) {
            // render products to appropriate dropdown
            renderProduct($(categoryDropDown).parents('.mycontainer').find('select.product'), data);
        },
        error: function (error) {
            console.log(error);
        }

    });
}

function renderProduct(el, data) {
    var $ele = $(el);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(data, (i, val) => {
        $ele.append($('<option/>').val(val.ProductId).text(val.ProductName));
    });
}


$(document).ready(() => {
    // add button click event
    $('#add').on('click', () => {
        // validation first
        var isAllValid = true;
        if ($('productCategory').val() === "0") {
            isAllValid = false;
            // visible above error
            $('#productCagory').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#productCagory').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('product').val() === "0") {
            isAllValid = false;
            // visible above error
            $('#product').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#product').siblings('span.error').css('visibility', 'hidden');
        }

        if (!($('quantity').val().trim() === '') && (parseInt($('quantity').val()) || 0)) {
            isAllValid = false;
            // visible above error
            $('#quantity').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#quantity').siblings('span.error').css('visibility', 'hidden');
        }

        if (!($('price').val().trim() === '') && (!isNaN($('price').val().trim()))) {
            isAllValid = false;
            // visible above error
            $('#price').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#price').siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllValid) {
            var $newRow = $('#mainrow').clone().removeAttr('id')
            $('.pc', $newRow).val($('#productCategory').val());
            $('.product', $newRow).val($('#products').val());

            // remove add button and replace with remove button
            $("#add", $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');

            // remove id attribute from new clone row
            $('#productCategory,#product,#quantity,#price,#add', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();

            // append clone row
            $('#orderdetailsItems').append($newRow);

            // clear select dat
            $('#productCategory,#product').val('0');
            $('#quantity,#price').val('');
            $('#orderItemsError').empty();
        }
    });

    // remove button click event
    $('#orderdetailsItems').on('click', '.remove', () => {
        $(this).parents('str').remove();
    });


    $('#submit').on('click', () => {
        var isAllValid = true;

        // validate order items
        $('#orderItemError').text('');
        var list = [];
        var errorItemCount = 0;
        $('#orderdetailsItems tbody tr').each(function (index, ele) {
            if(
                $('select.product', this).val() === "0" ||
                (parseInt($('.quantity', this).val()) || 0) === 0 ||
                $('.price', this).val() === "" ||
                isNaN($('.price'), this).val()
              )
            {
                errorItemCount++;
                $(this).addClass('error');

            } else {
                var orderItem = {
                    ProductID: $('select.product', this).val(),
                    Quantity: parseInt($('.quantity', this).val()),
                    Price: parseFloat($('.price', this).val())
                }
                list.push(orderItem);
            }
        });

        if (errorItemCount > 0) {
            $('#orderItemError').text(errorItemCount + "invalid entry in order item list");
            isAllValid = false;
        }
        if (list.length === 0) {
            $('#orderItemError').text("At least one order item required");
            isAllValid = false;
        }
        if ($('orderNo').val().trim() === '') {
            $('orderNo').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('orderNo').siblings('span.error').css('visibility', 'hidden');
        }
        if (('#orderDate').val().trim() === '') {
            ('#orderDate').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            ('#orderDate').siblings('span.error').css('visibility', 'hidden');
        }
        if (isAllValid) {
            var data = {
                OrderNo: $('#orderNo').val().trim(),
                OrderDateString: $('#orderDate').val().trim(),
                Description: $('#description').val().trim(),
                OrderDetails: list
            }
            $(this).val('Please wailt ....');

            $.ajax({
                type: "POST",
                url: "Orders/Save",
                data: JSON.stringify(data),
                contentType: "application/json",
                success: function (data) {
                    if (data.status) {
                        alert('Successfully saved');

                        // clear form
                        list = [];
                        $('#orderNo,#orderDate,#description').val('');
                        $('#orderdetailsItems').empty();

                    } else {
                        alert('Error');
                    }
                    $('#submit').text('Save');
                },
                error: function (error) {
                    console.log(error);
                    $('#submit').text('Save');
                }
            });
        }
    });
});

LoadCategory($('productCategory'));