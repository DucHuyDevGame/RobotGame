using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngameView : BaseView
{
    ConfigLevelRecord cfLevel;
    [SerializeField] TMP_Text taskTypeTxt, enviromentTxt, objectTxt, levelTxt;
    public override void Setup(ViewParam param)
    {
        base.Setup(param);
        CharacterBufferControl.Instance.tapEdit.gameObject.SetActive(true);
        CharacterBufferControl.Instance.trans.DOMove(new Vector3(-5.27f, 0.32f, -1f), 0.05f)
            .SetEase(Ease.OutQuad);
        cfLevel = GameManager.Instance.cur_cf_Level;
        taskTypeTxt.text = $"Task type: {cfLevel.TaskType}";
        enviromentTxt.text = $"Enviroment: {cfLevel.EnvironmentType}";
        objectTxt.text = cfLevel.ObjectForRobot ? "Object: Yes" : "Object: No";
        levelTxt.text = $"Level {cfLevel.ID}";
    }
    public void OnPause()
    {
        DialogManager.Instance.ShowDialog(DialogIndex.PauseDialog);
    }
    bool IsPointerOverGameObject(Vector2 pos)
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(pos);
        RaycastHit2D[] hits = Physics2D.RaycastAll(worldPoint, Vector2.zero);

        foreach (var hit in hits)
        {
            if (hit.collider != null)
            {
                Debug.LogError(hit.collider.gameObject.name);
                if (hit.collider.GetComponent<IgnoreUI>() != null)
                    return true;
            }
        }
        return false;
    }
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;
        Vector2 mousePosition = Input.mousePosition;
        if (IsPointerOverGameObject(mousePosition))
            ViewManager.Instance.SwitchView(ViewIndex.WeaponView);
    }
    public void CheckWin()
    {
        WinDialogParam param = new()
        {
            cf_level = GameManager.Instance.cur_cf_Level
        };
        DialogManager.Instance.ShowDialog(DialogIndex.WinDialog, param);
    }
}
