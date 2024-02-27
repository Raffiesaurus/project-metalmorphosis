using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerParts : MonoBehaviour {

    [SerializeField] public SpriteRenderer img = null;
    [HideInInspector] public PartType partType = PartType.Arm;
    [HideInInspector] public PartRarity partRarity = PartRarity.Common;
    [HideInInspector] public PlayerMain player = null;

    public bool isInstalled = false;

    public virtual void Start() {
        player = GameManager.GetPlayer().GetComponent<PlayerMain>();
    }

    public virtual void PartInstall() { }

    public virtual void PartUninstall() { }

    public virtual void PartFire(Vector3 mousePos) { }

    public virtual void PartReleased(Vector3 mousePos) { }

    public virtual void PartUtilityActivate1(Vector3 mousePos) { }

    public virtual void PartUtilityActivate2(Vector3 mousePos) { }

}
