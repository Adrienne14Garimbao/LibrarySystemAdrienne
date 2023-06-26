// #region Student > Create or Edit
(function ($) {

    var _studentAppService = abp.services.app.student;

    var l = abp.localization.getSource('LibrarySystemAdrienne'),
        _$form = $('#CreateStudentForm');

    var StudentHomePage = "/Students";

    _$form.submit(function (CatchError) {
        
        CreateOrEdit();
        CatchError.preventDefault();
    });


    // #region CreateOrEdit() - For create and edit of students
    function CreateOrEdit() {
        if (!_$form.valid()) {
            return;
        }
        var student = _$form.serializeFormToObject();

        if (student.Id != 0) {
            _studentAppService.update(student).done(function () {
                redirectToStudentIndex();
            });
        }
        else {
            _studentAppService.create(student).done(function () {
                redirectToStudentIndex();
            });
        }
    }

    // #endregion

    // #region Cancel Button
    $(document).on('click', '.cancel-button', function (e) {
        cancelAndReturn();
    });
    // #endregion

    // #region cancelAndReturn() - to cancel and go back in students home page
    function cancelAndReturn() {
        abp.message.confirm('Are you sure you want to cancel?', 'Go Back')
            .then(function (confirmed) {
                if (confirmed) {
                    window.location.href = StudentHomePage;
                }
            });
    }
    // #endregion

    // #region redirectToDepartmentIndex() - to redirect in students home page
    function redirectToStudentIndex() {
        abp.notify.info(l('Success'), 'Message');
        window.location.href = StudentHomePage;

    }
    // #endregion

})(jQuery);

// #endregion