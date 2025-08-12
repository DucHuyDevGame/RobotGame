using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class BootLoader : MonoBehaviour
{
    [SerializeField] AddressablesManager addressablesManager;
    IEnumerator Start()
    {
        DontDestroyOnLoad(gameObject);
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(addressablesManager.InitAddressable);
        ConfigManager.Instance.InitConfig(InitData);
    }
    private void InitData()
    {
        DataController.Instance.InitData(() =>
        {
            LoadSceneManager.Instance.LoadSceneByName("Buffer",true,(success) =>
            {
                if (success)
                    LoadSceneDone();
            });
        });
    }
   

    public void LoadSceneDone()
    {
        ViewManager.Instance.SwitchView(ViewIndex.HomeView);
    }
}
