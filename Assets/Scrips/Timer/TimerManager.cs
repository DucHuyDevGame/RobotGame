using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerManager : BYSingletonMono<TimerManager>
{
    float timer;
    bool isLoseShown = false;
    public UnityEvent<float> timerUpdate;
    void Start()
    {
        timer = GameManager.Instance.cur_cf_Level.TimeFinished;
    }
    void Update()
    {
        if (!RobotController.Instance.timeStart)
            return;
        if (isLoseShown)
            return;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            isLoseShown = true;
            timerUpdate?.Invoke(timer);
            DialogManager.Instance.ShowDialog(DialogIndex.LoseDialog);
            return;
        }
        timerUpdate?.Invoke(timer);
    }
}
