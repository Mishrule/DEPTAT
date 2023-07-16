$(document).ready(function () {
	//Create Year Group
	$('#updateYearGroup').hide();
	$('#yearGroupId').hide();
	$('#saveYearGroup').click(function () {
		
		var createYearGroup = {
			'Name':$('#yearGroup').val(),
			'Description' : $('#description').val()
		}

		

		$.ajax({
			url: $('#base_url').text() + '/YearGroup/CreateYearGroups',
			contentType: "application/json",
			type: 'POST',

			data: JSON.stringify(createYearGroup),

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
			$('#updateYearGroup').show();
			$('#saveYearGroup').hide();
			$.ajax({
				url: $('#base_url').text() + '/YearGroup/GetYearGroup',
				type: 'GET',
				data: { Id: Id },

				success: function (response) {
					console.log(response.result)
					if (response.isSuccess) {
						$('#yearGroupId').val(response.result.id);
						$('#yearGroup').val(response.result.name);
						$('#description').val(response.result.description);
					}

				}
			})
		})
		
	}

	//Upate Year Group
	$('#updateYearGroup').click(function () {

		var updateYearGroup = {
			'Id': $('#yearGroupId').val(),
			'Name': $('#yearGroup').val(),
			'Description': $('#description').val()
		}


		$.ajax({
			url: $('#base_url').text() + '/YearGroup/UpdateYearGroups',
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
							url: $('#base_url').text() + '/YearGroup/DeleteYearGroup',
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