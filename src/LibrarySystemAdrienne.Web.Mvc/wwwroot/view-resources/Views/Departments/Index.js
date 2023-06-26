// #region Department > Index
(function ($) {

    var _departmentAppService = abp.services.app.department;

    var l = abp.localization.getSource('LibrarySystemAdrienne');

    var DepartmentHomePage = "/Departments",
        DepartmentEditPage = "/Departments/CreateOrEditDepartment/";

    // #region Edit Department Button 
    $(document).on('click', '.edit-department', function (CatchError) {
        var departmentId = $(this).attr("data-department-id");

        window.location.href = DepartmentEditPage + departmentId;
        CatchError.preventDefault();

    });
    // #endregion


    // #region Delete Department Button
    $(document).on('click', '.delete-department', function () {
        var departmentId = $(this).attr("data-department-id");
        var departmentName = $(this).attr('data-department-name');

        DeleteDepartment(departmentId, departmentName);
    });
    // #endregion


    // #region DeleteDepartment() - To delete department records
    function DeleteDepartment(departmentId, departmentName)
    {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'), departmentName), l('Delete'),

            (isConfirmed) => {
                if (isConfirmed)
                {
                    _departmentAppService.delete({
                        id: departmentId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        window.location.href = DepartmentHomePage;

                    });
                }
            }
        );
    }
    // #endregion


})(jQuery);

// #endregion