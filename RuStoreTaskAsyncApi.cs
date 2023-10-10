using System.Collections.Generic;
using System.Threading.Tasks;
using RuStore;
using RuStore.BillingClient;

namespace RuStore.Extensions {
    public static class RuStoreTaskAsyncApi {
         public static async Task<RuStoreApiResult<PaymentResult>> PurchaseProductTaskAsync(this RuStoreBillingClient client, string itemSku, int quantity = 1, string developerPayload = "") {
            bool done = false;

            RuStoreApiResult<PaymentResult> result = default;
            client.PurchaseProduct(
                itemSku,
                quantity,
                developerPayload,
                (error) => {
                    result.Error = error;
                    result.HasError = true;

                    done = true;
                },
                response => {
                    result.Result = response;

                    done = true;
                });

            while (!done) {
                await Task.Yield();
            }

            return result;
        }

        public static async Task<RuStoreApiResult<bool>> ConfirmPurchaseTaskAsync(this RuStoreBillingClient client, string purchaseId) {
            bool done = false;

            RuStoreApiResult<bool> result = default;
            client.ConfirmPurchase(purchaseId, error => {
                result.Error = error;
                result.HasError = true;
                done = true;
            }, () => {
                result.Result = true;
                done = true;
            });
            
            while (!done) {
                await Task.Yield();
            }

            return result;
        }
        
        public static async Task<RuStoreApiResult<bool>> DeletePurchaseTaskAsync(this RuStoreBillingClient client, string purchaseId) {
            bool done = false;

            RuStoreApiResult<bool> result = default;
            client.DeletePurchase(purchaseId, error => {
                result.Error = error;
                result.HasError = true;
                done = true;
            }, () => {
                result.Result = true;
                done = true;
            });
            
            while (!done) {
                await Task.Yield();
            }

            return result;
        }

        public static async Task<RuStoreApiResult<List<Product>>> GetProductsTaskAsync(this RuStoreBillingClient client, string[] products) {
            bool done = false;

            RuStoreApiResult<List<Product>> result = default;
            
            client.GetProducts(products, error => {
                result.Error = error;
                result.HasError = true;
                done = true;
            }, response => {
                result.Result = response;
                done = true;
            });
            
            while (!done) {
                await Task.Yield();
            }

            return result;
        }

        public static async Task<RuStoreApiResult<List<Purchase>>> GetPurchasesTaskAsync(this RuStoreBillingClient client) {
            bool done = false;

            RuStoreApiResult<List<Purchase>> result = default;
            client.GetPurchases(error => {
                result.HasError = true;
                result.Error = error;
                done = true;
            }, purchases => {
                result.Result = purchases;
                done = true;
            });
            
            while (!done) {
                await Task.Yield();
            }

            return result;
        }

        public static async Task<RuStoreApiResult<FeatureAvailabilityResult>> CheckPurchasesAvailabilityTaskAsync(this RuStoreBillingClient client) {
            bool done = false;

            RuStoreApiResult<FeatureAvailabilityResult> result = default;
            client.CheckPurchasesAvailability(error => {
                result.Error = error;
                result.HasError = true;
                done = true;
            }, response => {
                result.Result = response;
                done = true;
            });
            
            while (!done) {
                await Task.Yield();
            }

            return result;
        }
        
        public static async Task<RuStoreApiResult<Purchase>> GetPurchaseInfoTaskAsync(this RuStoreBillingClient client, string purchaseId) {
            bool done = false;

            RuStoreApiResult<Purchase> result = default;
            client.GetPurchaseInfo(purchaseId, error => {
                result.Error = error;
                result.HasError = true;
                done = true;
            }, response => {
                result.Result = response;
                done = true;
            });
            
            while (!done) {
                await Task.Yield();
            }

            return result;
        }
    }
}