// This file is connected to the project via Shared/_Layout.cshtml

function UpdateTeacher(TeacherId) {

	//goal: send a request which looks like this:
	//POST : http://localhost:51326/api/TeacherData/UpdateTeacher/{id}
	//with POST data of authorname, bio, email, etc.

	var URL = "http://localhost:51326/api/TeacherData/UpdateTeacher/" + TeacherId;

	var rq = new XMLHttpRequest();

	var TeacherFname = document.getElementById('TeacherFname').value;
	var TeacherLname = document.getElementById('TeacherLname').value;
	var TeacherENumber = document.getElementById('EmployeeNumber').value;
	var TeacherHDate = document.getElementById('HireDate').value;
	var TeacherSalary = document.getElementById('Salary').value;



	var TeacherData = {
		"TeacherFname": TeacherFname,
		"TeacherLname": TeacherLname,
		"EmployeeNumber": TeacherENumber,
		"HireDate": TeacherHDate,
		"Salary":TeacherSalary
	};


	rq.open("POST", URL, true);
	rq.setRequestHeader("Content-Type", "application/json");
	rq.onreadystatechange = function () {
		//ready state should be 4 AND status should be 200
		if (rq.readyState == 4 && rq.status == 200) {
			//request is successful and the request is finished

			//nothing to render, the method returns nothing.


		}

	}
	//POST information sent through the .send() method
	rq.send(JSON.stringify(TeacherData));

}