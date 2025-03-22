using EnhancedUI.EnhancedScroller;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponViewGunListItem : EnhancedScrollerCellView, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector3 pos_drag;
    Camera cam;
    bool isDraging;
    public Image iconGun;
    public WeaponView weaponView;
    WeaponListData wpdata;
    public TMP_Text name_txt;
    RectTransform rect_item_drag;
    public GameObject item_drag;
    public bool isValid = false;
    public LayerMask layerMask;
    string typeConfig;
    public void SetDataCell(WeaponListData data, string config)
    {
        cam = Camera.main;
        this.wpdata = data;
        this.weaponView = wpdata.weaponView;
        name_txt.text = wpdata.cf.Name;
        iconGun.sprite = SpriteLibControl.Instance.GetSpriteByName(wpdata.cf.Image);
        item_drag.GetComponent<Image>().sprite = iconGun.sprite;
        rect_item_drag = item_drag.GetComponent<RectTransform>();
        this.typeConfig = config;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDraging = true;
        wpdata.weaponView.lockUIObject.SetActive(true);
        item_drag.SetActive(true);
        item_drag.transform.SetParent(wpdata.weaponView.m_DraggingPlane, false);
        SetDraggedPosition(eventData);
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        SetDraggedPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDraging = false;
        wpdata.weaponView.lockUIObject.SetActive(false);
        item_drag.SetActive(false);
        if (isValid)
        {
            DataController.Instance.AddWeapon(typeConfig,wpdata.cf.Name);
        }
        isValid = false;
    }
    void SetDraggedPosition(PointerEventData data)
    {
        pos_drag = data.position;
        Vector2 pos_local;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(wpdata.weaponView.m_DraggingPlane, data.position, data.pressEventCamera, out pos_local);
        rect_item_drag.anchoredPosition = pos_local;
    }
    private void FixedUpdate()
    {
        if (!isDraging)
            return;
        Vector2 worldPoint = cam.ScreenToWorldPoint(pos_drag);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, Mathf.Infinity, layerMask);
        if(hit.collider != null)
        {
            isValid = true;
        }
        else
            isValid = false;
    }
}
