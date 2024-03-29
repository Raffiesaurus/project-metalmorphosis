using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : PlayerParts {

    [SerializeField] public HeadPart headPart = HeadPart.Plain;

    [SerializeField] public int ammoBoost = 0;
    [SerializeField] public float healthBoost = 0.0f;
    [SerializeField] public float fuelBoost = 0.0f;
    [SerializeField] public float speedBoost = 1.0f;
    [SerializeField] public float meleeDmgBoost = 0.0f;
    [SerializeField] public float rangeDmgBoost = 0.0f;

    [SerializeField] public bool swapAmmoHp = false;
    [SerializeField] public float hpGain = 0.0f;
    [SerializeField] public float fuelLoss = 0.0f;
    [SerializeField] public int ammoLoss = 0;

    [SerializeField] public bool bulletBounce = false;
    [SerializeField] public bool oneHitMode = false;

    [SerializeField] public bool returnDmg = false;
    [SerializeField] public float returnDmgAmount = 0.0f;

    public virtual void Awake() {

    }

    public PlayerHead AssignScript() {
        PlayerHead headAdded = null;
        switch (headPart) {

            case HeadPart.Plain:
                headAdded = gameObject.AddComponent<PlainHead>();
                break;

            case HeadPart.Fishbowl:
                headAdded = gameObject.AddComponent<FishbowlHead>();
                break;

            case HeadPart.Surgeon:
                headAdded = gameObject.AddComponent<SurgeonHead>();
                break;

            case HeadPart.Boundman:
                headAdded = gameObject.AddComponent<BoundmanHead>();
                break;

            case HeadPart.Meathead:
                headAdded = gameObject.AddComponent<MeatheadHead>();
                break;

            case HeadPart.Pinhead:
                headAdded = gameObject.AddComponent<PinheadHead>();
                break;

            case HeadPart.Neurons:
                headAdded = gameObject.AddComponent<NeuronsHead>();
                break;

            case HeadPart.Farsighted:
                headAdded = gameObject.AddComponent<FarsightedHead>();
                break;

            case HeadPart.Nearsighted:
                headAdded = gameObject.AddComponent<NearsightedHead>();
                break;

            case HeadPart.Thinker:
                headAdded = gameObject.AddComponent<ThinkerHead>();
                break;

            case HeadPart.Magnifeye:
                headAdded = gameObject.AddComponent<MagnifeyeHead>();
                break;

            case HeadPart.Minimifeye:
                headAdded = gameObject.AddComponent<MinimifeyeHead>();
                break;
        }
        Destroy(this);
        return headAdded;
    }

    public virtual void Update() {

    }

    public override void PartInstall() {

    }

    public override void PartUninstall() {

    }
}
