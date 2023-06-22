// #region Borrowers > Create 
(function ($) {

    var _borrowerAppService = abp.services.app.borrower,
        _bookAppService = abp.services.app.book;        ;

    var l = abp.localization.getSource('LibrarySystemAdrienne'),
        _$form = $('#CreateBorrowerForm');

    var BorrowerHomePage = "/Borrowers";

    // #region To format date into ISO Format
    var BorrowDate = new Date(),
        ExpectedReturnDate = new Date()

    ExpectedReturnDate.setDate(ExpectedReturnDate.getDate(BorrowDate) + 7);

    window.onload = function () {
        document.getElementById('BorrowDate').value = BorrowDate.toISOString().slice(0, 10);
        document.getElementById('ExpectedReturnDate').value = ExpectedReturnDate.toISOString().slice(0, 10);
    }
    // #endregion


    _$form.submit(function (e) {
        e.preventDefault();

        save();
    });


    // #region save() - To add of borrowers
    function save() {

        if (!_$form.valid()) {
            return;
        }
        var borrower = _$form.serializeFormToObject();

        abp.message.confirm('Are you sure you want to save?', 'Save')
            .then(function (confirmed) {
                if (confirmed)
                {

                    if (borrower.Id == 0) {
                        _borrowerAppService.create(borrower).done(function () {
                            borrower.ReturnDate = null;
                            _bookAppService.updateStatusOfBooks({
                                Id: borrower.BookId,
                            }).done(function () {
                                redirectToBorrowerIndex();
                            });
                        });
                    }
                }
            });
 
    }

    // #endregion

    // #region Cancel Button
    $(document).on('click', '.cancel-button', function (e) {
        cancelAndReturn();
    });
    // #endregion

    // #region cancelAndReturn() - to cancel and go back in borrowers home page
    function cancelAndReturn() {
        abp.message.confirm('Are you sure you want to cancel?', 'Go Back')
            .then(function (confirmed) {
                if (confirmed) {
                    redirectToBorrowerIndex();
                }
            });
    }
    // #endregion

    // #region redirectToDepartmentIndex() - to redirect in borrowers home page
    function redirectToBorrowerIndex() {
        abp.notify.info(l('Success'), 'Message');
        window.location.href = BorrowerHomePage;

    }
    // #endregion

})(jQuery);

// #endregion