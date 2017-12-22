var Categories = []
//fetch categories from database
function LoadCategory(element) {
    if (Categories.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '/home/getCategories',
            success: function (data) {
                Categories = data;
                //render catagory
                renderCategory(element);
            }
        })
    }
    else {
        //render catagory to the element
        renderCategory(element);
    }
}

function renderCategory(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(Categories, function (i, val) {
        $ele.append($('<option/>').val(val.CategoryID).text(val.CategoryName));
    })
}

//fetch products
function LoadProduct(categoryDD) {
    $.ajax({
        type: "GET",
        url: "/home/getProducts",
        data: { 'categoryID': $(categoryDD).val() },
        success: function (data) {
            //render products to appropriate dropdown
            renderProduct($(categoryDD).parents('.mycontainer').find('select.product'), data);
        },
        error: function (error) {
            console.log(error);
        }
    })
}

function renderProduct(element, data) {
    //render product
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(data, function (i, val) {
        $ele.append($('<option/>').val(val.ProductID).text(val.ProductName));
    })
}


//////

$(document).ready(function () {
    //Add button click event
    $('#addOrder').click(function () {
        //validation and add order items
        // Category
        var isAllValid = true;
        if ($('#category').val() == "0") {
            isAllValid = false;
            $('#category').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#category').siblings('span.error').css('visibility', 'hidden');
        }

        // Product
        if ($('#product').val() == "0") {
            isAllValid = false;
            $('#product').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#product').siblings('span.error').css('visibility', 'hidden');
        }

        // Demand Quantity
        if (!($('#demandquantity').val().trim() != '' && (parseInt($('#demandquantity').val()) || 0))) {
            isAllValid = false;
            $('#demandquantity').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#demandquantity').siblings('span.error').css('visibility', 'hidden');
        }

        // Actual Quantity
        if (!($('#actualquantity').val().trim() != '' && (parseInt($('#actualquantity').val()) || 0))) {
            isAllValid = false;
            $('#actualquantity').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#quantity').siblings('span.error').css('visibility', 'hidden');
        }

        // Price
        if (!($('#price').val().trim() != '' && !isNaN($('#price').val().trim()))) {
            isAllValid = false;
            $('#price').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#price').siblings('span.error').css('visibility', 'hidden');
        }

        // Unit
        if ($('#unit').val() == "0") {
            isAllValid = false;
            $('#unit').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#unit').siblings('span.error').css('visibility', 'hidden');
        }

        //
        if (isAllValid) {
            var $newRow = $('#mainrow').clone().removeAttr('id');
            $('.pc', $newRow).val($('#category').val());
            $('.product', $newRow).val($('#product').val());

            //Replace add button with remove button
            $('#addOrder', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');

            //remove id attribute from new clone row
            $('#category,#product,#demandquantity,#actualquantity,#price,#unit,#addOrder', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
            //append clone row
            $('#orderdetailsItems').append($newRow);

            //clear select data
            $('#category,#product,#unit').val('0');
            $('#demandquantity,#actualquantity,#price').val('');
            $('#orderItemError').empty();
        }

    })

    //remove button click event
    $('#orderdetailsItems').on('click', '.remove', function () {
        $(this).parents('tr').remove();
    });

    $('#saveOrder').click(function () {
        var isAllValid = true;

        //validate order items
        $('#orderItemError').text('');
        var list = [];
        var errorItemCount = 0;
        $('#orderdetailsItems tbody tr').each(function (index, ele) {
            if (
                $('select.product', this).val() == "0" ||
                (parseInt($('.demandquantity', this).val())) == 0 ||
                (parseInt($('.actualquantity', this).val())) == 0 ||
                $('.price', this).val() == "" ||
                isNaN($('.price', this).val()) || 
                $('select.unit', this).val() == "0"
                ) {
                errorItemCount++;
                $(this).addClass('error');
            } else {
                var orderItem = {
                    ProductID: $('select.product', this).val(),
                    DemandQuantity: parseInt($('.demandquantity', this).val()),
                    ActualQuantity: parseInt($('.actualquantity', this).val()),
                    Price: parseFloat($('.price', this).val()),
                    Unit: $('select.unit', this).val(),
                }
                list.push(orderItem);
            }
        })

        if (errorItemCount > 0) {
            $('#orderItemError').text(errorItemCount + " invalid entry in order item list.");
            isAllValid = false;
        }

        if (list.length == 0) {
            $('#orderItemError').text('At least 1 order item required.');
            isAllValid = false;
        }

        

        if ($('#orderDate').val().trim() == '') {
            $('#orderDate').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#orderDate').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#deliveryDate').val().trim() == '') {
            $('#deliveryDate').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#deliveryDate').siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllValid) {
            var data = {
                
                OrderDate: $('#orderDate').val().trim(),
                DeliveryDate: $('#deliveryDate').val().trim(),
                Status: $('#status').val().trim(),
                OrdersDetail: list
            }

            $(this).val('Please wait...');

            $.ajax({
                type: 'POST',
                url: '/home/save',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        alert('Successfully saved');
                        //here we will clear the form
                        list = [];
                        $('#orderDate,#deliveryDate,#status').val('');
                        $('#orderdetailsItems').empty();
                    }
                    else {
                        alert('Error');
                    }
                    $('#saveOrder').val('Save');
                },
                error: function (error) {
                    console.log(error);
                    $('#saveOrder').val('Save');
                }
            });
        }

    });

});

LoadCategory($('#category'));