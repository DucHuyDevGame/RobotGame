using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponView : BaseView
{
    public TapLargeWeaponButton tapLargeButtons;
    public RectTransform m_DraggingPlane;
    public GameObject lockUIObject;
    public override void Setup(ViewParam param)
    {
        base.Setup(param);
        lockUIObject.SetActive(false);
        tapLargeButtons.Init();
    }
    public void OnHomeView()
    {
        ViewManager.Instance.SwitchView(ViewIndex.HomeView);
    }
}
