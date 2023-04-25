using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct SaveGameData
{
    public float maxHealth;
    public float playerHealth;
    public float baseDamage;
    public float playerExperience;
    public float playerMoney;
    public bool unlockedShotgun;
    public bool unlockedM4;
    public bool unlockedKatana;
    public bool unlockedBeam;
    public bool unlockedSkill1;
    public bool unlockedSkill2;
    public bool unlockedSkill3;
}
