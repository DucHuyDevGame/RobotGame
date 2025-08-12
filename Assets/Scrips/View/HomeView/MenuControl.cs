using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : BYSingletonMono<MenuControl>
{
    [SerializeField] RectTransform top;
    [SerializeField] RectTransform bottom;
    [SerializeField] RectTransform right;
    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().name == "Buffer")
            AnimHomeView();
    }
    public void AnimHomeView()
    {
        top.DOAnchorPosY(0, 0.5f);
        bottom.DOAnchorPosY(0, 0.5f);
        right.DOAnchorPosX(-555, 0.25f);
        right.DOAnchorPosY(-18, 0.5f);
    }
}
