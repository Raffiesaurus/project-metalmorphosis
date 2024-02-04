using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArm : PlayerParts {

    [SerializeField] public ArmType armType = ArmType.Punch;
    [SerializeField] public BulletType bulletType = BulletType.Melee;

    public override void PartInstall() {

    }

    public override void PartUninstall() {

    }

    public override void PartUtilityActivate1(Vector3 mousePos) { }

    public override void PartFire(Vector3 mousePos) { }

    public override void PartUtilityActivate2(Vector3 mousePos) { }

}
