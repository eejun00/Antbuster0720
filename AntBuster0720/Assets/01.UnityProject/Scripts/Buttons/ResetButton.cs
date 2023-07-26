using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public void OnClickButton()
    {
        GameManager.instance.EndGame();
    }
}
