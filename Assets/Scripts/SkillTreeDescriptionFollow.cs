using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeDescriptionFollow : MonoBehaviour
{

    private void Start()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x + 150, Input.mousePosition.y + 100, Input.mousePosition.z);
        transform.position = mousePos;
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x+150, Input.mousePosition.y+100, Input.mousePosition.z);
        transform.position = mousePos;
    }
}
