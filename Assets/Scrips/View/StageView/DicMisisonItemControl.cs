using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DicMisisonItemControl : MonoBehaviour
{
    public TMP_Text name_misison;
    public Image stageCurrent;
    [SerializeField] List<GameObject> startsOn;
    ConfigLevelRecord cf;
    MissionData data;
    public GameObject lockMission;
    public void SetUp(MissionData data_, bool isPreviousMissionCompleted)
    {
        cf = ConfigManager.Instance.configLevel.GetRecordBykeySearch(data_.id);
        data = data_;
        name_misison.text = cf.MisisonName;
        if (data.star > 0)
        {
            for (int i = 0; i < startsOn.Count; i++)
                startsOn[i].SetActive(i < data.star);
            stageCurrent.overrideSprite = SpriteLibControl.Instance.GetSpriteByName("complete");
            lockMission.SetActive(false);
        }
        else if (isPreviousMissionCompleted)
        {
            stageCurrent.overrideSprite = SpriteLibControl.Instance.GetSpriteByName("current");
            lockMission.SetActive(false);
        }
        else
        {
            if(data.id == 1)
            {
                stageCurrent.overrideSprite = SpriteLibControl.Instance.GetSpriteByName("current");
                lockMission.SetActive(false);
            }
            else
            {
                stageCurrent.overrideSprite = SpriteLibControl.Instance.GetSpriteByName("lock");
                lockMission.SetActive(true);
            }
            
        }
    }
}
