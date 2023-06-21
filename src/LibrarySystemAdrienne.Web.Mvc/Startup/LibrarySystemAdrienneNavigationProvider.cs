using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using LibrarySystemAdrienne.Authorization;

namespace LibrarySystemAdrienne.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class LibrarySystemAdrienneNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu

            #region Home / Library System
                    .AddItem(
                        new MenuItemDefinition(
                            PageNames.Home,
                            L("LibrarySystem"),
                            url: "",
                            icon: "fas fa-book-open",
                            requiresAuthentication: true
                        )
                    )
            #endregion

            #region Departments
                                .AddItem(
                                    new MenuItemDefinition(
                                        PageNames.Departments,
                                        L("Departments"),
                                        url: "Departments",
                                        icon: "fas fa-sitemap",
                                        requiresAuthentication: true
                                    )
                                )
            #endregion

            #region  Students
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Students,
                        L("Students"),
                        url: "Students",
                        icon: "fas fa-graduation-cap",
                        requiresAuthentication: true
                    )
                )
            #endregion

            #region Authors
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Authors,
                        L("Author"),
                        url: "Authors",
                        icon: "fas fa-pencil-alt",
                        requiresAuthentication: true
                    )
                )
            #endregion

            #region Book Category   
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.BookCategories,
                        L("Category"),
                        url: "BooksCategories",
                        icon: "fas fa-list-alt",
                        requiresAuthentication: true
                    )
                )
            #endregion

            #region Books
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Books,
                        L("Books"),
                        url: "Books",
                        icon: "fas fa-book-medical",
                        requiresAuthentication: true
                    )
                )
                #endregion

            #region Borrower
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Borrowers,
                        L("Borrower"),
                        url: "Borrowers",
                        icon: "fas fa-hand-holding",
                        requiresAuthentication: true
                    )
                );
            #endregion


            #region Commented Codes
            //.AddItem(
            //    new MenuItemDefinition(
            //        PageNames.Tenants,
            //        L("Tenants"),
            //        url: "Tenants",
            //        icon: "fas fa-building",
            //        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)
            //    )
            //).AddItem(
            //    new MenuItemDefinition(
            //        PageNames.Users,
            //        L("Users"),
            //        url: "Users",
            //        icon: "fas fa-users",
            //        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
            //    )
            //).AddItem(
            //    new MenuItemDefinition(
            //        PageNames.Roles,
            //        L("Roles"),
            //        url: "Roles",
            //        icon: "fas fa-theater-masks",
            //        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
            //    )
            //)
            //.AddItem( // Menu items below is just for demonstration!
            //    new MenuItemDefinition(
            //        "MultiLevelMenu",
            //        L("MultiLevelMenu"),
            //        icon: "fas fa-circle"
            //    ).AddItem(
            //        new MenuItemDefinition(
            //            "AspNetBoilerplate",
            //            new FixedLocalizableString("ASP.NET Boilerplate"),
            //            icon: "far fa-circle"
            //        ).AddItem(
            //            new MenuItemDefinition(
            //                "AspNetBoilerplateHome",
            //                new FixedLocalizableString("Home"),
            //                url: "https://aspnetboilerplate.com?ref=abptmpl",
            //                icon: "far fa-dot-circle"
            //            )
            //        ).AddItem(
            //            new MenuItemDefinition(
            //                "AspNetBoilerplateTemplates",
            //                new FixedLocalizableString("Templates"),
            //                url: "https://aspnetboilerplate.com/Templates?ref=abptmpl",
            //                icon: "far fa-dot-circle"
            //            )
            //        ).AddItem(
            //            new MenuItemDefinition(
            //                "AspNetBoilerplateSamples",
            //                new FixedLocalizableString("Samples"),
            //                url: "https://aspnetboilerplate.com/Samples?ref=abptmpl",
            //                icon: "far fa-dot-circle"
            //            )
            //        ).AddItem(
            //            new MenuItemDefinition(
            //                "AspNetBoilerplateDocuments",
            //                new FixedLocalizableString("Documents"),
            //                url: "https://aspnetboilerplate.com/Pages/Documents?ref=abptmpl",
            //                icon: "far fa-dot-circle"
            //            )
            //        )
            //    ).AddItem(
            //        new MenuItemDefinition(
            //            "AspNetZero",
            //            new FixedLocalizableString("ASP.NET Zero"),
            //            icon: "far fa-circle"
            //        ).AddItem(
            //            new MenuItemDefinition(
            //                "AspNetZeroHome",
            //                new FixedLocalizableString("Home"),
            //                url: "https://aspnetzero.com?ref=abptmpl",
            //                icon: "far fa-dot-circle"
            //            )
            //        ).AddItem(
            //            new MenuItemDefinition(
            //                "AspNetZeroFeatures",
            //                new FixedLocalizableString("Features"),
            //                url: "https://aspnetzero.com/Features?ref=abptmpl",
            //                icon: "far fa-dot-circle"
            //            )
            //        ).AddItem(
            //            new MenuItemDefinition(
            //                "AspNetZeroPricing",
            //                new FixedLocalizableString("Pricing"),
            //                url: "https://aspnetzero.com/Pricing?ref=abptmpl#pricing",
            //                icon: "far fa-dot-circle"
            //            )
            //        ).AddItem(
            //            new MenuItemDefinition(
            //                "AspNetZeroFaq",
            //                new FixedLocalizableString("Faq"),
            //                url: "https://aspnetzero.com/Faq?ref=abptmpl",
            //                icon: "far fa-dot-circle"
            //            )
            //        ).AddItem(
            //            new MenuItemDefinition(
            //                "AspNetZeroDocuments",
            //                new FixedLocalizableString("Documents"),
            //                url: "https://aspnetzero.com/Documents?ref=abptmpl",
            //                icon: "far fa-dot-circle"
            //            )
            //        )
            //    )
            //);
            #endregion
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LibrarySystemAdrienneConsts.LocalizationSourceName);
        }
    }
}