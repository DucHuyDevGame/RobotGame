using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class HomeView : BaseView
{
    WeaponsData weapon;
    public override void Setup(ViewParam param)
    {
        base.Setup(param);
        weapon = DataController.Instance.ReloadWeapon(); 
        CharacterBufferControl.Instance.trans.DOMove(new Vector3(-5.92f, 0.7f, -1f), 0.5f)
            .SetEase(Ease.OutQuad);
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
        ViewManager.Instance.SwitchView(ViewIndex.StageView);
    }
}
