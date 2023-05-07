function CalculateIncomeTax() {
    var monthlyIncome = document.getElementById("monthlyIncome");
    var postalCode = document.getElementById("postalCode");

    if (monthlyIncome.value === "" || monthlyIncome.value === undefined) {
        swal.fire({
            title: 'Oops...',
            text: 'Monthly Income is required.',
            type: "warning",
            icon: "warning",
            showConfirmButton: false,
            showCancelButton: false
        });
    }

    if (postalCode.value === "" || postalCode.value === undefined) {
        swal.fire({
            title: 'Oops...',
            text: 'Postal Code is required.',
            type: "warning",
            icon: "warning",
            showConfirmButton: false,
            showCancelButton: false
        });
    }

    //Set data for post
    var senddata = {};
    senddata["monthlyIncome"] = monthlyIncome.value;
    senddata["postalCode"] = postalCode.value;

    swal.fire({
        title: 'Calculating Tax..',
        text: 'Busy doing some calculations please wait.',
        type: "warning",
        icon: "warning",
        showConfirmButton: false,
        showCancelButton: false
    });

    $.ajax({
        type: "POST",
        url: '/Tax/CalculateTax',
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        dataType: 'JSON',
        contentType: "application/json",
        data: JSON.stringify(senddata),
        success: function (result) {
            if (typeof result === 'string' || result instanceof String) {
                if (result === "Failed") {
                    swal.fire({
                        title: 'Oops...',
                        text: 'Ajax call failed - Make sure that the API project is also running.',
                        type: "error",
                        icon: "error",
                        showConfirmButton: false,
                        showCancelButton: false
                    });
                }
                else {
                    swal.fire({
                        title: 'Oops...',
                        text: 'Ajax call failed - Something went wrong.',
                        type: "error",
                        icon: "error",
                        showConfirmButton: false,
                        showCancelButton: false
                    });
                }
            }
            else {
                swal.fire({
                    title: 'Calculations complete',
                    text: 'Your annual tax is: R ' + result,
                    type: "success",
                    icon: "success",
                    showConfirmButton: true,
                    showCancelButton: false
                });
            }
        },
        error: function () {
            swal.fire({
                title: 'Oops...',
                text: 'Ajax call failed - Make sure that the API project is also running.',
                type: "error",
                icon: "error",
                showConfirmButton: false,
                showCancelButton: false
            });
        }
    });
}