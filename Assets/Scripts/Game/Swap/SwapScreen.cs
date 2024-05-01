using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapScreen : MonoBehaviour {

    private PartDropData partData;
    private string uninstalledPart;

    [SerializeField] private GameObject leftArm = null;
    [SerializeField] private GameObject rightArm = null;
    [SerializeField] private GameObject leg = null;
    [SerializeField] private GameObject head = null;

    [SerializeField] private Transform leftArmPoint = null;
    [SerializeField] private Transform rightArmPoint = null;
    [SerializeField] private Transform legsPoint = null;
    [SerializeField] private Transform headPoint = null;

    [SerializeField] private GameObject[] arms;
    [SerializeField] private GameObject[] heads;
    [SerializeField] private GameObject[] legs;

    [SerializeField] private GameObject newPartParent = null;

    private GameObject newPartSpawned = null;

    private Camera sceneCam = null;

    private string partToTouch = "";

    private bool hasUninstalled = false;
    private bool hasInstalled = false;

    private int partNum;

    public void Setup(PartDropData data) {
        hasUninstalled = false;
        hasInstalled = false;
        sceneCam = CameraManager.GetEquipScreenCamera();
        partData = data;
        CheckPart();
    }

    public string GetArmName(ArmPart armNum) {
        switch (armNum) {
            case ArmPart.Backfire:
                return "Backfire";
            case ArmPart.Punch:
                return "Punch";
            case ArmPart.Chainsaw:
                return "Chainsaw";
            case ArmPart.Bat:
                return "Bat";
            case ArmPart.Lucky_Scalpel:
                return "Lucky Scalpel";
            case ArmPart.Lefty:
                return "Lefty";
            case ArmPart.Judy:
                return "Judy";
            case ArmPart.Righty:
                return "Rigty";
            case ArmPart.Nail_Gun:
                return "Nail Gun";
            case ArmPart.Blitzburst:
                return "Blitzburst";
            default:
                return "Uhoh";
        }
    }

    public string GetLegName(LegPart legNum) {
        switch (legNum) {
            case LegPart.Overclocked:
                return "Overclocked";
            case LegPart.Heavy_Artillery:
                return "Heavy Artillery";
            case LegPart.Plain:
                return "Plain";
            case LegPart.Gassy:
                return "Gassy";
            case LegPart.Dumptruck:
                return "Dumptruck";
            default:
                return "Uhoh";
        }
    }

    public string GetHeadName(HeadPart headNum) {
        switch (headNum) {
            case HeadPart.Plain:
                return "Plain";
            case HeadPart.Meathead:
                return "Meathead";
            case HeadPart.Minimifeye:
                return "Minimifeye";
            case HeadPart.Pinhead:
                return "Pinhead";
            case HeadPart.Nearsighted:
                return "Nearsighted";
            case HeadPart.Boundman:
                return "Boundman";
            case HeadPart.Fishbowl:
                return "Fishbowl";
            case HeadPart.Surgeon:
                return "Surgeon";
            case HeadPart.Neurons:
                return "Neurons";
            case HeadPart.Farsighted:
                return "Farsighted";
            case HeadPart.Thinker:
                return "Thinker";
            case HeadPart.Magnifeye:
                return "Magnifeye";
            default:
                return "Uhoh";
        }
    }

    void CheckPart() {
        if (partData.partType == "Left") {
            MoveToLeftArm();
        } else if (partData.partType == "Right") {
            MoveToRightArm();
        } else if (partData.partType == "Legs") {
            MoveToLeg();
        } else if (partData.partType == "Head") {
            MoveToHead();
        }
    }

    void MoveToLeftArm() {
        partToTouch = "left_arm";
        Vector3 moveToPos = leftArmPoint.position;
        moveToPos.z -= 2.0f;
        sceneCam.transform.position = moveToPos;
    }

    void MoveToRightArm() {
        partToTouch = "right_arm";
        Vector3 moveToPos = rightArmPoint.position;
        moveToPos.z -= 2.0f;
        sceneCam.transform.position = moveToPos;
    }

    void MoveToLeg() {
        partToTouch = "legs";
        Vector3 moveToPos = legsPoint.position;
        moveToPos.z -= 2.0f;
        sceneCam.transform.position = moveToPos;
    }

    void MoveToHead() {
        partToTouch = "head";
        Vector3 moveToPos = headPoint.position;
        moveToPos.z -= 2.0f;
        sceneCam.transform.position = moveToPos;
    }

    void Uninstall() {
        hasUninstalled = true;
        if (partToTouch == "left_arm") {
            UninstallLeftArm();
        } else if (partToTouch == "right_arm") {
            UninstallRightArm();
        } else if (partToTouch == "legs") {
            UninstallLegs();
        } else if (partToTouch == "head") {
            UninstallHead();
        }
    }

    void UninstallLeftArm() {
        Vector3 moveToPos = leftArm.transform.position;
        moveToPos.x += 5;
        leftArm.transform.position = moveToPos;

        uninstalledPart = GetArmName(PartsManager.EquippedLeftArm);
        PartsManager.EquippedLeftArm = ArmPart.Lucky_Scalpel;
        GameUIManager.ShowNotification("Uninstalled " + uninstalledPart + " from left arm.");

        SpawnNewLeftArm(moveToPos);
    }

    void UninstallRightArm() {
        Vector3 moveToPos = rightArm.transform.position;
        moveToPos.x -= 5;
        rightArm.transform.position = moveToPos;

        uninstalledPart = GetArmName(PartsManager.EquippedRightArm);
        PartsManager.EquippedRightArm = ArmPart.Nail_Gun;
        GameUIManager.ShowNotification("Uninstalled " + uninstalledPart + " from right arm.");

        SpawnNewRightArm(moveToPos);
    }

    void UninstallHead() {
        Vector3 moveToPos = head.transform.position;
        moveToPos.y += 5;
        head.transform.position = moveToPos;
        uninstalledPart = GetHeadName(PartsManager.EquippedHead);
        PartsManager.EquippedHead = HeadPart.Plain;
        GameUIManager.ShowNotification("Uninstalled " + uninstalledPart + " from head.");
        SpawnNewHead(moveToPos);
    }

    void UninstallLegs() {
        Vector3 moveToPos = leg.transform.position;
        moveToPos.y -= 5;
        leg.transform.position = moveToPos;
        uninstalledPart = GetLegName(PartsManager.EquippedLeg);
        PartsManager.EquippedLeg = LegPart.Plain;
        GameUIManager.ShowNotification("Uninstalled " + uninstalledPart + " from legs.");
        SpawnNewLeg(moveToPos);
    }

    void SpawnNewLeftArm(Vector3 spawnPos) {
        partToTouch = "new_left_arm";
        spawnPos.x -= 3;
        newPartSpawned = Instantiate(arms[(int)partData.leftArm], newPartParent.transform);
        newPartSpawned.transform.position = spawnPos;
    }

    void SpawnNewRightArm(Vector3 spawnPos) {
        partToTouch = "new_right_arm";
        spawnPos.x += 3;
        newPartSpawned = Instantiate(arms[(int)partData.rightArm], newPartParent.transform);
        newPartSpawned.transform.position = spawnPos;
    }

    void SpawnNewHead(Vector3 spawnPos) {
        partToTouch = "new_head";
        spawnPos.y -= 4;
        newPartSpawned = Instantiate(heads[(int)partData.head], newPartParent.transform);
        newPartSpawned.transform.position = spawnPos;
    }

    void SpawnNewLeg(Vector3 spawnPos) {
        partToTouch = "new_legs";
        spawnPos.y += 4;
        newPartSpawned = Instantiate(legs[(int)partData.legs], newPartParent.transform);
        newPartSpawned.transform.position = spawnPos;
    }

    void Install() {
        hasInstalled = true;

        if (partToTouch == "new_left_arm") {
            InstallLeftArm();
        } else if (partToTouch == "new_right_arm") {
            InstallRightArm();
        } else if (partToTouch == "new_legs") {
            InstallLegs();
        } else if (partToTouch == "new_head") {
            InstallHead();
        }
    }

    void InstallLeftArm() {
        newPartSpawned.transform.localPosition = Vector3.zero;
        PartsManager.EquippedLeftArm = partData.leftArm;
        GameUIManager.ShowNotification("Installed " + partData.partName + " in right arm.");
        partToTouch = "";
        newPartSpawned.tag = "left_arm";
        newPartSpawned.transform.parent = leftArm.transform.parent;
        leftArm = newPartSpawned;
    }

    void InstallRightArm() {
        newPartSpawned.transform.localPosition = Vector3.zero;
        PartsManager.EquippedRightArm = partData.rightArm;
        GameUIManager.ShowNotification("Installed " + partData.partName + " in right arm.");
        partToTouch = "";
        newPartSpawned.tag = "right_arm";
        newPartSpawned.transform.parent = rightArm.transform.parent;
        rightArm = newPartSpawned;
    }

    void InstallLegs() {
        newPartSpawned.transform.localPosition = Vector3.zero;
        PartsManager.EquippedLeg = partData.legs;
        GameUIManager.ShowNotification("Installed " + partData.partName + " in leg.");
        partToTouch = "";
        newPartSpawned.tag = "legs";
        newPartSpawned.transform.parent = leg.transform.parent;
        leg = newPartSpawned;
    }

    void InstallHead() {
        newPartSpawned.transform.localPosition = Vector3.zero;
        PartsManager.EquippedHead = partData.head;
        GameUIManager.ShowNotification("Installed " + partData.partName + " in head.");
        partToTouch = "";
        newPartSpawned.tag = "head";
        newPartSpawned.transform.parent = head.transform.parent;
        head = newPartSpawned;
    }

    public void Update() {

        if (!hasUninstalled) {
            if (Input.GetMouseButtonDown(0)) {
                Ray ray = sceneCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit)) {
                    if (hit.collider.gameObject.CompareTag(partToTouch)) {
                        Debug.Log("Touched: " + hit.collider.gameObject.name);
                        Uninstall();
                    }
                }
            }
        } else {
            if (Input.GetMouseButtonDown(0)) {
                Ray ray = sceneCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit)) {
                    if (hit.collider.gameObject.CompareTag(partToTouch)) {
                        Debug.Log("Touched: " + hit.collider.gameObject.name);
                        Install();
                    }
                }
            }
        }
        if (hasInstalled && hasUninstalled && Input.GetKeyDown(KeyCode.P)) {
            GameUIManager.SwitchToInGame();
        }
    }
}
