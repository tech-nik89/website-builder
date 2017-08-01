(function() {

	$('form.form-designer').on('submit', function(e) {
		e.preventDefault();
		
		var form = $(this);
		var url = form.attr('action');
		var data = form.serialize();
		var message = form.attr('data-message');

		$.post(url, data, function(result) { });
		form.empty();

		if (message) {
			var p = $('<p />');
			p.text(message);
			form.append(p);
		}

		return false;
	});

})();