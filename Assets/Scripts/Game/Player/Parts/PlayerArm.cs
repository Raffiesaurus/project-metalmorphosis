using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerArm : PlayerParts {

    [SerializeField] public ArmType armType = ArmType.Punch;
    [SerializeField] public BulletType bulletType = BulletType.Melee;
    [SerializeField] public float cooldown = 2.0f;
    [SerializeField] public float meleeDamage = 10.0f;

    public virtual void Awake() {
        if (bulletType == BulletType.Melee) {
            if (armType == ArmType.Punch) {
                PunchArm addedComp = gameObject.AddComponent<PunchArm>();
                addedComp.SetData(armType, bulletType, partType, partRarity);
                Destroy(this);
            }
        } else {
            if (armType == ArmType.SmallGun) {
                SmallBulletArm addedComp = gameObject.AddComponent<SmallBulletArm>();
                addedComp.SetData(armType, bulletType, partType, partRarity);
                Destroy(this);
            }
        }
    }

    public override void PartInstall() {

    }

    public override void PartUninstall() {

    }

    public override void PartUtilityActivate1(Vector3 mousePos) { }

    public override void PartFire(Vector3 mousePos) { }

    public override void PartUtilityActivate2(Vector3 mousePos) { }

    public void SetData(ArmType newArmType, BulletType newBulletType, PartType newPartType, PartRarity newPartRarity) {
        armType = newArmType;
        bulletType = newBulletType;
        partType = newPartType;
        partRarity = newPartRarity;
    }

}
