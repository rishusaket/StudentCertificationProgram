$("#createFormId").validate({
    rules: {
        studentAddress: {
            required: true,
            maxlength:100
        },
        city: {
            required: true
            
        },
        state: {
            required: true,
        }
    },
    messages: {
        studentName: {
            required: "Please enter your Address",
            maxlength: "Required Limit is 100 words"
        },
        emailId: {
            required: "Please Enter your city",
            
        },
        phoneNumber: {
            required: "Please Enter your Phone Number",
            
        }
    }
});