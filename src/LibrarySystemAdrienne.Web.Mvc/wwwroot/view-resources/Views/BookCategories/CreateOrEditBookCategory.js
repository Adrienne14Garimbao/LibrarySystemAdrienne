// #region Category > Create or Edit
(function ($) {

    var _categoryAppService = abp.services.app.bookCategory;

    var l = abp.localization.getSource('LibrarySystemAdrienne'),
        _$form = $('#CreateBookCategoryForm');

    var CategoryHomePage = "/BooksCategories";

    _$form.submit(function (CatchError) {

        CreateOrEdit();
        CatchError.preventDefault();
        
    });


    // #region CreateOrEdit() - For create and edit of categories
    function CreateOrEdit() {

        if (!_$form.valid()) {
            return;
        }
        var category = _$form.serializeFormToObject();

        if (category.Id != 0) {
            _categoryAppService.update(category).done(function () {
                redirectToCategoryIndex();
            });
        }
        else {
            _categoryAppService.create(category).done(function () {
                redirectToCategoryIndex();
            });
        }
    }

    // #endregion

    // #region Cancel Button
    $(document).on('click', '.cancel-button', function (e) {
        cancelAndReturn();
    });
    // #endregion

    // #region cancelAndReturn() - to cancel and go back in category home page
    function cancelAndReturn() {
        abp.message.confirm('Are you sure you want to cancel?', 'Go Back')
            .then(function (confirmed) {
                if (confirmed) {
                    window.location.href = CategoryHomePage;
                }
            });
    }
    // #endregion

    // #region redirectToDepartmentIndex() - to redirect in category home page
    function redirectToCategoryIndex() {
        abp.notify.info(l('Success'), 'Message');
        window.location.href = CategoryHomePage;

    }
    // #endregion

})(jQuery);

// #endregion