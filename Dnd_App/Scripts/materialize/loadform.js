﻿var input_selector = 'input[type=text], input[type=password], input[type=email], input[type=url], input[type=tel], input[type=number], input[type=search], textarea';
$(document).ready(function () {
    $(input_selector).each(function (index, element) {
        if ($(element).val().length > 0) {
            $(this).siblings('label, i').addClass('active');
        }
    });
});