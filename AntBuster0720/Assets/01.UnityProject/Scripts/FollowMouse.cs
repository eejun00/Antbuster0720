using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class FollowMouse : MonoBehaviour , IPointerDownHandler
{
    public GameObject towerPrefab = default;
    private bool isClick = false;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isClick)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // 2D 게임에서는 z축 값을 0으로 설정
            transform.position = mousePosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isClick = true;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // 2D 게임에서는 z축 값을 0으로 설정
        GameObject tower = Instantiate(towerPrefab, mousePosition, Quaternion.identity);
        Destroy(gameObject);
    }


}
