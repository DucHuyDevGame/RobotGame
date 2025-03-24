using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : BYSingletonMono<MenuControl>
{
    public RectTransform top;
    public RectTransform bottom;
    public RectTransform right;
    void Awake()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if(arg0.buildIndex==1)
        {
            top.DOAnchorPosY(0, 0.5f);
            bottom.DOAnchorPosY(0, 0.5f);
            right.DOAnchorPosX(-555, 0.25f);
            right.DOAnchorPosY(-18, 0.5f);
        }
    }
}
