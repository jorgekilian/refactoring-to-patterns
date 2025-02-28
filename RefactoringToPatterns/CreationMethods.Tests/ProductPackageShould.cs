using Xunit;

namespace RefactoringToPatterns.CreationMethods.Tests {
    public class ProductPackageShould {
        [Fact]
        public void CreateAProductPackageWithOnlyInternet() {
            var productPackage = ProductPackage.CreateProductWithInternet("100MB");

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndVoip() {
            var productPackage = ProductPackage.CreateProductWithInternetWithVoip("100MB", 91233788);

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndTv() {
            var productPackage = ProductPackage.CreateProductWithInternetWithTv("100MB", new[] { "LaLiga", "Estrenos" });

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.True(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetVoipAndTv() {
            var productPackage = ProductPackage.CreateProductWithInternetWithVoipWithTv("100MB", 91233788, new[] { "LaLiga", "Estrenos" });

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.True(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndMobile() {
            var productPackage = ProductPackage.CreateProductWithInternetWithMobile("100MB", 612345688);

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasMobile());
        }

        [Fact]
        public void CreateWithInternetAndMobileAndTv() {
            var productPackage = ProductPackage.CreateProductWithInternetWithMobileWithTv("100MB", 612345688, new[] { "LaLiga", "Estrenos" });

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasMobile());
            Assert.True(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndVoipAndMobileAndTv() {
            var productPackage = ProductPackage.CreateProductWithInternetWihtVoipWithMobileWithTv("100MB", 91233788, 612345688, new[] { "LaLiga", "Estrenos" });

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.True(productPackage.HasMobile());
            Assert.True(productPackage.HasTv());
        }
    }
}