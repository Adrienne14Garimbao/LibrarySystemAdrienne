// #region Students > Index
(function ($) {

    var _studentAppService = abp.services.app.student;

    var l = abp.localization.getSource('LibrarySystemAdrienne'),
        _$form = $('#SearchForm');

    var StudentHomePage = "/Students",
        StudentEditPage = "/Students/CreateOrEditStudent/";

    // #region Edit Student Button 
    $(document).on('click', '.edit-student', function (CatchError) {
        var studentId = $(this).attr("data-student-id");

        window.location.href = StudentEditPage + studentId;
        CatchError.preventDefault();

    });
    // #endregion


    // #region Delete Student Button
    $(document).on('click', '.delete-student', function () {
        var studentId = $(this).attr("data-student-id");
        var studentName = $(this).attr('data-student-name');

        DeleteStudent(studentId, studentName);
    });
    // #endregion


    // #region DeleteStudent() - To delete student records
    function DeleteStudent(studentId, studentName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'), studentName), l('Delete'),

            (isConfirmed) => {
                if (isConfirmed) {
                    _studentAppService.delete({
                        id: studentId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        window.location.href = StudentHomePage;

                    });
                }
            }
        );
    }
    // #endregion


})(jQuery);

// #endregion