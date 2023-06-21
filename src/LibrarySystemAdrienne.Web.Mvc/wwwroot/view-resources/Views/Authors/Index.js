// #region Authors > Index
(function ($) {

    var _authorAppService = abp.services.app.author;

    var l = abp.localization.getSource('LibrarySystemAdrienne');

    var AuthorHomePage = "/Authors",
        AuthorEditPage = "/Authors/CreateOrEditAuthor/";

    // #region Edit Author Button 
    $(document).on('click', '.edit-author', function (e) {
        var authorId = $(this).attr("data-author-id");

        e.preventDefault();
        window.location.href = AuthorEditPage + authorId;

    });
    // #endregion


    // #region Delete Author Button
    $(document).on('click', '.delete-department', function () {
        var authorId = $(this).attr("data-author-id");
        var authorName = $(this).attr('data-author-name');

        DeleteAuthor(authorId, authorName);
    });
    // #endregion


    // #region DeleteAuthor() - To delete author records
    function DeleteAuthor(authorId, authorName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'), authorName), l('Delete'),

            (isConfirmed) => {
                if (isConfirmed) {
                    _authorAppService.delete({
                        id: authorId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        window.location.href = AuthorHomePage;

                    });
                }
            }
        );
    }
    // #endregion


})(jQuery);

// #endregion