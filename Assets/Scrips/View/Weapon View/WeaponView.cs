using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponView : BaseView
{
    public TapLargeWeaponButton tapLargeButtons;
    public RectTransform m_DraggingPlane;
    public GameObject lockUIObject;
    [SerializeField] TMP_Text taskTypeTxt, enviromentTxt, objectTxt;
    bool checkRobot;
    ConfigLevelRecord configLevelRecord;
    WeaponsData weaponData;
    public override void Setup(ViewParam param)
    {
        base.Setup(param);
        lockUIObject.SetActive(false);
        tapLargeButtons.Init();
        checkRobot = false;
        CharacterBufferControl.Instance.trans.DOMove(new Vector3(-1.84f, -0.26f, -1f), 0.5f)
            .SetEase(Ease.OutQuad);
        configLevelRecord = ConfigManager.Instance.configLevel.records[0];
        taskTypeTxt.text = $"Task type: {configLevelRecord.TaskType}";
        enviromentTxt.text = $"Enviroment: {configLevelRecord.EnvironmentType}";
        objectTxt.text = configLevelRecord.ObjectForRobot ? "Object: Yes" : "Object: No";
        weaponData = DataController.Instance.ReloadWeapon();
    }
    public override void OnShowView()
    {
        base.OnShowView();
        DataTrigger.RegisterValueChange(DataSchema.WEAPON, UpdateWeapon);
    }
    public override void OnHideView()
    {
        base.OnHideView();
        DataTrigger.UnRegisterValueChange(DataSchema.WEAPON, UpdateWeapon);
    }
    void UpdateWeapon(object data)
    {
        weaponData = DataController.Instance.ReloadWeapon();
    }
    public void OnHomeView()
    {
        ViewManager.Instance.SwitchView(ViewIndex.IngameView);
    }
}
