showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    })
};


jQueryAjaxPost = form => {
    try {
        $ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-alll').html(res.html);
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                   /* $.notify('submitted successfully', { globalPosition: 'top center', className='success' })*/
                }
                else {
                    $('#form-modal .modal-body').html('');

                }
            },
            error: function (err) {
                console.log(err);
            }
        })
    } catch (e) {
        console.log(e);
    }
    //khong cho submit form
    return false;
};



jQueryAjaxDelete = form => {
    if (confirm('Bạn có thật sự muốn xóa?')) {
        try {
            $ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#view-alll').html(res.html);
                   /* $.notify('submitted successfully', { globalPosition: 'top center', className='success' })*/

                },
                error: function (err) {
                    console.log(err);
                }
            })
        } catch (e) {
            console.log(e);
        }
    }
    return false;
};