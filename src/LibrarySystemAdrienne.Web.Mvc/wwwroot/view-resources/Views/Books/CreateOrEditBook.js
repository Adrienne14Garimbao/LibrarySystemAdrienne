// #region Books > Create or Edit
(function ($) {

    var _bookAppService = abp.services.app.book;

    var l = abp.localization.getSource('LibrarySystemAdrienne'),
        _$form = $('#CreateBookForm');

    var BookHomePage = "/Books";

    _$form.submit(function (CatchError) {

        CreateOrEdit();
        CatchError.preventDefault();
    });


    // #region CreateOrEdit() - For create and edit of books
    function CreateOrEdit() {
        if (!_$form.valid()) {
            return;
        }
        var book = _$form.serializeFormToObject();

        if (book.Id != 0) {
            _bookAppService.update(book).done(function () {
                redirectToBookIndex();
            });
        }
        else {
            _bookAppService.create(book).done(function () {
                redirectToBookIndex();
            });
        }
    }

    // #endregion

    // #region Cancel Button
    $(document).on('click', '.cancel-button', function (e) {
        cancelAndReturn();
    });
    // #endregion

    // #region cancelAndReturn() - to cancel and go back in books home page
    function cancelAndReturn() {
        abp.message.confirm('Are you sure you want to cancel?', 'Go Back')
            .then(function (confirmed) {
                if (confirmed) {
                    window.location.href = BookHomePage;
                }
            });
    }
    // #endregion

    // #region redirectToDepartmentIndex() - to redirect in books home page
    function redirectToBookIndex() {
        abp.notify.info(l('Success'), 'Message');
        window.location.href = BookHomePage;

    }
    // #endregion

})(jQuery);

// #endregion