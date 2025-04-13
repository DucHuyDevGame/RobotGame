using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] float timer;
    bool isLoseShown = false;
    void Start()
    {
        //timer = GameManager.Instance.cur_cf_Level.TimeFinished * 60;
    }
    void Update()
    {
        if (!RobotController.Instance.runRobot)
            return;
        if (isLoseShown)
            return;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            isLoseShown = true;
            DialogManager.Instance.ShowDialog(DialogIndex.LoseDialog);
            return;
        }
    }
}
