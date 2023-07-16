$(document).ready(function () {
	//Create Year Group
	$('#updateDepartment').hide();
	$('#departmentId').hide();
	$('#saveDepartment').click(function () {
		
		var createDepartment = {
			'Name': $('#departmentName').val(),
			'Description': $('#description').val(),
			'FacultyId': $('#facultyId').val()
		}

		

		$.ajax({
			url: $('#base_url').text() + '/Department/CreateDepartment',
			contentType: "application/json",
			type: 'POST',

			data: JSON.stringify(createDepartment),

			success: function (response) {
				if (response.isSuccess) {
					showNotificationSuccessMessage(response.message, "Success");
					//location.reload();
				} else {
					showNotificationErrorMessage("Failed", response.message, "error");
					//location.reload();
				}
				
			}
		})
		
	})


	//Edit Year Group
	EditYearGroup()
	function EditYearGroup() {
		$(document).on('click', '.edit', function () {
			var Id = $(this).attr('id');
			$('#updateDepartment').show();
			$('#saveDepartment').hide();
			$.ajax({
				url: $('#base_url').text() + '/Department/GetDepartment',
				type: 'GET',
				data: { Id: Id },

				success: function (response) {
					console.log(response.result)
					if (response.isSuccess) {
						$('#departmentId').val(response.result.id);
						$('#departmentName').val(response.result.name);
						$('#description').val(response.result.description);
						$('#facultyId').val(response.result.facultyId);
					}

				}
			})
		})
		
	}

	//Upate Year Group
	$('#updateDepartment').click(function () {

		var updateDepartment = {
			'Id': $('#departmentId').val(),
			'Name': $('#departmentName').val(),
			'Description': $('#description').val(),
			'FacultyId': $('#facultyId').val()
		}


		$.ajax({
			url: $('#base_url').text() + '/Department/UpdateDepartment',
			contentType: "application/json",
			type: 'PUT',

			data: JSON.stringify(updateDepartment),

			success: function (response) {
				if (response.isSuccess) {
					showNotificationSuccessMessage(response.message, "Success");
				} else {
					showNotificationErrorMessage("Failed", response.message, "error");
				}
				
			}
			
		})
	})

	//Delect Department
	DeleteDepartment();
function DeleteDepartment() {
		$(document).on('click', '.del', function () {
			var Id = $(this).attr('id');
			
			swal("Are you sure?", {
				dangerMode: true,
				buttons: true,
			})
				.then((willConfirm) => {
					if (willConfirm) {
						// User clicked "OK" or confirmed the action
						// Add your code here for the action to be taken

						$.ajax({
							url: $('#base_url').text() + '/Department/DeleteDepartment',
							type: 'DELETE',
								data: { Id: Id },

						success: function (response) {
							if (response.isSuccess) {
								showNotificationSuccessMessage(response.message, "Success");
							} else {
								showNotificationErrorMessage("Failed", response.message, "error");
							}

						}
					});
					} else {
						// User clicked "Cancel" or dismissed the dialog
						// Add your code here for the action to be taken
						console.log("User cancelled the action.");
					}
				});
			//location.reload();
		})

	}

})