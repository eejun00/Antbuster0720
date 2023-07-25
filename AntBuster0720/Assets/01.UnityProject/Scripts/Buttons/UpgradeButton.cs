using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    GameObject uiCanvas;
    GameObject createTowerBtn;
    GameObject upgradeBtn;
    public GameObject upgradeTower7Prefab;
    public GameObject upgradeTower36Prefab;
    public GameObject upgradeTower6Prefab;
    public GameObject upgradeTower37Prefab;


    private void Awake()
    {
        uiCanvas = GFunc.GetRootObject("UiCanvas");
        createTowerBtn = uiCanvas.FindChildObject("CreateTowerBtn");
        upgradeBtn = uiCanvas.FindChildObject("UpgradeBtn");
    }
    public void OnClickButton()
    {
        if (GameManager.instance.clickedTower.name == "Tower7(Clone)")
        {
            Instantiate(upgradeTower7Prefab, GameManager.instance.clickedTower.transform.position,
            GameManager.instance.clickedTower.transform.rotation);
        }
        else if (GameManager.instance.clickedTower.name == "Tower36(Clone)")
        {
            Instantiate(upgradeTower36Prefab, GameManager.instance.clickedTower.transform.position,
            GameManager.instance.clickedTower.transform.rotation);
        }
        else if(GameManager.instance.clickedTower.name == "Tower6(Clone)")
        {
            Instantiate(upgradeTower6Prefab, GameManager.instance.clickedTower.transform.position,
            GameManager.instance.clickedTower.transform.rotation);
        }
        else if (GameManager.instance.clickedTower.name == "Tower37(Clone)")
        {
            Instantiate(upgradeTower37Prefab, GameManager.instance.clickedTower.transform.position,
            GameManager.instance.clickedTower.transform.rotation);
        }
        createTowerBtn.SetActive(true);
            upgradeBtn.SetActive(false);            
            Destroy(GameManager.instance.clickedTower);
            GameManager.instance.clickedTower = default;
        
    }
}
