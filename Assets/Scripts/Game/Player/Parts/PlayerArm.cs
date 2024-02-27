using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerArm : PlayerParts {

    [SerializeField] public ArmPart armPart = ArmPart.Nail_Gun;
    [SerializeField] public float cooldown = 2.0f;
    [SerializeField] public float meleeDamage = 10.0f;
    [SerializeField] public float fuelUsage = 0.0f;
    [SerializeField] public int ammoUsage = 1;

    [HideInInspector] public float cdCounter = 0.0f;
    [HideInInspector] public BulletType bulletType = BulletType.None;

    public virtual void Awake() {
        //AssignScript();
    }

    public void AssignScript() {
        BoxCollider2D meleeHitBox = transform.parent.GetComponentInChildren<BoxCollider2D>();
        Debug.Log(name + " " + armPart);
        switch (armPart) {

            case ArmPart.Backfire:
                gameObject.AddComponent<BackfireArm>();
                break;

            case ArmPart.Punch:
                gameObject.AddComponent<PunchArm>();
                meleeHitBox.enabled = true;
                break;

            case ArmPart.Chainsaw:
                gameObject.AddComponent<ChainsawArm>();
                meleeHitBox.enabled = true;
                break;

            case ArmPart.Bat:
                gameObject.AddComponent<BatArm>();
                meleeHitBox.enabled = true;
                break;

            case ArmPart.Lucky_Scalpel:
                gameObject.AddComponent<LuckyScalpelArm>();
                meleeHitBox.enabled = true;
                break;

            case ArmPart.Lefty:
                gameObject.AddComponent<LeftyArm>();
                break;

            case ArmPart.Judy:
                gameObject.AddComponent<JudyArm>();
                meleeHitBox.enabled = true;
                break;

            case ArmPart.Righty:
                gameObject.AddComponent<RightyArm>();
                break;

            case ArmPart.Nail_Gun:
                gameObject.AddComponent<NailGunArm>();
                break;

            case ArmPart.Blitzburst:
                gameObject.AddComponent<BlitzburstArm>();
                break;

        }

        Destroy(this);
    }

    public virtual void Update() {
        if (cdCounter > 0) {
            cdCounter -= Time.deltaTime;
        }
    }

    public override void PartInstall() {

    }

    public override void PartUninstall() {

    }

    public override void PartUtilityActivate1(Vector3 mousePos) { }

    public override void PartFire(Vector3 mousePos) { }

    public override void PartUtilityActivate2(Vector3 mousePos) { }

    public override void PartReleased(Vector3 mousePos) {
        player.UpdateDamageReductionPercentage(0);
    }
    public void SetData(float cd, float mDmg, int ammoUse, float fuelUse) {
        cooldown = cd;
        meleeDamage = mDmg;
        ammoUsage = ammoUse;
        fuelUsage = fuelUse;
    }
}
