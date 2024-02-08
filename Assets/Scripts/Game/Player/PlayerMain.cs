using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour {

    private PlayerControl playerControl;

    [SerializeField] private PlayerParts leftArm;
    [SerializeField] private PlayerParts rightArm;
    [SerializeField] private PlayerParts legs;
    [SerializeField] private PlayerParts head;
    [SerializeField] private PlayerParts torso;

    private void OnEnable() {
        playerControl = GetComponent<PlayerControl>();
        playerControl.enabled = true;
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnLeftClick(Vector3 mousePos) {
        leftArm.PartFire(mousePos);
    }

    public void OnRightClick(Vector3 mousePos) {
        Debug.Log("On Right Click");
        rightArm.PartFire(mousePos);
    }

    public void OnShiftClick() {

    }

    public void OnUtilityOne() {

    }

    public void OnUtilityTwo() {

    }

    void OnDeath() {
        playerControl.enabled = false;
    }
}
