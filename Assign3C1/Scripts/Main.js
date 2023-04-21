
window.onload = () => {


	var AddTeacherForm = document.forms.createForm;
    console.log(createForm);



    // ---------------- A teacher Object to store values from form and pass through our API Controller ----------------



    AddTeacherForm.addEventListener("submit", checkValidation);


    function checkValidation(){
        // ------------defining variables-----------

        var firstName = AddTeacherForm.teacherfname;
        var lastName = AddTeacherForm.teacherlname;
        var employee_number = AddTeacherForm.employeenumber;
        var salary = AddTeacherForm.salary;
        var hiredate = AddTeacherForm.hiredate;
 


        //  -----------------  first Name ---------------
        if (firstName.value == "") {
            firstName.style.background = "red";
            firstName.focus();
            return false;
        } else {
            firstName.style.background = "white";
            newTeacher.teacherfname = firstName.value;
        }


        //  -----------------  last Name ---------------
        if (lastName.value == "") {
            lastName.style.background = "red";
            lastName.focus();
            return false;
        } else {
            lastName.style.background = "white";
            newTeacher.teacherlname = lastName.value;
        }


        //  -----------------  employee_number ---------------
        if (employee_number.value == "") {
            employee_number.style.background = "red";
            employee_number.focus();
            return false;
        } else {
            employee_number.style.background = "white";
            newTeacher.employeenumber = employee_number.value;
        }

        //  -----------------  salary ---------------
        if (salary.value == "") {
            salary.style.background = "red";
            salary.focus();
            return false;
        } else {
            salary.style.background = "white";
            newTeacher.salary = salary.value;
        }


        //  -----------------  hiredate ---------------
        if (hiredate.value == "") {
            hiredate.style.background = "red";
            hiredate.focus();
            return false;
        } else {
            hiredate.style.background = "white";
            newTeacher.hiredate = hiredate.value;
        }

        console.log("ff");

        return false;
    }


    ///  Addding Teacher Through AJAX Request

    function addTeacher() {
        var AddTeacherForm = document.forms.createForm;

        var firstName = AddTeacherForm.teacherfname.value;
        var lastName = AddTeacherForm.teacherlname.value;
        var employee_number = AddTeacherForm.employeenumber.value;
        var salary = AddTeacherForm.salary.value;
        var hiredate = AddTeacherForm.hiredate.value;

        var newTeacher = {
            teacherfname: firstName,
            teacherlname: lastName,
            employeenumber: employee_number,
            salary: salary,
            hiredate: hiredate,
        };

        var url = "https://localhost:44353/api/TeacherData/addTeacherData/" + newTeacher;

        var req = new XMLHttpRequest();
        req.open("POST", url, true);
        req.setRequestHeader("Content-Type", "application/json");


        req.onreadystatechange = () => {
            if (req.readyState == 4 && req.status == 200) {
                
            }
        }
        req.send(JSON.stringify(newTeacher));
    }



    /// Updating Teacher Through AJAX request


    function UpdateTeacher() {
        var UpdateTeacherForm = document.forms.updateForm;

        var firstName = UpdateTeacherForm.teacherfname.value;
        var lastName = UpdateTeacherForm.teacherlname.value;
        var employee_number = UpdateTeacherForm.employeenumber.value;
        var salary = UpdateTeacherForm.salary.value;
        var hiredate = UpdateTeacherForm.hiredate.value;

        // initializing object and assigning data
        var TeacherData = {
            teacherfname: firstName,
            teacherlname: lastName,
            employeenumber: employee_number,
            salary: salary,
            hiredate: hiredate,
        };
        // Api url for update controller function
        var url = "https://localhost:44353/api/TeacherData/UpdateTeacher/" + TeacherData;

        var req = new XMLHttpRequest();
        req.open("POST", url, true);
        req.setRequestHeader("Content-Type", "application/json");


        req.onreadystatechange = () => {
            if (req.readyState == 4 && req.status == 200) {

            }
        }
        req.send(JSON.stringify(TeacherData));
    }



    // Delete Teacher using AJAX
    
    function DeleteTeacher(teacherid) {
        var url = "https://localhost:44353/api/TeacherData/deleteTeacher/" + teacherid;
        var req = new XMLHttpRequest();
        req.open("POST", url, true);
        req.setRequestHeader("Content-Type", "application/json");


        req.onreadystatechange = () => {
            if (req.readyState == 4 && req.status == 200) {

            }
        }
    }
        
}
