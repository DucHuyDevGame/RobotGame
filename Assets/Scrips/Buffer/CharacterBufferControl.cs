using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CharacterBufferControl : BYSingletonMono<CharacterBufferControl>
{
    WeaponsData weaponData;
    [SerializeField] SpriteRenderer movement, manipulator, sensor, powerSource;
    public Transform trans;
    public TMP_Text tapEdit;
    //public Light2D lightObjectGlobal;
    public Light2D lightObjectSensor;
    private void Awake()
    {
        trans = transform;
    }
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

        if (weaponData == null)
            return;

        if (weaponData.movementData.movementType == MovementType.None)
            movement.sprite = null;
        else
            movement.sprite = SpriteLibControl.Instance.GetSpriteByName(weaponData.movementData.image);

        //if(lightObjectGlobal != null)
        //{
        //    if (weaponData.sensorTypeData.sensorType == SensorsType.LightSensor)
        //        lightObjectGlobal.intensity = 0.2f;
        //    else
        //        lightObjectGlobal.intensity = 1f;
        //}
        manipulator.sprite = SpriteLibControl.Instance.GetSpriteByName(weaponData.manipulatorData.image);

        if (lightObjectSensor != null)
        {
            if (weaponData.manipulatorData.manipulatorType == ManipulatorType.LightBulb
                && weaponData.sensorTypeData.sensorType == SensorsType.LightSensor)
                lightObjectSensor.gameObject.SetActive(true);
            else
                lightObjectSensor.gameObject.SetActive(false);
        }

        sensor.sprite = SpriteLibControl.Instance.GetSpriteByName(weaponData.sensorTypeData.image);

        powerSource.sprite = SpriteLibControl.Instance.GetSpriteByName(weaponData.powerSourceTypeData.image);
    }
}
