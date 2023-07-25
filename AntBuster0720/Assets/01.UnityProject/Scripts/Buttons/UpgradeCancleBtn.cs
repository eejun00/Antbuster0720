using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCancleBtn : MonoBehaviour
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
        GameManager.instance.clickedTower = default;
    }
}
