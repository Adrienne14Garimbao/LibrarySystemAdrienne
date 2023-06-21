// #region Book > Index
(function ($) {

    var _bookAppService = abp.services.app.book;

    var l = abp.localization.getSource('LibrarySystemAdrienne');

    var BookHomePage = "/Books",
        BookEditPage = "/Books/CreateOrEditBook/";

    // #region Edit Book Button
    $(document).on('click', '.edit-book', function (e) {
        var bookId = $(this).attr("data-book-id");

        e.preventDefault();
        window.location.href = BookEditPage + bookId;

    });
    // #endregion


    // #region Delete Book Button
    $(document).on('click', '.delete-book', function () {
        var bookId = $(this).attr("data-book-id");
        var bookName = $(this).attr('data-book-name');

        DeleteBook(bookId, bookName);
    });
    // #endregion


    // #region DeleteBook() - To delete book records
    function DeleteBook(bookId, bookName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'), bookName), l('Delete'),

            (isConfirmed) => {
                if (isConfirmed) {
                    _bookAppService.delete({
                        id: bookId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        window.location.href = BookHomePage;

                    });
                }
            }
        );
    }
    // #endregion


})(jQuery);

// #endregion