using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : BYSingletonMono<ConfigManager>
{
    public ConfigManipulator configManipulator;
    public ConfigShop configShop;
    public ConfigMovement configMovement;
    public ConfigSensor configSensor;
    public ConfigLevel configLevel;

    public void InitConfig(Action callback)
    {
        StartCoroutine(ProgressLoadConfig(callback));
    }
    IEnumerator ProgressLoadConfig(Action callback)
    {
        configShop = Resources.Load("Config/ConfigShop", typeof(ScriptableObject)) as ConfigShop;
        yield return new WaitUntil(() => configShop != null);

        configManipulator = Resources.Load("Config/ConfigManipulator", typeof(ScriptableObject)) as ConfigManipulator;
        yield return new WaitUntil(() => configManipulator != null);

        configMovement = Resources.Load("Config/ConfigMovement", typeof(ScriptableObject)) as ConfigMovement;
        yield return new WaitUntil(() => configMovement != null);

        configSensor = Resources.Load("Config/ConfigSensor", typeof(ScriptableObject)) as ConfigSensor;
        yield return new WaitUntil(() => configSensor != null);

        configLevel = Resources.Load("Config/ConfigLevel", typeof(ScriptableObject)) as ConfigLevel;
        yield return new WaitUntil(() => configLevel != null);

        callback?.Invoke();
    }
}
