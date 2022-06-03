namespace RefactoringToPatterns.CreationMethods {
    public class ProductPackage {
        private readonly string _internetLabel;
        private readonly int? _telephoneNumber;
        private readonly string[] _tvChannels;


        internal ProductPackage(string internetLabel, int? telephoneNumber = null, string[] tvChannels = null) {
            _internetLabel = internetLabel;
            _telephoneNumber = telephoneNumber;
            _tvChannels = tvChannels;
        }

        public bool HasInternet() {
            return _internetLabel != null;
        }


        public bool HasVOIP() {
            return _telephoneNumber != null;
        }

        public bool HasTv() {
            return _tvChannels != null;
        }

        public static ProductPackage CreateProductWithInternet(string speed) {
            return new ProductPackage(speed);
        }

        public static ProductPackage CreateProductWithInternetWithVoip(string speed, int telephoneNumber) {
            return new ProductPackage(speed, telephoneNumber);
        }

        public static ProductPackage CreateProductWithInternetWithTv(string speed, string[] tvChannels) {
            return new ProductPackage(speed, null, tvChannels);
        }

        public static ProductPackage CreateProductWithInternetWithVoipWithTv(string speed, int telephoneNumber, string[] tvChannels) {
            return new ProductPackage(speed, telephoneNumber, tvChannels);
        }
    }
}