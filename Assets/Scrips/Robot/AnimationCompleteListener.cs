using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCompleteListener : MonoBehaviour
{
    public void OnAnimationComplete()
    {
        WinDialogParam param = new WinDialogParam()
        {
            cf_level = GameManager.Instance.cur_cf_Level
        };
        DialogManager.Instance.ShowDialog(DialogIndex.WinDialog, param);
    }
}
