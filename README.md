# Task/UniTask extension for RuStore Unity billing plugin 

## Badges
[![MIT License](https://img.shields.io/apm/l/atomic-design-ui.svg?)](https://github.com/tterb/atomic-design-ui/blob/master/LICENSEs)
[![Downloads](https://img.shields.io/github/downloads/finikigames/RuStore-unity-async/total.svg)](https://github.com/finikigames/RuStore-unity-async/releases)

## Plugin provides two API's to call async methods:
1. Task
2. UniTask

Task vesion available as is. To use UniTask extension, you need to define Scripting Define Symbols <br>RUSTORE_UNITASK</br> and import UniTask plugin to your project.
[How to add Scripting Define Symbols](https://docs.unity3d.com/Manual/CustomScriptingSymbols.html)

## Install
You can add https://github.com/finikigames/RuStore-unity-async.git to Package Manager

![image](https://user-images.githubusercontent.com/46207/79450714-3aadd100-8020-11ea-8aae-b8d87fc4d7be.png)

or add "com.finikigames.rustore-async-extension": "https://github.com/finikigames/RuStore-unity-async.git" to Packages/manifest.json.

## Usage/Examples

```csharp
var result = await RuStoreBillingClient.Instance.PurchaseProductAsync(itemId);
```

All methods return RuStoreApiResult struct:

```csharp
 public struct RuStoreApiResult<T> {
        public RuStoreError Error;
        public T Result;
        public bool HasError;
    }
```

To use extensions just write await in front of your method call, remove stupid callbacks and add Async to the method name.
That's all :)