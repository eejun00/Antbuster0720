using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    
    public GameObject towerImage = default;
    public void OnClickButton()
    {
        if (GameManager.instance.money >= 100)
        { 
        GameManager.instance.GetMoney(-100);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        GameObject tower = Instantiate(towerImage, mousePosition, Quaternion.identity);
        }
    }
}
