using System.Collections;
using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.RemoteConfig;
using UnityEngine;

public class RemoteConfigHandle : MonoBehaviour
{
    public struct UserAttributes
    {
        ////
    }

    public struct AppAttributes
    {
        ////////
    }
    private async void Awake()
    {
        await UnityServices.InitializeAsync();

        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        RuntimeConfig runtimeConfig = await RemoteConfigService.Instance.FetchConfigsAsync(new UserAttributes(), new AppAttributes());

        Debug.Log("health=" + runtimeConfig.GetFloat("health")); 
        Debug.Log("lives=" + runtimeConfig.GetInt("lives"));

    }
}
