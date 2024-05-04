using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [SerializeField] private TMP_Text helpText = null;

    private GameObject newPartSpawned = null;

    private Camera sceneCam = null;

    private string partToTouch = "";

    private bool hasUninstalled = false;
    private bool hasInstalled = false;

    private int partNum;

    public void Setup(PartDropData data) {
        hasUninstalled = false;
        hasInstalled = false;
        partToTouch = "";
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
        if (partData.partType == "Left Arm") {
            MoveToLeftArm();
        } else if (partData.partType == "Right Arm") {
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
        helpText.text = "Click on left arm to uninstall.";
    }

    void MoveToRightArm() {
        partToTouch = "right_arm";
        Vector3 moveToPos = rightArmPoint.position;
        moveToPos.z -= 2.0f;
        sceneCam.transform.position = moveToPos;
        helpText.text = "Click on right arm to uninstall.";
    }

    void MoveToLeg() {
        partToTouch = "legs";
        Vector3 moveToPos = legsPoint.position;
        moveToPos.z -= 2.0f;
        sceneCam.transform.position = moveToPos;
        helpText.text = "Click on legs to uninstall.";
    }

    void MoveToHead() {
        partToTouch = "head";
        Vector3 moveToPos = headPoint.position;
        moveToPos.z -= 2.0f;
        sceneCam.transform.position = moveToPos;
        helpText.text = "Click on head to uninstall.";
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
        AudioManager.PlaySFX(AudioClips.PartUninstall);
        SpawnNewLeftArm(moveToPos);
    }

    void UninstallRightArm() {
        Vector3 moveToPos = rightArm.transform.position;
        moveToPos.x -= 5;
        rightArm.transform.position = moveToPos;
        uninstalledPart = GetArmName(PartsManager.EquippedRightArm);
        PartsManager.EquippedRightArm = ArmPart.Nail_Gun;
        GameUIManager.ShowNotification("Uninstalled " + uninstalledPart + " from right arm.");
        AudioManager.PlaySFX(AudioClips.PartUninstall);
        SpawnNewRightArm(moveToPos);
    }

    void UninstallHead() {
        Vector3 moveToPos = head.transform.position;
        moveToPos.y += 5;
        head.transform.position = moveToPos;
        uninstalledPart = GetHeadName(PartsManager.EquippedHead);
        PartsManager.EquippedHead = HeadPart.Plain;
        GameUIManager.ShowNotification("Uninstalled " + uninstalledPart + " from head.");
        AudioManager.PlaySFX(AudioClips.PartUninstall);
        SpawnNewHead(moveToPos);
    }

    void UninstallLegs() {
        Vector3 moveToPos = leg.transform.position;
        moveToPos.y -= 5;
        leg.transform.position = moveToPos;
        uninstalledPart = GetLegName(PartsManager.EquippedLeg);
        PartsManager.EquippedLeg = LegPart.Plain;
        GameUIManager.ShowNotification("Uninstalled " + uninstalledPart + " from legs.");
        AudioManager.PlaySFX(AudioClips.PartUninstall);
        SpawnNewLeg(moveToPos);
    }

    void SpawnNewLeftArm(Vector3 spawnPos) {
        partToTouch = "new_left_arm";
        spawnPos.x -= 3;
        newPartSpawned = Instantiate(arms[(int)partData.leftArm], newPartParent.transform);
        newPartSpawned.transform.position = spawnPos;
        helpText.text = "Click on new left arm to install.";
    }

    void SpawnNewRightArm(Vector3 spawnPos) {
        partToTouch = "new_right_arm";
        spawnPos.x += 3;
        newPartSpawned = Instantiate(arms[(int)partData.rightArm], newPartParent.transform);
        newPartSpawned.transform.position = spawnPos;
        helpText.text = "Click on new right arm to install.";
    }

    void SpawnNewHead(Vector3 spawnPos) {
        partToTouch = "new_head";
        spawnPos.y -= 4;
        newPartSpawned = Instantiate(heads[(int)partData.head], newPartParent.transform);
        newPartSpawned.transform.position = spawnPos;
        helpText.text = "Click on new head to install.";
    }

    void SpawnNewLeg(Vector3 spawnPos) {
        partToTouch = "new_legs";
        spawnPos.y += 4;
        newPartSpawned = Instantiate(legs[(int)partData.legs], newPartParent.transform);
        newPartSpawned.transform.position = spawnPos;
        helpText.text = "Click on new leg to install.";
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
        AudioManager.PlaySFX(AudioClips.PartInstall);
        helpText.text = "Press P to return to game.";
    }

    void InstallRightArm() {
        newPartSpawned.transform.localPosition = Vector3.zero;
        PartsManager.EquippedRightArm = partData.rightArm;
        GameUIManager.ShowNotification("Installed " + partData.partName + " in right arm.");
        partToTouch = "";
        newPartSpawned.tag = "right_arm";
        newPartSpawned.transform.parent = rightArm.transform.parent;
        rightArm = newPartSpawned;
        AudioManager.PlaySFX(AudioClips.PartInstall);
        helpText.text = "Press P to return to game.";
    }

    void InstallLegs() {
        newPartSpawned.transform.localPosition = Vector3.zero;
        PartsManager.EquippedLeg = partData.legs;
        GameUIManager.ShowNotification("Installed " + partData.partName + " in leg.");
        partToTouch = "";
        newPartSpawned.tag = "legs";
        newPartSpawned.transform.parent = leg.transform.parent;
        leg = newPartSpawned;
        AudioManager.PlaySFX(AudioClips.PartInstall);
        helpText.text = "Press P to return to game.";
    }

    void InstallHead() {
        newPartSpawned.transform.localPosition = Vector3.zero;
        PartsManager.EquippedHead = partData.head;
        GameUIManager.ShowNotification("Installed " + partData.partName + " in head.");
        partToTouch = "";
        newPartSpawned.tag = "head";
        newPartSpawned.transform.parent = head.transform.parent;
        head = newPartSpawned;
        AudioManager.PlaySFX(AudioClips.PartInstall);
        helpText.text = "Press P to return to game.";
    }

    public void Update() {
        if (!GameUIManager.IsInSwapScreen) {
            return;
        }
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
        if ((!hasUninstalled || (hasInstalled && hasUninstalled)) && Input.GetKeyDown(KeyCode.P)) {
            GameUIManager.SwitchToInGame();
        }
    }
}
