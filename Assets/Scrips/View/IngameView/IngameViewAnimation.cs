using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameViewAnimation : BaseViewAnimation
{
    [SerializeField] RectTransform right;
    [SerializeField] RectTransform top;
    public override void OnHideAnimation(Action callback)
    {
        base.OnHideAnimation(callback);
        top.DOAnchorPosY(250, 0.25f);
        right.DOAnchorPosX(1200, 0.25f);
        right.DOAnchorPosY(162.5673f, 0.25f);
    }
    public override void OnShowAnimation(Action callback)
    {
        base.OnShowAnimation(callback);
        right.DOAnchorPosX(-495, 0.02f);
        right.DOAnchorPosY(316, 0.02f);
        top.DOAnchorPosY(-49, 0.02f);
    }
}
