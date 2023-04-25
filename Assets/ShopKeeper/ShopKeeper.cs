using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopKeeper : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public GameObject player;
    public PlayerStats stats;
    public Button shop1;
    public Button shop2;
    public Button shop3;
    public Button shop4;

    private void Start()
    {
        Button shp1 = shop1.GetComponent<Button>();
        Button shp2 = shop2.GetComponent<Button>();
        Button shp3 = shop3.GetComponent<Button>();
        Button shp4 = shop4.GetComponent<Button>();

        shp1.onClick.AddListener(() => { Purchase(shp1, 20); });
        shp2.onClick.AddListener(() => { Purchase(shp2, 50); });
        shp3.onClick.AddListener(() => { Purchase(shp3, 50); });
        shp4.onClick.AddListener(() => { Purchase(shp4, 500); });

    }

    // Update is called once per frame
    private void Update()
    {
        float money = GameObject.Find("Player").transform.gameObject.GetComponent<PlayerStats>().playerMoney;
        moneyText.SetText("Money: " + money);
    }

    void Purchase(Button btn, float price)
    {
        if (stats.playerMoney >= price)
        {
            print("Purchased");
            stats.grantMoney(-price);
            unlockWeapon(btn);
            btn.enabled = false;
        } else
        {
            print("Not Enough Money!");
        }
    }

    void unlockWeapon(Button btn)
    {
        string name = btn.gameObject.transform.name;

        if (name == "Shotgun")
        {
            player.gameObject.GetComponent<WeaponSystem>().unlockedShotgun = true;
        } 
        else if (name == "M4A1")
        {
            player.gameObject.GetComponent<WeaponSystem>().unlockedM4 = true;
        }
        else if (name == "Katana")
        {
            player.gameObject.GetComponent<WeaponSystem>().unlockedKatana = true;
        }
        else if (name == "Beam Gun")
        {
            player.gameObject.GetComponent<WeaponSystem>().unlockedBeam = true;
        }
    }

}
