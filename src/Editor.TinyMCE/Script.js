tinymce.init({
	selector: '#editor',
	toolbar: false,
	menubar: false,
	branding: false,
	setup: function(editor) {
		if (window.external) {
			editor.on('contextmenu', function(e) {
				e.stopPropagation();
				e.preventDefault();
				window.external.FireContextMenu();
				return false;
			});
			editor.on('init', function(e) {
				window.external.FireInit();
			});
			editor.on('nodechange', function (e) {
				window.external.FireSelectionChanged();
			});
		}
	}
});

function GetData() {
	return tinyMCE.activeEditor.getContent();
}

function SetData(value) {
	tinyMCE.activeEditor.setContent(value);
}

function QueryCommandState(command) {
	return tinyMCE.activeEditor.queryCommandState(command) || false;
}

function ExecCommand(command, arg) {
	return tinyMCE.activeEditor.execCommand(command, false, arg) || false;
}

function IsDirty() {
	return tinyMCE.activeEditor.isDirty();
}

function SetDirty(value) {
	tinyMCE.activeEditor.setDirty(value);
}

function Undo() {
	tinyMCE.activeEditor.undoManager.undo();
}

function Redo() {
	tinyMCE.activeEditor.undoManager.redo();
}

function HasUndo() {
	return tinyMCE.activeEditor.undoManager.hasUndo();
}

function HasRedo() {
	return tinyMCE.activeEditor.undoManager.hasRedo();
}

function ApplyFormat(format) {
	tinyMCE.activeEditor.formatter.apply(format);
}

function GetSelectedNode() {
	var node = tinyMCE.activeEditor.selection.getNode();
	var html = node.outerHTML;
	
	if (node.childNodes.length == 0 && html.indexOf('/>', html.length - 2) === -1) {
		html = html.substr(0, html.length - 1);
		html += '/>';
	}

	return html;
}

function DeleteSelectedNode() {
	tinyMCE.activeEditor.dom.remove(tinyMCE.activeEditor.selection.getNode());
}