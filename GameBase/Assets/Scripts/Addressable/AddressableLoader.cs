using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressableLoader
{
    const string WRONG_ADDRESS_MSG = "肋给等 Addressable林家 : ";

    public static T LoadAsset<T>(string address) where T : Object
    {
        try
        {
            var asset = Addressables.LoadAssetAsync<T>(address).WaitForCompletion();
            if (asset == null)
                return null;

            return asset;
        }
        catch
        {
            Debug.LogError($"{WRONG_ADDRESS_MSG}{address}");
            return null;
        }
    }
    public static GameObject LoadAsset(AssetReference assetReference)
    {
        var asset = assetReference.LoadAssetAsync<GameObject>().WaitForCompletion();
        if (asset == null)
            return null;

        return asset;
    }


    public static GameObject Instantiate(string address)
    {
        return Addressables.InstantiateAsync(address).WaitForCompletion();
    }

    public static GameObject Instantiate(AssetReference assetReference)
    {
        var asset = assetReference.InstantiateAsync().WaitForCompletion();
        if (asset == null)
            return null;

        return asset;
    }

    public static bool ReleaseInstance(GameObject gameObject)
    {
        return Addressables.ReleaseInstance(gameObject);
    }

    public static void Release(GameObject gameObject)
    {
        Addressables.Release(gameObject);
    }
}
