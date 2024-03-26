using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : PlayerParts {

    [SerializeField] public HeadPart headPart = HeadPart.Plain;

    [SerializeField] public int ammoChange = 0;
    [SerializeField] public float healthChange = 0.0f;
    [SerializeField] public float fuelChange = 0.0f;
    [SerializeField] public float speedChange = 1.0f;
    [SerializeField] public float meleeDmgChange = 0.0f;
    [SerializeField] public float rangeDmgChange = 0.0f;
    
    [SerializeField] public bool swapAmmoHp = false;
    [SerializeField] public float hpGain = 0.0f;
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
                headAdded = gameObject.AddComponent<PlainHead>();
                break;

            case HeadPart.Surgeon:
                headAdded = gameObject.AddComponent<PlainHead>();
                break;

            case HeadPart.Boundman:
                headAdded = gameObject.AddComponent<PlainHead>();
                break;

            case HeadPart.Meathead:
                headAdded = gameObject.AddComponent<PlainHead>();
                break;

            case HeadPart.Pinhead:
                headAdded = gameObject.AddComponent<PlainHead>();
                break;

            case HeadPart.Neurons:
                headAdded = gameObject.AddComponent<PlainHead>();
                break;

            case HeadPart.Farsighted:
                headAdded = gameObject.AddComponent<PlainHead>();
                break;

            case HeadPart.Nearsighted:
                headAdded = gameObject.AddComponent<PlainHead>();
                break;

            case HeadPart.Thinker:
                headAdded = gameObject.AddComponent<PlainHead>();
                break;

            case HeadPart.Magnifeye:
                headAdded = gameObject.AddComponent<PlainHead>();
                break;

            case HeadPart.Minimifeye:
                headAdded = gameObject.AddComponent<PlainHead>();
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
