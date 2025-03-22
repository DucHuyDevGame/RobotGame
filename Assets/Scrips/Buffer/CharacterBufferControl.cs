using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBufferControl : MonoBehaviour
{
    WeaponsData weaponData;
    [SerializeField] SpriteRenderer movement, manipulator, sensor, powerSource;
    private void Start()
    {
        Setup();
    }

    private void OnEnable()
    {
        DataTrigger.RegisterValueChange(DataSchema.WEAPON, SetupData);
    }
    private void OnDisable()
    {
        DataTrigger.UnRegisterValueChange(DataSchema.WEAPON, SetupData);
    }

    void SetupData(object data)
    {
        Setup();
    }

    void Setup()
    {
        weaponData = DataController.Instance.ReloadWeapon();
        
        movement.sprite = SpriteLibControl.Instance.GetSpriteByName(weaponData.movementData.image);

        manipulator.sprite = SpriteLibControl.Instance.GetSpriteByName(weaponData.manipulatorData.image);

        sensor.sprite = SpriteLibControl.Instance.GetSpriteByName(weaponData.sensorTypeData.image);

        powerSource.sprite = SpriteLibControl.Instance.GetSpriteByName(weaponData.powerSourceTypeData.image);
    }
}
