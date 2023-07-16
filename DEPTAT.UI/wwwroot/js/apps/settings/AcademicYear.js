$(document).ready(function () {
	//Create Year Group
	$('#updateAcademicYear').hide();
	$('#academicYearId').hide();
	$('#saveAcademicYear').click(function () {
		
		var createAcademicYear= {
			'Name': $('#academicYear').val(),
			'Description' : $('#description').val()
		}


		$.ajax({
			url: $('#base_url').text() + '/AcademicYear/CreateAcademicYear',
			contentType: "application/json",
			type: 'Post',
			data: JSON.stringify(createAcademicYear),

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
			$('#updateAcademicYear').show();
			$('#saveAcademicYear').hide();
			$.ajax({
				url: $('#base_url').text() + '/AcademicYear/GetAcademicYear',
				type: 'GET',
				data: { Id: Id },

				success: function (response) {
					console.log(response.result)
					if (response.isSuccess) {
						$('#academicYearId').val(response.result.id);
						$('#academicYear').val(response.result.name);
						$('#description').val(response.result.description);
					}

				}
			})
		})
		
	}

	//Upate Year Group
	$('#updateAcademicYear').click(function () {

		var updateYearGroup = {
			'Id': $('#academicYearId').val(),
			'Name': $('#academicYear').val(),
			'Description': $('#description').val()
		}


		$.ajax({
			url: $('#base_url').text() + '/AcademicYear/UpdateAcademicYear',
			contentType: "application/json",
			type: 'PUT',

			data: JSON.stringify(updateYearGroup),

			success: function (response) {
				if (response.isSuccess) {
					showNotificationSuccessMessage(response.message, "Success");
				} else {
					showNotificationErrorMessage("Failed", response.message, "error");
				}
				
			}
			
		})
	})

	//Delect YearGroup
	DeleteYearGroup();
	function DeleteYearGroup() {
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
							url: $('#base_url').text() + '/AcademicYear/DeleteAcademicYear',
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
		})

	}

})