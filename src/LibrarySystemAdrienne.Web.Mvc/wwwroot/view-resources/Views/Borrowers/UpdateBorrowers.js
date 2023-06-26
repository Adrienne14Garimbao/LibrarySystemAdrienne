// #region Borrowers > Update 
(function ($) {

    var _borrowerAppService = abp.services.app.borrower,
        _bookAppService = abp.services.app.book;

    var l = abp.localization.getSource('LibrarySystemAdrienne'),
        _$formUpdate = $('#UpdateForm'),
        _$formEdit = $('#EditForm');

    var BorrowerHomePage = "/Borrowers";

    // #region To format date into ISO Format
    var BorrowDate = new Date(),
        ExpectedReturnDate = new Date(),
        ReturnDate = new Date();

    ExpectedReturnDate.setDate(ExpectedReturnDate.getDate(BorrowDate) + 7);

    window.onload = function () {
        document.getElementById('BorrowDate').value = BorrowDate.toISOString().slice(0, 10);
        document.getElementById('ExpectedReturnDate').value = ExpectedReturnDate.toISOString().slice(0, 10);
    }
    // #endregion

    // #region submit
    _$formUpdate.submit(function (CatchError)
    {
        update();
        CatchError.preventDefault();
    });

    _$formEdit.submit(function (CatchError) {
        edit();
        CatchError.preventDefault();
    });

    // #endregion

    // #region update() - To update return date 
    function update()
    {
        
        if (!_$formUpdate.valid()) {
            return;
        }

        var borrower = _$formUpdate.serializeFormToObject();

        if (borrower.Id != 0) {

            document.getElementById('ReturnDate').value = ReturnDate.toISOString().slice(0, 10);

            if (borrower.ReturnDate == borrower.ExpectedReturnDate) {

                /*  Book returned on time  */
                _borrowerAppService.update(borrower).done(function (CatchError) {
                    _bookAppService.updateStatusOfBooks({ Id: borrower.BookId, }).done(function () {
                        abp.message.success('Nice! Book is returned on time.', 'Congratulations');
                        redirectToBorrowerIndex();
                        CatchError.preventDefault();

                    });
                });
            }
            else if (borrower.ReturnDate < borrower.ExpectedReturnDate && borrower.ReturnDate >= borrower.BorrowDate )
            {
                /* Book returned earlier than expected date */

                _borrowerAppService.update(borrower).done(function (CatchError) {
                    _bookAppService.updateStatusOfBooks({ Id: borrower.BookId, }).done(function () {

                        abp.message.success('Yey! Book is returned early.', 'Congratulations');
                        redirectToBorrowerIndex();
                        CatchError.preventDefault();
                    });
                });


            }
            else if (borrower.ReturnDate > borrower.ExpectedReturnDate)
            {
                /* Book returned late */
                _borrowerAppService.update(borrower).done(function CatchError() {
                    _bookAppService.updateStatusOfBooks({ Id: borrower.BookId, }).done(function () {

                        abp.message.success('Book is not returned on time', 'Congratulations');
                        redirectToBorrowerIndex();
                        CatchError.preventDefault();

                    });
                });
          
            }
            else
            {

                if (borrower.ReturnDate < borrower.BorrowDate) {

                    /* Invalid input date */
                    abp.message.error('Cannot return the book earlier than book borrowed date');
                }
            }

        }
    }
    // #endregion

    // #region edit() - To edit borrowers data
    function edit() {

        if (!_$formEdit.valid()) {
            return;
        }

        var borrower = _$formEdit.serializeFormToObject();

        if (borrower.Id != 0)
        {
            _borrowerAppService.update(borrower).done(function () {

                _bookAppService.updateStatusOfBooksForEdit({ Id: borrower.BookId, }).done(function () {
                    abp.message.success('Successfully Updated!', 'Congratulations');
                    redirectToBorrowerIndex();
                });
            
            });

        }
    }
    // #endregion edit

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
                    window.location.href = BorrowerHomePage;
                }
            });
    }
    // #endregion

    // #region redirectToBorrowerIndex() - to redirect in borrowers home page
    function redirectToBorrowerIndex(CatchError) {

        window.location.href = BorrowerHomePage;

    }
    // #endregion

})(jQuery);

// #endregion