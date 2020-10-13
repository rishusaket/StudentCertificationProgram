$("#createFormId").validate({
    rules: {
        secondarySchoolName: {
            required: true
            
        },
        seniorSecondarySchoolName: {
            required: true

        },
        state: {
            required: true,
        },
        collegePercentage: {
            required: true,
            range: [1,100]

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

        },
        collegePercentage: {
            required: "Please enter your Percentage",
            range: "Please enter in between 1 to 100"
        }
    }
});