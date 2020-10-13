//$(document).ready(function () {
    $("#createFormId").validate({
        rules: {
            studentName: {
                required: true
            },
            emailId: {
                required: true,
                pattern: "\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b",
            },
            phoneNumber: {
                required: true,
                maxlength: 10,
                minlength: 10
            }
        },
        messages: {
            studentName: {
                required: "Please enter you Name"
            },
            emailId: {
                required: "Please Enter your emailId",
                pattern: "Please enter a valid email address"
            },
            phoneNumber: {
                required: "Please Enter your Phone Number",
                maxlength: "Enter valid Phone Number",
                minlength: "Enter valid Phone Number"
            }
        }
    });
//});