$(document).ready(function () {
	//Create Year Group
	$('#updateCourse').hide();
	$('#courseId').hide();
	$('#saveCourse').click(function () {
		
		var createCourse = {
			'Name': $('#courseName').val(),
			'Code': $('#courseCode').val(),
			'Description': $('#description').val(),
			'ProgrammeId': $('#programmeId').val()
		}

		

		$.ajax({
			url: $('#base_url').text() + '/Course/CreateCourse',
			contentType: "application/json",
			type: 'POST',

			data: JSON.stringify(createCourse),

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
			$('#updateCourse').show();
			$('#saveCourse').hide();
			$.ajax({
				url: $('#base_url').text() + '/Course/GetCourse',
				type: 'GET',
				data: { Id: Id },

				success: function (response) {
					console.log(response.result)
					if (response.isSuccess) {
						$('#courseId').val(response.result.id);
						$('#courseName').val(response.result.name);
						$('#courseCode').val(response.result.code);
						$('#description').val(response.result.description);
						$('#programmedId').val(response.result.programmedId);
					}

				}
			})
		})
		
	}

	//Upate Year Group
	$('#updateCourse').click(function () {

		var updateCourse = {
			'Id': $('#courseId').val(),
			'Name': $('#courseName').val(),
			'Code': $('#courseCode').val(),
			'Description': $('#description').val(),
			'ProgrammeId': $('#programmeId').val()
		}


		$.ajax({
			url: $('#base_url').text() + '/Course/UpdateCourse',
			contentType: "application/json",
			type: 'PUT',

			data: JSON.stringify(updateCourse),

			success: function (response) {
				if (response.isSuccess) {
					showNotificationSuccessMessage(response.message, "Success");
				} else {
					showNotificationErrorMessage("Failed", response.message, "error");
				}
				
			}
			
		})
	})

	//Delect Course
	DeleteCourse();
function DeleteCourse() {
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
							url: $('#base_url').text() + '/Course/DeleteCourse',
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