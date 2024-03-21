using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArm : PlayerParts {

    [SerializeField] public ArmPart armPart = ArmPart.Nail_Gun;
    [SerializeField] public float cooldown = 2.0f;
    [SerializeField] public float meleeDamage = 10.0f;
    [SerializeField] public float fuelUsage = 0.0f;
    [SerializeField] public int ammoUsage = 1;
    [SerializeField] public GameObject spawnPoint = null;

    [HideInInspector] public float cdCounter = 0.0f;
    [HideInInspector] public BulletType bulletType = BulletType.None;

    public virtual void Awake() {
    }

    public PlayerArm AssignScript() {
        BoxCollider2D meleeHitBox = transform.parent.GetComponentInChildren<BoxCollider2D>();
        PlayerArm armAdded = null;
        switch (armPart) {

            case ArmPart.Backfire:
                armAdded = gameObject.AddComponent<BackfireArm>();
                break;

            case ArmPart.Punch:
                armAdded = gameObject.AddComponent<PunchArm>();
                meleeHitBox.enabled = true;
                break;

            case ArmPart.Chainsaw:
                armAdded = gameObject.AddComponent<ChainsawArm>();
                meleeHitBox.enabled = true;
                break;

            case ArmPart.Bat:
                armAdded = gameObject.AddComponent<BatArm>();
                meleeHitBox.enabled = true;
                break;

            case ArmPart.Lucky_Scalpel:
                armAdded = gameObject.AddComponent<LuckyScalpelArm>();
                meleeHitBox.enabled = true;
                break;

            case ArmPart.Lefty:
                armAdded = gameObject.AddComponent<LeftyArm>();
                break;

            case ArmPart.Judy:
                armAdded = gameObject.AddComponent<JudyArm>();
                meleeHitBox.enabled = true;
                break;

            case ArmPart.Righty:
                armAdded = gameObject.AddComponent<RightyArm>();
                break;

            case ArmPart.Nail_Gun:
                armAdded = gameObject.AddComponent<NailGunArm>();
                break;

            case ArmPart.Blitzburst:
                armAdded = gameObject.AddComponent<BlitzburstArm>();
                break;

        }
        Destroy(this);
        return armAdded;
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

    public override void PartFire(Vector3 mousePos, Vector3 spawnPoint) { }

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
