// #region Category > Index
(function ($) {

    var _categoryAppService = abp.services.app.bookCategory;

    var l = abp.localization.getSource('LibrarySystemAdrienne');

    var CategoryHomePage = "/BooksCategories",
        CategoryEditPage = "/BooksCategories/CreateOrEditBookCategory/";

    // #region Edit Category Button
    $(document).on('click', '.edit-category', function (e) {
        var categorytId = $(this).attr("data-category-id");

        e.preventDefault();
        window.location.href = CategoryEditPage + categorytId;

    });
    // #endregion


    // #region Delete Category Button
    $(document).on('click', '.delete-category', function () {
        var categoryId = $(this).attr("data-category-id");
        var categoryName = $(this).attr('data-category-name');

        DeleteCategory(categoryId, categoryName);
    });
    // #endregion


    // #region DeleteCategory() - To delete category records
    function DeleteCategory(categoryId, categoryName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'), categoryName), l('Delete'),

            (isConfirmed) => {
                if (isConfirmed) {
                    _categoryAppService.delete({
                        id: categoryId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        window.location.href = CategoryHomePage;

                    });
                }
            }
        );
    }
    // #endregion


})(jQuery);

// #endregion