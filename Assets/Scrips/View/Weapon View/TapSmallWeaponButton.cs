using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TapSmallWeaponButton : MonoBehaviour
{
    public List<Button> buttons;
    public List<UnityEvent> onEvent_Clicks;
    public List<Image> images;
    int count = 0;
    public WeaponViewGunList weaponList;
    public void Init()
    {
        OnClick(0);
    }
    public void OnClick(int index)
    {
        for (int i = 0; i < count; i++)
        {
            buttons[i].interactable = !(i == index);
        }
        if (onEvent_Clicks.Count >= index + 1)
            onEvent_Clicks[index].Invoke();

    }
    public void SetUpImagesMovement()
    {
        count = 0;
        Dictionary<string, int> imageTypeToButtonIndex = new Dictionary<string, int>();

        foreach (var record in ConfigManager.Instance.configMovement.records)
        {
            string imageType = record.ImageType;

            if (!imageTypeToButtonIndex.ContainsKey(imageType))
            {
                imageTypeToButtonIndex[imageType] = count;
                images[count].sprite = SpriteLibControl.Instance.GetSpriteByName(imageType);
                buttons[count].gameObject.SetActive(true);
                count++;
            }
        }
        if (count < buttons.Count)
        {
            for (int i = count; i < buttons.Count; i++)
                buttons[i].gameObject.SetActive(false);
        }
        weaponList.SetUpConfig(ConfigType.Movement);
    }
    public void SetUpImagesManipulator()
    {
        count = 0;
        Dictionary<string, int> imageTypeToButtonIndex = new Dictionary<string, int>();

        for (int i = 0; i < ConfigManager.Instance.configManipulator.records.Count; i++)
        {
            string imageType = ConfigManager.Instance.configManipulator.records[i].ImageType;
            if (!imageTypeToButtonIndex.ContainsKey(imageType))
            {
                imageTypeToButtonIndex[imageType] = count;
                images[count].sprite = SpriteLibControl.Instance.GetSpriteByName(imageType);
                buttons[count].gameObject.SetActive(true);
                count++;
            }
        }
        if (count < buttons.Count)
        {
            for (int i = count; i < buttons.Count; i++)
                buttons[i].gameObject.SetActive(false);
        }
        weaponList.SetUpConfig(ConfigType.Manipulator);
    }
    public void SetUpImagesSensor()
    {
        count = 0; 
        Dictionary<string, int> imageTypeToButtonIndex = new Dictionary<string, int>();
        for (int i = 0; i < ConfigManager.Instance.configSensor.records.Count; i++)
        {
            string imageType = ConfigManager.Instance.configSensor.records[i].ImageType;
            if(!imageTypeToButtonIndex.ContainsKey(imageType))
            {
                imageTypeToButtonIndex[imageType] = count;
                images[count].sprite = SpriteLibControl.Instance.GetSpriteByName(imageType);
                buttons[count].gameObject.SetActive(true);
                count++;
            }
        }
        if (count < buttons.Count)
        {
            for (int i = count; i < buttons.Count; i++)
                buttons[i].gameObject.SetActive(false);
        }
        weaponList.SetUpConfig(ConfigType.Sensor);
    }
    public void SetUpImagesPowerSource()
    {
        count = 0;
        Dictionary<string, int> imageTypeToButtonIndex = new Dictionary<string, int>();
        for (int i = 0; i < ConfigManager.Instance.configPowerSource.records.Count; i++)
        {
            string imageType = ConfigManager.Instance.configPowerSource.records[i].ImageType;
            if(!imageTypeToButtonIndex.ContainsKey(imageType))
            {
                imageTypeToButtonIndex[imageType] = count;
                images[count].sprite = SpriteLibControl.Instance.GetSpriteByName(imageType);
                buttons[count].gameObject.SetActive(true);
                count++;
            }
        }
        if (count < buttons.Count)
        {
            for (int i = count; i < buttons.Count; i++)
                buttons[i].gameObject.SetActive(false);
        }
        weaponList.SetUpConfig(ConfigType.PowerSource);
    }
}
