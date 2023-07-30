using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpawnAddressable : MonoBehaviour
{
    [SerializeField] private AssetReference assetReference;
    [SerializeField] private AssetLabelReference assetLabelReference;

    private void Awake()
    {
        NewInputAction inputActions = new NewInputAction();
        inputActions.Move.Enable();
        inputActions.Move.Spawn.performed += SpawnCube;


    }

    public void SpawnCube(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        /*assetReference.LoadAssetAsync<GameObject>().Completed +=
            (asyncOperation) =>
            {
                if (asyncOperation.Status == AsyncOperationStatus.Succeeded)
                {
                    Instantiate(asyncOperation.Result);
                }
                else
                {
                    Debug.Log("Error while loading Cube using Addressable !!!");
                }
            };*/

        //Using asset label
        Addressables.LoadAssetAsync<GameObject>(assetLabelReference).Completed +=
           (asyncOperation) =>
           {
               if (asyncOperation.Status == AsyncOperationStatus.Succeeded)
               {
                   Instantiate(asyncOperation.Result);
               }
               else
               {
                   Debug.Log("Error while loading Cube using Addressable !!!");
               }
           };
    }
}
