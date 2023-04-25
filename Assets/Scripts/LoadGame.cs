using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    public string saveDirectory = "Saved";
    public string saveName = "savedGame";
    public GameObject Player;
    public GameObject Weapon;
    public GameObject skillTree;
    public GameObject waveSystem;
    public Button skill1;
    public Button skill2;
    public Button skill3;

    public void LoadFromFile()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream saveFile = File.Open(saveDirectory + "/" + saveName + ".bin", FileMode.Open);

        SaveGameData loadData = (SaveGameData)formatter.Deserialize(saveFile);

        print("~~~ LOADED GAME DATA ~~~");
        print("MAX HEALTH: " + loadData.maxHealth);
        print("PLAYER HEALTH: " + loadData.playerHealth);
        print("PLAYER BASE DAMAGE: " + loadData.baseDamage);
        print("PLAYER EXPERIENCE: " + loadData.playerExperience);
        print("PLAYER MONEY: " + loadData.playerMoney);
        print("UNLOCKED SHOTGUN: " + loadData.unlockedShotgun);
        print("UNLOCKED M4: " + loadData.unlockedM4);
        print("UNLOCKED KATANA: " + loadData.unlockedKatana);
        print("UNLOCKED BEAM: " + loadData.unlockedBeam);
        print("UNLOCKED SKILL 1: " + loadData.unlockedSkill1);
        print("UNLOCKED SKILL 2: " + loadData.unlockedSkill2);
        print("UNLOCKED SKILL 3: " + loadData.unlockedSkill3);

        Player.GetComponent<Health>().SetMaxHealth(loadData.maxHealth);
        Player.GetComponent<Health>().currentHealth = loadData.playerHealth;
        Player.GetComponent<PlayerStats>().setDamage(loadData.baseDamage);
        Player.GetComponent<PlayerStats>().setExperience(loadData.playerExperience);
        Player.GetComponent<PlayerStats>().setMoney(loadData.playerMoney);
        Weapon.GetComponent<WeaponSystem>().unlockedShotgun = loadData.unlockedShotgun;
        Weapon.GetComponent<WeaponSystem>().unlockedM4 = loadData.unlockedM4;
        Weapon.GetComponent<WeaponSystem>().unlockedKatana = loadData.unlockedKatana;
        Weapon.GetComponent<WeaponSystem>().unlockedBeam = loadData.unlockedBeam;

        if (loadData.unlockedSkill1 == true)
        {
            skillTree.GetComponent<SkillTree>().Purchase(skill1, 0);
        }
        if (loadData.unlockedSkill2 == true)
        {
            skillTree.GetComponent<SkillTree>().Purchase(skill2, 0);
        }
        if (loadData.unlockedSkill3 == true)
        {
            skillTree.GetComponent<SkillTree>().Purchase(skill3, 0);
        }

        waveSystem.GetComponent<WaveSystem>().Restart();

        saveFile.Close();
    }
}
