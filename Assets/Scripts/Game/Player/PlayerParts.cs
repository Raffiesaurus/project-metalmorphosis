using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerParts : MonoBehaviour {

    [SerializeField] public SpriteRenderer img = null;
    [SerializeField] public PartType partType = PartType.Arm;
    [SerializeField] public PartRarity partRarity = PartRarity.Common;

    public bool isInstalled = false;

    public abstract void PartInstall();

    public abstract void PartUninstall();

    public abstract void PartFire(Vector3 mousePos);

    public abstract void PartUtilityActivate1(Vector3 mousePos);

    public abstract void PartUtilityActivate2(Vector3 mousePos);

}
