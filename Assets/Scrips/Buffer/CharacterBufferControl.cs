using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CharacterBufferControl : BYSingletonMono<CharacterBufferControl>
{
    WeaponsData weaponData;
    [SerializeField] SpriteRenderer movementLeft, movementRight, manipulatorLeft, manipulatorRight, sensor;
    public Transform trans;
    public TMP_Text tapEdit;
    public Light2D lightObjectGlobal;
    public Light2D lightObjectSensor;
    public RobotValidator robotValidator;
    public GameObject wallObject, fireObject, ground, gripperObject, gripperObjectHand;
    private void Awake()
    {
        trans = transform;
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

    public void Setup()
    {
        weaponData = DataController.Instance.ReloadWeapon();

        if (weaponData == null)
            return;

        if (weaponData.movementData.movementType == MovementType.None)
            movementLeft.sprite = movementRight.sprite = null;
        else
        {
            if(weaponData.movementData.movementType == MovementType.Legs)
            {
                movementLeft.transform.localPosition = new Vector3(-1.71f, -0.92f, -0.1f);
                movementLeft.transform.localRotation = /*new Vector3(0f, 172.706f,0f)*/ Quaternion.Euler(0f, 172.706f, 0f);
                movementRight.transform.localPosition = new Vector3(1.58f, -0.96f, 0f);
            }
            else if (weaponData.movementData.movementType == MovementType.Wheels)
            {
                movementLeft.transform.localPosition = new Vector3(-0.59f, -1.347f, 0f);
                movementLeft.transform.localRotation = Quaternion.identity;
                movementRight.transform.localPosition = new Vector3(0.528f, -1.34f, 0f);
            }
            movementLeft.sprite = movementRight.sprite = SpriteLibControl.Instance.GetSpriteByName(weaponData.movementData.image);
        }
        //if(lightObjectGlobal != null)
        //{
        //    if (weaponData.sensorTypeData.sensorType == SensorsType.LightSensor)
        //        lightObjectGlobal.intensity = 0.2f;
        //    else
        //        lightObjectGlobal.intensity = 1f;
        //}

        if (weaponData.manipulatorData.manipulatorType == ManipulatorType.Gripper)
            manipulatorLeft.transform.localScale = manipulatorRight.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        else
            manipulatorLeft.transform.localScale = manipulatorRight.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        manipulatorLeft.sprite = manipulatorRight.sprite = SpriteLibControl.Instance.GetSpriteByName(weaponData.manipulatorData.image);
        sensor.sprite = SpriteLibControl.Instance.GetSpriteByName(weaponData.sensorTypeData.image);
        if (lightObjectSensor != null)
        {
            if (weaponData.manipulatorData.manipulatorType == ManipulatorType.LightBulb
                && /*weaponData.sensorTypeData.sensorType == SensorsType.LightSensor
                && */GameManager.Instance.cur_cf_Level.ID == 4)
                lightObjectSensor.gameObject.SetActive(true);
            else
                lightObjectSensor.gameObject.SetActive(false);

            if (!RobotController.Instance.runRobot)
                return;
        }
    }
    public void AddGripperObject()
    {
        GameObject obj = Instantiate(Resources.Load("Object/ObjectRobot", typeof(GameObject)), Vector3.zero, Quaternion.identity) as GameObject;
        obj.transform.SetParent(gripperObjectHand.transform, false);
        gripperObjectHand.transform.localPosition = new Vector3(0, 3.17f, 0);
        obj.transform.localScale = Vector3.one;
    }

}
