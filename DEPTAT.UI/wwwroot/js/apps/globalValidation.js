function validateFields(fieldElement, labelElement) {
	if ($(fieldElement).val() === "") {
		$(labelElement).text("* required");
		$(labelElement).addClass("text-danger");
		return true;

	} else {
		$(labelElement).text("");
		$(labelElement).removeClass("text-danger");
	}

}