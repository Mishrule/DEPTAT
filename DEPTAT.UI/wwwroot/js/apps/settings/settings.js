$(document).ready(function () {
	toastr.success('Have fun storming the castle!', 'Miracle Max Says', { timeOut: 5000 });
	showNotificationMessage("Success", "response.message", "success");
	$('#saveYearGroup').click(function () {

		var createYearGroup = {
			'Name':$('#yearGroup').val(),
			'Description' : $('#description').val()
		}

		console.log(createYearGroup);

		$.ajax({
			url: $('#base_url').text() + '/Settings/CreateYearGroups',
			contentType: "application/json",
			type: 'POST',

			data: JSON.stringify(createYearGroup),

			success: function (response) {
				//if (response.isComplete) {
				//	showNotificationMessage("Success", response.message, "success");

				//} else {
				//	var errorMessage = response.message;
				//	if (!errorMessage)
				//		errorMessage = response.detailedMessage;

				//	showNotificationMessage("Error", errorMessage, "error");
				//}
			}
		})

		//$.ajax({
		//	type: "POST",
		//	url: "/Settings/CreateYearGroup",
		//	data: createYearGroup,
		//	success: function (response) {
		//		//if (response.isComplete) {
		//		//	showNotificationMessage("Success", response.message, "success");

		//		//} else {
		//		//	var errorMessage = response.message;
		//		//	if (!errorMessage)
		//		//		errorMessage = response.detailedMessage;

		//		//	showNotificationMessage("Error", errorMessage, "error");
		//		//}
		//	},
		//	//complete: function () {
		//	//	off();
		//	//},
		//	//error: errorResponse
		//});
	})
});