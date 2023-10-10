using RuStore;

namespace RuStore.Extensions {
    public struct RuStoreApiResult<T> {
        public RuStoreError Error;
        public T Result;
        public bool HasError;
    }
}