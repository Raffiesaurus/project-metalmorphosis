using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerArm : PlayerParts {

    [SerializeField] public ArmPart armPart = ArmPart.Nail_Gun;
    [SerializeField] public float cooldown = 2.0f;
    [SerializeField] public float meleeDamage = 10.0f;
    [SerializeField] public int ammoUsage = 1;

    [HideInInspector] public float cdCounter = 0.0f;
    [HideInInspector] public BulletType bulletType = BulletType.Melee;

    public virtual void Awake() {
        PlayerArm newCompAdded = this;

        switch (armPart) {

            case ArmPart.Backfire:
                newCompAdded = gameObject.AddComponent<NailGunArm>();
                break;

            case ArmPart.Punch:
                newCompAdded = gameObject.AddComponent<NailGunArm>();
                break;

            case ArmPart.Chainsaw:
                newCompAdded = gameObject.AddComponent<NailGunArm>();
                break;

            case ArmPart.Bat:
                newCompAdded = gameObject.AddComponent<NailGunArm>();
                break;

            case ArmPart.Lucky_Scalpel:
                newCompAdded = gameObject.AddComponent<NailGunArm>();
                break;

            case ArmPart.Lefty:
                newCompAdded = gameObject.AddComponent<LeftyArm>();
                break;

            case ArmPart.Judy:
                newCompAdded = gameObject.AddComponent<NailGunArm>();
                break;

            case ArmPart.Righty:
                newCompAdded = gameObject.AddComponent<RightyArm>();
                break;

            case ArmPart.Nail_Gun:
                newCompAdded = gameObject.AddComponent<NailGunArm>();
                break;

            case ArmPart.Brrrrr:
                newCompAdded = gameObject.AddComponent<NailGunArm>();
                break;

        }
        newCompAdded.SetData(cooldown, meleeDamage, ammoUsage);
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
    public void SetData(float cd, float mDmg, int ammoUse) {
        cooldown = cd;
        meleeDamage = mDmg;
        ammoUsage = ammoUse;
    }
}
