using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HomeView : BaseView
{
    WeaponsData weapon;
    public override void Setup(ViewParam param)
    {
        base.Setup(param);
        weapon = DataController.Instance.ReloadWeapon();
    }
    public void OnWeaponView()
    {
        ViewManager.Instance.SwitchView(ViewIndex.WeaponView);
    }
    public void LoadSceneLevel()
    {
        ConfigLevelRecord cfLevel = ConfigManager.Instance.configLevel.records.FirstOrDefault(level =>
            level.Object == 1 &&
            level.TaskType == TaskType.Navigation &&
            level.EnvironmentType == EnvironmentType.Water &&
            weapon.movementData.movementType == MovementType.Wheels &&
            weapon.manipulatorData.manipulatorType == ManipulatorType.Gripper &&
            weapon.sensorTypeData.sensorType == SensorsType.Heat &&
            weapon.powerSourceTypeData.powerSourceType == PowerSourceType.PowerCore);

        if (cfLevel != null)
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
