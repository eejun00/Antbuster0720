using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellButton : MonoBehaviour
{
    GameObject uiCanvas;
    GameObject createTowerBtn;
    GameObject upgradeBtn;

    private void Awake()
    {
        uiCanvas = GFunc.GetRootObject("UiCanvas");
        createTowerBtn = uiCanvas.FindChildObject("CreateTowerBtn");
        upgradeBtn = uiCanvas.FindChildObject("UpgradeBtn");
    }

    public void OnClickButton()
    {
        createTowerBtn.SetActive(true);
        upgradeBtn.SetActive(false);
        Destroy(GameManager.instance.clickedTower);
        if (GameManager.instance.clickedTower.name == "Tower7(Clone)" || GameManager.instance.clickedTower.name == "Tower36(Clone)")
        {
            GameManager.instance.GetMoney(50);
        }
        else if(GameManager.instance.clickedTower.name == "Tower6(Clone)" || GameManager.instance.clickedTower.name == "Tower37(Clone)")
        {
            GameManager.instance.GetMoney(100);
        }
        else if (GameManager.instance.clickedTower.name == "Tower5(Clone)" || GameManager.instance.clickedTower.name == "Tower38(Clone)")
        {
            GameManager.instance.GetMoney(200);
        }
            GameManager.instance.clickedTower = default;
    }
}
