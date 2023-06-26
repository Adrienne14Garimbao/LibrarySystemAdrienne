// #region Borrower > Index
(function ($) {

    var _borrowerAppService = abp.services.app.borrower,
        _bookAppService = abp.services.app.book;  

    var l = abp.localization.getSource('LibrarySystemAdrienne');

    var BorrowerHomePage = "/Borrowers",
        BorrowerUpdatePage = "/Borrowers/UpdateBorrowers/",
        BorrowerEditPage = "/Borrowers/EditBorrowers/";


    // #region Return Borrower Button
    $(document).on('click', '.btn-return', function () {
        var borrowerId = $(this).attr("data-borrower-id");

        window.location.href = BorrowerUpdatePage + borrowerId;
    });
    // #endregion

    // #region Return Borrower Button
    $(document).on('click', '.btn-edit', function () {
        var borrowerId = $(this).attr("data-borrower-id");

        window.location.href = BorrowerEditPage + borrowerId;
    });
    // #endregion



    // #region Delete Borrower Button
    $(document).on('click', '.delete-borrower', function () {

        var borrowerId = $(this).attr("data-borrower-id"),
            borrowerName = $(this).attr('data-borrower-name'),
            bookName = $(this).attr('data-book-name'),
            bookId = $(this).attr('data-book-id');

        DeleteBorrower(borrowerId, borrowerName, bookId, bookName);



    });
    // #endregion


    // #region DeleteBorrower() - To delete borrower records
    function DeleteBorrower(borrowerId, borrowerName, bookId, bookName) {
        abp.message.confirm(
            abp.utils.formatString(l('AreYouSureWantToRemoveThisBorrower'), borrowerName, bookName), l('Delete'),

            (isConfirmed) => {
                if (isConfirmed) {
                    _borrowerAppService.delete({
                        id: borrowerId
                    }).done(() => {
                        _bookAppService.updateStatusOfBooks({
                            id: bookId,
                        }).done(() => {

                            abp.message.success(l('SuccessfullyDeleted'), 'Congratulations');
                            redirectToBorrowerIndex();
                        });
                    });
                }
            }
        );
    }
    // #endregion

    // #region redirectToBorrowerIndex() - to redirect in borrowers home page
    function redirectToBorrowerIndex(CatchError) {

        window.location.href = BorrowerHomePage;

        CatchError.preventDefault();

    }
    // #endregion



})(jQuery);

// #endregion