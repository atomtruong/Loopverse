using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public string saveName = "savedGame";
    public string directoryName = "Saved";
    public SaveGameData saveGameData;
    public GameObject Player;
    public GameObject Weapon;
    public GameObject skillTree;

    public void SaveToFile()
    {
        saveGameData.maxHealth = Player.GetComponent<Health>().maxHealth;
        saveGameData.playerHealth = Player.GetComponent<Health>().getHealth();
        saveGameData.baseDamage = Player.GetComponent<PlayerStats>().baseDamage;
        saveGameData.playerExperience = Player.GetComponent<PlayerStats>().playerExperience;
        saveGameData.playerMoney = Player.GetComponent<PlayerStats>().playerMoney;
        saveGameData.unlockedShotgun = Weapon.GetComponent<WeaponSystem>().unlockedShotgun;
        saveGameData.unlockedM4 = Weapon.GetComponent<WeaponSystem>().unlockedM4;
        saveGameData.unlockedKatana = Weapon.GetComponent<WeaponSystem>().unlockedKatana;
        saveGameData.unlockedBeam = Weapon.GetComponent<WeaponSystem>().unlockedBeam;
        saveGameData.unlockedSkill1 = skillTree.GetComponent<SkillTree>().unlockedSkill1;
        saveGameData.unlockedSkill2 = skillTree.GetComponent<SkillTree>().unlockedSkill2;
        saveGameData.unlockedSkill3 = skillTree.GetComponent<SkillTree>().unlockedSkill3;


        if (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName);
        }

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream saveFile = File.Create(directoryName + "/" + saveName + ".bin");

        formatter.Serialize(saveFile, saveGameData);

        saveFile.Close();

        print("Game saved to " + Directory.GetCurrentDirectory().ToString() + "/Saved/" + saveName + ".bin");
    }
}