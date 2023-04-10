
window.onload = () => {


	var createForm = document.forms.createForm;
    console.log(createForm);

	var newTeacher = {
		teacherfname: "",
		teacherlname: "",
		employeenumber: "",
		salary: "",
		hiredate: "",
	};

    createForm.onsubmit = processform;
    function processform(){
        // ------------defining variables-----------

        var firstName = myForm.teacherfname;
        var lastName = myForm.teacherlname;
        var employee_number = myForm.employeenumber;
        var salary = myForm.salary;
        var hiredate = myForm.hiredate;
 


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







}
