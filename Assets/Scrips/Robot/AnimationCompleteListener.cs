using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCompleteListener : MonoBehaviour
{
    public void OnAnimationComplete()
    {
        if (GameManager.Instance.cur_cf_Level.ID == 3 &&
            CharacterBufferControl.Instance.gripperObject != null &&
            CharacterBufferControl.Instance.gripperObject.transform.childCount <= 0)
        {
            DialogManager.Instance.ShowDialog(DialogIndex.LoseDialog);
            return;
        }
        WinDialogParam param = new()
        {
            cf_level = GameManager.Instance.cur_cf_Level
        };
        DialogManager.Instance.ShowDialog(DialogIndex.WinDialog, param);
    }
}
