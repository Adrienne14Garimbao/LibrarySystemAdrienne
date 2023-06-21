using System.Threading.Tasks;
using LibrarySystemAdrienne.Models.TokenAuth;
using LibrarySystemAdrienne.Web.Controllers;
using Shouldly;
using Xunit;

namespace LibrarySystemAdrienne.Web.Tests.Controllers
{
    public class HomeController_Tests: LibrarySystemAdrienneWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}