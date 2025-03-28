using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class HomeView : BaseView
{
    WeaponsData weapon; 
    [SerializeField] TMP_Text taskTypeTxt, enviromentTxt, objectTxt;
    ConfigLevelRecord cfLevel;
    public override void Setup(ViewParam param)
    {
        base.Setup(param);
        weapon = DataController.Instance.ReloadWeapon(); 
        CharacterBufferControl.Instance.trans.DOMove(new Vector3(-6.23f, 0.7f, -1f), 0.5f)
            .SetEase(Ease.OutQuad);
        cfLevel = ConfigManager.Instance.configLevel.records[0];
        taskTypeTxt.text = $"Task type: {cfLevel.TaskType}";
        enviromentTxt.text = $"Enviroment: {cfLevel.EnvironmentType}";
        objectTxt.text = cfLevel.ObjectForRobot? "Object: Yes" : "Object: No";
    }
    public void OnWeaponView()
    {
        ViewManager.Instance.SwitchView(ViewIndex.WeaponView);
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
        weapon = DataController.Instance.ReloadWeapon();
    }
    public void LoadSceneLevel()
    {
        if (cfLevel.TaskType == TaskType.Navigation && cfLevel.MovementType == weapon.movementData.movementType
            && !cfLevel.ObjectForRobot && cfLevel.EnvironmentType == EnvironmentType.FlatGround)
        {
            LoadSceneManager.Instance.LoadSceneByName(cfLevel.SceneName, () =>
            {
                ViewManager.Instance.SwitchView(ViewIndex.EmptyView);
            });
        }
        else
            DialogManager.Instance.ShowDialog(DialogIndex.CancelDialog);
        
    }
}
