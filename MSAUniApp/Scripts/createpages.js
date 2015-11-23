document.addEventListener("DOMContentLoaded", function () {
    setupCourseSubmit();
    setupReturn();
});

function setupCourseSubmit() {

    //Creating student from form parameters

    var form = document.forms.create;
    // Need to add our own custom event for form submission
    form.onsubmit = function (e) {
        // ... and prevent the default action from occuring
        e.preventDefault();
        
        /*
        //Creating student from form parameters
        var newStudent = {
            // Access the data in the fields with .value 
            lastname: document.getElementById("LastNameinput").value,
            firstmidname: document.getElementById("FirstNameinput").value,
            enrollmentdate: document.getElementById("EnrollmentDateinput").value
        }
        */

        var newCourse = {
            title: document.getElementById("titleinput").value,
            credits: document.getElementById("creditinput").value,
            courseid: document.getElementById("courseidinput").value
        }
        
        // Take me back home when done!
        StudentModule.addCourse(newCourse, function () {
            window.location.href = "index.html";
        });
    }

};

// Add event listener, cancel button will take you back to home page
function setupReturn() {
    document.getElementById('btncancel').addEventListener('click', function () {
        window.location.href = "index.html";
    });
}