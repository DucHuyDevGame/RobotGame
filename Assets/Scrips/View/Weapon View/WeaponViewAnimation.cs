using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeaponViewAnimation : BaseViewAnimation
{
    public RectTransform top;
    public RectTransform left;
    public override void OnHideAnimation(Action callback)
    {
        base.OnHideAnimation(callback);
        top.DOAnchorPosY(250, 0.5f).OnComplete(() => {
         
            callback();
        });
        left.DOAnchorPosX(1200, 0.25f);
        left.DOAnchorPosY(162.5673f, 0.25f);
    }
    public override void OnShowAnimation(Action callback)
    {
        base.OnShowAnimation(callback);
        top.DOAnchorPosY(0, 0.5f).OnComplete(()=>{
            callback();
        });
        left.DOAnchorPosX(-700, 0.25f);
        left.DOAnchorPosY(-333, 0.5f);
    }
}
