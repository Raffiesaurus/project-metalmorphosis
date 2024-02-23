using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyDropProperties {
    [SerializeField] public float partDropChance = 0.0f;
    [SerializeField] public float commonDropChance = 0.0f;
    [SerializeField] public float rareDropChance = 0.0f;
    [SerializeField] public float epicDropChance = 0.0f;
}
public class DropsManager : MonoBehaviour {
    private static DropsManager instance = null;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public static void DropArm(PartRarity rarity, Vector2 spawnPoint) {
        PrefabManager.SpawnDroppablePart(PartType.Arm, rarity, spawnPoint);
    }

    public static void DropLeg(PartRarity rarity, Vector2 spawnPoint) {
        PrefabManager.SpawnDroppablePart(PartType.Leg, rarity, spawnPoint);
    }

    public static void DropHead(PartRarity rarity, Vector2 spawnPoint) {
        PrefabManager.SpawnDroppablePart(PartType.Head, rarity, spawnPoint);
    }
}
