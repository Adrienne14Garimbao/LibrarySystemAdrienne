// #region Authors > Create or Edit
(function ($) {

    var _authorAppService = abp.services.app.author;

    var l = abp.localization.getSource('LibrarySystemAdrienne'),
        _$form = $('#CreateAuthorForm');

    var HomePageAuthor = "/Authors";

    _$form.submit(function (e) {
        e.preventDefault();

        CreateOrEdit();
    });


    // #region CreateOrEdit() - For create and edit of authors
    function CreateOrEdit() {
        if (!_$form.valid()) {
            return;
        }
        var author = _$form.serializeFormToObject();

        if (author.Id != 0) {
            _authorAppService.update(author).done(function () {
                redirectToAuthorIndex();
            });
        }
        else {
            _authorAppService.create(author).done(function () {
                redirectToAuthorIndex();
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
    function cancelAndReturn() {
        abp.message.confirm('Are you sure you want to cancel?', 'Go Back')
            .then(function (confirmed) {
                if (confirmed) {
                    window.location.href = HomePageAuthor;
                }
            });
    }
    // #endregion

    // #region redirectToDepartmentIndex() - to redirect to departments home page
    function redirectToAuthorIndex() {
        abp.notify.info(l('Success'), 'Message');
        window.location.href = HomePageAuthor;

    }
    // #endregion

})(jQuery);

// #endregion