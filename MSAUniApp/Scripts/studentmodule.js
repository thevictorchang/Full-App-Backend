var StudentModule = (function () {

    return {

        getCourses: function (callback) {
            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://contosouniversitythevictorchang.azurewebsites.net/api/Courses",
                success: function(data){
                    console.log(data);
                    callback(data);
                }
            });
        },

        addCourse: function (course, callback) {

            $.ajax({
                url: "http://contosouniversitythevictorchang.azurewebsites.net/api/Courses/",
                type: "POST",
                data: course,
                success: function (data, textStatus, jqXHR) {
                    callback();
                }
            });

        },

        getStudents: function (callback) {
             $.ajax({ 
                type: "GET",
                dataType: "json",
                // API url here
                url: "http://contosouniversitythevictorchang.azurewebsites.net/api/Students",
                success: function(data){        
                    console.log(data);
                    callback(data);
                }
             });
        },

        getStudentById: function (id, callback){
            
            $.ajax({ 
                type: "GET",
                dataType: "json",
                url: "http://contosouniversitythevictorchang.azurewebsites.net/api/Students/" + id,
                success: function(data){        
                    console.log(data);
                    callback(data);
                }
             });

        },

        addStudent: function (student, callback) {
             
             $.ajax({
                 url: "http://contosouniversitythevictorchang.azurewebsites.net/api/Students/",
                type: "POST",
                data : student,
                success: function(data, textStatus, jqXHR)
                {
                    callback();
                }
             });

        },

        updateStudent: function (studentid, student, callback){
            
            $.ajax({
                url: "http://contosouniversitythevictorchang.azurewebsites.net/api/Students/" + studentid,
                type: "PUT",
                data : student,
                success: function(data, textStatus, jqXHR)
                {
                    callback();
                }
             });
        },

        deleteStudent: function (studentid, callback) {
            
            $.ajax({ 
                type: "DELETE",
                dataType: "json",
                url: "http://contosouniversitythevictorchang.azurewebsites.net/api/Students/" + studentid,
                success: function(data){        
                    callback();
                }
             });
        }
    };

}());