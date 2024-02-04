using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBulletArm : PlayerArm
{
    public override void PartFire(Vector3 mousePos) {
        Debug.Log("Small bullet fired!");

    }
}
