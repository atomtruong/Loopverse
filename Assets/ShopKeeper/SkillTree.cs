using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillTree : MonoBehaviour
{
    public TextMeshProUGUI expText;
    public GameObject player;
    public Button skill1;
    public Button skill2;
    public Button skill3;

    public bool unlockedSkill1 = false;
    public bool unlockedSkill2 = false;
    public bool unlockedSkill3 = false;

    private void Start()
    {
        Button skl1 = skill1.GetComponent<Button>();
        Button skl2 = skill2.GetComponent<Button>();
        Button skl3 = skill3.GetComponent<Button>();

        skl1.onClick.AddListener(() => { Purchase(skill1, 5); });
        skl2.onClick.AddListener(() => { Purchase(skill2, 5); });
        skl3.onClick.AddListener(() => { Purchase(skill3, 5); });
    }

    // Update is called once per frame
    void Update()
        {
            float exp = GameObject.Find("Player").transform.gameObject.GetComponent<PlayerStats>().playerExperience;
            expText.SetText("Experience: " + exp);
        }

    public void Purchase(Button btn, float price)
    {
        PlayerStats stats = player.GetComponent<PlayerStats>();
        if (stats.playerExperience >= price)
        {
            print("Purchased");
            stats.grantExperience(-price);
            grantSkill(btn);
            btn.enabled = false;
        }
        else
        {
            print("Not Enough Experience!");
        }
    }

    void grantSkill(Button btn)
    {
        string name = btn.gameObject.transform.name;
        PlayerStats stats = player.GetComponent<PlayerStats>();

        if (name == "Skill1Button")
        {
            player.GetComponent<Health>().SetMaxHealth(125f);
            btn.interactable = false;
            skill2.enabled = true;
            skill3.enabled = true;
            unlockedSkill1 = true;
        }
        else if (name == "Skill2Button")
        {
            stats.setDamage(2);
            btn.interactable = false;
            btn.enabled = false;
            skill3.enabled = false;
            unlockedSkill2 = true;
        }
        else if (name == "Skill3Button")
        {
            btn.enabled = false;
            btn.interactable = false;
            player.GetComponent<FirstPersonCharacter>().setMovementSpeed(12f);
            unlockedSkill3 = true;
        }
    }
}
