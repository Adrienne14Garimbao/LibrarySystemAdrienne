// #region Department > Create or Edit
(function ($) {

    var _departmentAppService = abp.services.app.department;

    var l = abp.localization.getSource('LibrarySystemAdrienne'),
        _$form = $('#CreateDepartmentForm');

    var DepartmentHomePage = "/Departments";

    _$form.submit(function (e) {
        e.preventDefault();

        CreateOrEdit();
    });


    // #region CreateOrEdit() - For create and edit of departments
    function CreateOrEdit()
    {
        if (!_$form.valid()) {
            return;
        }
        var department = _$form.serializeFormToObject();

        if (department.Id != 0)
        {
            _departmentAppService.update(department).done(function () {
                redirectToDepartmentIndex();
            });
        }
        else
        {
            _departmentAppService.create(department).done(function () {
                redirectToDepartmentIndex();
            });
        }
    }

    // #endregion

    // #region Cancel Button
    $(document).on('click', '.cancel-button', function (e) {
        cancelAndReturn();
    });
    // #endregion

    // #region cancelAndReturn() - to cancel and go back in departments home page
    function cancelAndReturn()
    {
        abp.message.confirm('Are you sure you want to cancel?', 'Go Back')
            .then(function (confirmed) {
                if (confirmed) {
                    window.location.href = DepartmentHomePage;
                }
            });
    }
    // #endregion

    // #region redirectToDepartmentIndex() - to redirect in departments home page
    function redirectToDepartmentIndex() {
        abp.notify.info(l('Success'), 'Message');
        window.location.href = DepartmentHomePage;

    }
    // #endregion

})(jQuery);

// #endregion