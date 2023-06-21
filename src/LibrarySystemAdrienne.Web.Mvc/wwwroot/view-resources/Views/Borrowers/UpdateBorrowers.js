// #region Borrowers > Update 
(function ($) {

    var _borrowerAppService = abp.services.app.borrower,
        _bookAppService = abp.services.app.book;

    var l = abp.localization.getSource('LibrarySystemAdrienne'),
        _$form = $('#frmReturn');

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


    _$form.submit(function (tryAndCatch)
    {
        tryAndCatch.preventDefault();
        update();
    });

    // #region update() - To update data and return books
    function update()
    {
        document.getElementById('ReturnDate').value = ReturnDate.toISOString().slice(0, 10);
        if (!_$form.valid()) {
            return;
        }

        var borrower = _$form.serializeFormToObject();

        if (borrower.Id != 0) {
            
            if (borrower.ExpectedReturnDate < borrower.ReturnDate)
            {
                /*  Late */
                _borrowerAppService.update(borrower).done(function () {
                    _bookAppService.updateStatusOfBooks({ Id: borrower.BookId, }).done(function ()
                    {
                        alert("Book not returned on time");
                        redirectToBorrowerIndex();
                    });
                });
            }
            else if (borrower.ReturnDate < borrower.BorrowDate)
            {
                alert("Cannot return book earlier than book borrowed date");
                /* Too early */
            }
            else
            {
                _borrowerAppService.update(borrower).done(function () {
                    _bookAppService.updateStatusOfBooks({ Id: borrower.BookId, }).done(function ()
                    {
                        alert("Book returned on time");
                        redirectToBorrowerIndex();
                    });
                });
            }

        }
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
                    window.location.href = BorrowerHomePage;
                }
            });
    }
    // #endregion

    // #region redirectToBorrowerIndex() - to redirect in borrowers home page
    function redirectToBorrowerIndex() {
        abp.notify.info(l('Success'), 'Message');
        window.location.href = BorrowerHomePage;

    }
    // #endregion

})(jQuery);

// #endregion