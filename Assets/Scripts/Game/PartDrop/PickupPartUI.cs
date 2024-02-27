using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PickupPartUI : MonoBehaviour {

    private PartDropData uiData;

    private GameObject linkedObject;

    [SerializeField] private TMP_Text nameText = null;
    [SerializeField] private TMP_Text rarityText = null;
    [SerializeField] private TMP_Text typeText = null;
    [SerializeField] private TMP_Text descText = null;
    [SerializeField] private SpriteRenderer image = null;

    public void SetData(PartDropData data, GameObject droppedObject) {
        uiData = data;
        linkedObject = droppedObject;
        Vector2 uiPoint = CameraManager.GetUICamera().WorldToViewportPoint(droppedObject.transform.position);
        transform.localPosition = new Vector2(uiPoint.x, uiPoint.y);
        ApplyData();
    }

    public void ApplyData() {
        nameText.text = uiData.partName;
        rarityText.text = uiData.partRarity;
        typeText.text = uiData.partType;
        descText.text = uiData.partDescription;
        image.sprite = uiData.partImage;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            GameManager.SetupSwap(uiData);
            GameUIManager.SwitchToSwapScreen();

            Destroy(linkedObject);
            Destroy(gameObject);
        } else if (Input.GetKeyDown(KeyCode.X)) {
            Destroy(linkedObject);
            Destroy(gameObject);
        }
    }

}
