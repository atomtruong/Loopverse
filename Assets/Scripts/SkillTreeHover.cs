using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SkillTreeHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject textBox;
    public TextMeshProUGUI descText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == "Skill1Button")
        {
            textBox.SetActive(true);
            descText.SetText("Maximum Health Upgrade: +25hp.");
        } else if (eventData.pointerCurrentRaycast.gameObject.name == "Skill2Button")
        {
            textBox.SetActive(true);
            descText.SetText("Maximum Damage Upgrade: +1dmg.");
        } else if (eventData.pointerCurrentRaycast.gameObject.name == "Skill3Button")
        {
            textBox.SetActive(true);
            descText.SetText("Maximum Movement Speed Upgrade: 1.5x movement speed.");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textBox.SetActive(false);
    }

    
}
