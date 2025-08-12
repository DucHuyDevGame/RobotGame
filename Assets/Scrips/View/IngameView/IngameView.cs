using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngameView : BaseView
{
    ConfigLevelRecord cfLevel;
    [SerializeField] TMP_Text taskTypeTxt, enviromentTxt, objectTxt, levelTxt, timerTxt;
    [SerializeField] Button btnRunRobot;
    [SerializeField] float intensity;
    public override void Setup(ViewParam param)
    {
        base.Setup(param);
        RobotController.Instance.RigiBody.gravityScale = 1;
        if (CharacterBufferControl.Instance.wallObject != null)
            CharacterBufferControl.Instance.wallObject.SetActive(true);
        if (CharacterBufferControl.Instance.fireObject != null)
            CharacterBufferControl.Instance.fireObject.SetActive(true);
        CharacterBufferControl.Instance.ground.SetActive(true);
        CharacterBufferControl.Instance.tapEdit.gameObject.SetActive(true);
        CharacterBufferControl.Instance.trans.DOMove(new Vector3(-5.1f, 0.82f, -1f), 0.05f)
            .SetEase(Ease.OutQuad);
        cfLevel = GameManager.Instance.cur_cf_Level;
        taskTypeTxt.text = $"Task type: {cfLevel.TaskType}";
        enviromentTxt.text = $"Enviroment: {cfLevel.EnvironmentType}";
        objectTxt.text = $"{cfLevel.ObjectTypes}";
        levelTxt.text = $"Level {cfLevel.ID}";
        btnRunRobot.gameObject.SetActive(true);
        if (CharacterBufferControl.Instance.lightObjectGlobal != null)
            CharacterBufferControl.Instance.lightObjectGlobal.intensity = intensity;
    }
    public override void OnShowView()
    {
        base.OnShowView();
        TimerManager.Instance.timerUpdate.AddListener(UpdateTimerTxt);
    }
    void UpdateTimerTxt(float timer)
    {
        if (timer <= 0)
        {
            timerTxt.text = "";
            return;
        }
        int hours = Mathf.FloorToInt(timer / 3600);
        int minutes = Mathf.FloorToInt((timer % 3600) / 60);
        int seconds = Mathf.CeilToInt(timer % 60);
        timerTxt.text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
    }
    public void OnPause()
    {
        //DialogManager.Instance.ShowDialog(DialogIndex.PauseDialog);
        RobotController.Instance.gameObject.SetActive(false);
        ViewManager.Instance.SwitchView(ViewIndex.EmptyView);
        LoadSceneManager.Instance.LoadSceneByName("Buffer", false, (success) =>
        {
            if(success)
                ViewManager.Instance.SwitchView(ViewIndex.HomeView);
        });
    }
    bool IsPointerOverGameObject(Vector2 pos)
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(pos);
        RaycastHit2D[] hits = Physics2D.RaycastAll(worldPoint, Vector2.zero);

        foreach (var hit in hits)
        {
            if (hit.collider != null)
            {
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
    public void RunRobot()
    {
        RobotController.Instance.Speed = ConfigManager.Instance.configMovement.GetRecordSpeed(DataController.Instance.ReloadWeapon().movementData.movementType);
        RobotController.Instance.timeStart = true;
        btnRunRobot.gameObject.SetActive(false);
        CharacterBufferControl.Instance.tapEdit.gameObject.SetActive(false);
        CharacterBufferControl.Instance.robotValidator.CheckRobotCondition(DataController.Instance.ReloadWeapon());
        CharacterBufferControl.Instance.Setup();
    }
}
