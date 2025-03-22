using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootLoader : MonoBehaviour
{
    IEnumerator Start()
    {
        DontDestroyOnLoad(gameObject);
        yield return new WaitForSeconds(1);
        ConfigManager.Instance.InitConfig(InitData);
    }
    private void InitData()
    {
        DataController.Instance.InitData(() =>
        {
            LoadSceneManager.Instance.LoadSceneByName("Buffer", LoadSceneDone);
        });
    }
   

    public void LoadSceneDone()
    {
        Debug.LogError(" load scene done");
        ViewManager.Instance.SwitchView(ViewIndex.HomeView);
    }
}
