﻿// #region Borrower > Index
(function ($) {

    var _borrowerAppService = abp.services.app.borrower,
        _bookAppService = abp.services.app.book;  

    var l = abp.localization.getSource('LibrarySystemAdrienne');

    var BorrowerHomePage = "/Borrowers",
        BorrowerUpdatePage = "/Borrowers/UpdateBorrowers/";


    // #region Return Borrower Button
    $(document).on('click', '.btn-return', function (CatchError) {
        var borrowerId = $(this).attr("data-borrower-id");

        window.location.href = BorrowerUpdatePage + borrowerId;
        CatchError.preventDefault();
    });
    // #endregion


    // #region Delete Borrower Button
    $(document).on('click', '.delete-borrower', function (CatchError) {

        var borrowerId = $(this).attr("data-borrower-id"),
            borrowerName = $(this).attr('data-borrower-name'),
            bookName = $(this).attr('data-book-name'),
            bookId = $(this).attr('data-book-id');

        DeleteBorrower(borrowerId, borrowerName, bookId, bookName);
        CatchError.preventDefault();
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
                        //borrower.bookIsBorrowed = true;
                        _bookAppService.updateStatusOfBooks({
                            id: bookId,
                        }).done(() => {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            window.location.href = BorrowerHomePage;
                        });
                    });
                }
            }
        );
    }
    // #endregion


})(jQuery);

// #endregion