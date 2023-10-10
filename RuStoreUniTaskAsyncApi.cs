#if RUSTORE_UNITASK
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using RuStore;
using RuStore.BillingClient;

namespace Payments.RuStore.Extensions {
    public static class RuStoreAsyncApi {
        public static async UniTask<RuStoreApiResult<PaymentResult>> PurchaseProductAsync(this RuStoreBillingClient client, string itemSku, int quantity = 1, string developerPayload = "") {
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
                await UniTask.Yield();
            }

            return result;
        }

        public static async UniTask<RuStoreApiResult<bool>> ConfirmPurchaseAsync(this RuStoreBillingClient client, string purchaseId) {
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
                await UniTask.Yield();
            }

            return result;
        }
        
        public static async UniTask<RuStoreApiResult<bool>> DeletePurchaseAsync(this RuStoreBillingClient client, string purchaseId) {
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
                await UniTask.Yield();
            }

            return result;
        }

        public static async UniTask<RuStoreApiResult<List<Product>>> GetProductsAsync(this RuStoreBillingClient client, string[] products) {
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
                await UniTask.Yield();
            }

            return result;
        }

        public static async UniTask<RuStoreApiResult<List<Purchase>>> GetPurchasesAsync(this RuStoreBillingClient client) {
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
                await UniTask.Yield();
            }

            return result;
        }

        public static async UniTask<RuStoreApiResult<FeatureAvailabilityResult>> CheckPurchasesAvailabilityAsync(this RuStoreBillingClient client) {
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
                await UniTask.Yield();
            }

            return result;
        }
        
        public static async UniTask<RuStoreApiResult<Purchase>> GetPurchaseInfoAsync(this RuStoreBillingClient client, string purchaseId) {
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
                await UniTask.Yield();
            }

            return result;
        }
    }
}
#endif