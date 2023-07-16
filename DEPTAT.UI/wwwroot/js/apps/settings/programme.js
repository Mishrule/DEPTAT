$(document).ready(function () {
	//Create Year Group
	$('#updateProgramme').hide();
	$('#programmeId').hide();
	$('#saveProgramme').click(function () {
		
		var createProgramme = {
			'Name': $('#programmeName').val(),
			'Description': $('#description').val(),
			'DepartmentId': $('#departmentId').val()
		}

		

		$.ajax({
			url: $('#base_url').text() + '/Programme/CreateProgramme',
			contentType: "application/json",
			type: 'POST',

			data: JSON.stringify(createProgramme),

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
			$('#updateProgramme').show();
			$('#saveProgramme').hide();
			$.ajax({
				url: $('#base_url').text() + '/Programme/GetProgramme',
				type: 'GET',
				data: { Id: Id },

				success: function (response) {
					console.log(response.result)
					if (response.isSuccess) {
						$('#programmeId').val(response.result.id);
						$('#programmeName').val(response.result.name);
						$('#description').val(response.result.description);
						$('#departmentId').val(response.result.departmentId);
					}

				}
			})
		})
		
	}

	//Upate Year Group
	$('#updateProgramme').click(function () {

		var updateProgramme = {
			'Id': $('#programmeId').val(),
			'Name': $('#programmeName').val(),
			'Description': $('#description').val(),
			'DepartmentId': $('#departmentId').val()
		}


		$.ajax({
			url: $('#base_url').text() + '/Programme/UpdateProgramme',
			contentType: "application/json",
			type: 'PUT',

			data: JSON.stringify(updateProgramme),

			success: function (response) {
				if (response.isSuccess) {
					showNotificationSuccessMessage(response.message, "Success");
				} else {
					showNotificationErrorMessage("Failed", response.message, "error");
				}
				
			}
			
		})
	})

	//Delect Programme
	DeleteProgramme();
function DeleteProgramme() {
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
							url: $('#base_url').text() + '/Programme/DeleteProgramme',
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