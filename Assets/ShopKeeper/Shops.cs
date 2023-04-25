using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shops : MonoBehaviour
{
    public GameObject Shop;
    public GameObject SkillTree;
    public GameObject EscapeMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (Shop.gameObject.activeSelf == true && SkillTree.gameObject.activeSelf == false && EscapeMenu.gameObject.activeSelf == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Shop.gameObject.SetActive(false);
                Time.timeScale = 1;
            } else if (SkillTree.gameObject.activeSelf == false && EscapeMenu.gameObject.activeSelf == false)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Shop.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (SkillTree.gameObject.activeSelf == true && Shop.gameObject.activeSelf == false && EscapeMenu.gameObject.activeSelf == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                SkillTree.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else if (Shop.gameObject.activeSelf == false && EscapeMenu.gameObject.activeSelf == false) 
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SkillTree.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (EscapeMenu.gameObject.activeSelf == true && Shop.gameObject.activeSelf == false && SkillTree.gameObject.activeSelf == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                EscapeMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else if (SkillTree.gameObject.activeSelf == false && Shop.gameObject.activeSelf == false)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                EscapeMenu.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
