function setupSummernote(summerNoteElement) {
    summerNoteElement.summernote(
        {
            height: 300, //set editable area's height http://hackerwins.github.io/summernote/features.html
            codemirror: {
                // codemirror options
                theme: 'monokai'
            },
            toolbar: [
                //[groupname, [button list]]
                ['style', ['bold', 'italic', 'underline', 'clear', 'strikethrough']],
                ['fontname', ['fontname']],
                ['color', ['color']],
                ['para', ['ul', 'ol', 'paragraph']],
                ['table', ['table']],
                ['insert', ['picture', 'link', 'video']],
                ['misc', ['fullscreen', 'codeview', 'undo', 'redo']]

            ],
            callbacks: {
                onImageUpload: function (image) {
                    uploadImage(summerNoteElement, image[0]);
                }
            },
            onChange: function (contents, $editable) {
                summerNoteElement.val(summerNoteElement.code());
            }
        });
}

function uploadImage(editor, image) {
    var data = new FormData();
    data.append("SummernotePhoto", image);
    var url = "/api/Upload/UploadSummernotePhoto";
    $.ajax({
        data: data,
        type: "POST",
        url: url,
        cache: false,
        contentType: false,
        processData: false,
        success: function (url) {
            //var image = $('<img>').attr('src', url);
            //$('#summernote').summernote("insertNode", image[0]);
            editor.summernote('pasteHTML', "<img src='" + url + "' alt='' />");
        },
        error: function (data) {
            alert(data);
        }
    });
}