using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchArm : PlayerArm {
    public override void Awake() {

    }
    // Start is called before the first frame update
    public override void PartFire(Vector3 mousePos) {
        transform.parent.parent.GetComponent<PlayerMain>().DealMeleeDamage(meleeDamage);
    }

} 
