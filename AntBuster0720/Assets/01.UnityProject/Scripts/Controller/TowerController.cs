using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerController : MonoBehaviour, IPointerClickHandler
{
    public float attackRange = 5f; // Ÿ���� ���� ����
    public GameObject bulletPrefab = default;

    public float shootRate = 1f;
    private float shootAfter = default;

    private GameObject closeEnemy = null;
    private List<GameObject> enemyList = new List<GameObject>();
    private GameObject target;

    GameObject uiCanvas;
    GameObject createTowerBtn;
    GameObject upgradeBtn;
    GameObject buttonImg;

    public Sprite towerUpgradeImg;

    private void Awake()
    {
        uiCanvas = GFunc.GetRootObject("UiCanvas");
    }

    // Start is called before the first frame update
    void Start()
    {
        shootAfter = 0f;
        //target = FindObjectOfType<MobController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        shootAfter += Time.deltaTime;
        if (enemyList.Count > 0) // ���� �Ѹ� �̻� �������
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (enemyList[i] != null)
                {
                    target = enemyList[i];
                    break;
                }
            }

            if (target != null && shootAfter > shootRate)
            {
                if (target.transform.position.x < transform.position.x)
                {
                    // ������Ʈ�� Sprite Renderer�� �����ɴϴ�.
                    SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

                    // flipX �Ӽ��� ����Ͽ� ������Ʈ�� �������ϴ�.
                    spriteRenderer.flipX = false;
                }
                else
                {
                    // ������Ʈ�� Sprite Renderer�� �����ɴϴ�.
                    SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

                    // flipX �Ӽ��� ����Ͽ� ������Ʈ�� �������ϴ�.
                    spriteRenderer.flipX = true;
                }
                shootAfter = 0f;
                GameObject bullet = Instantiate(bulletPrefab,
                    transform.position, Quaternion.identity, transform);
                bullet.GetComponent<Bullet>().targetPosition =
                    (target.transform.position - transform.position).normalized;
                bullet.transform.localScale = new Vector3(1.0f, 1.0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            enemyList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (GameObject mob in enemyList)
        {
            if (mob == collision.gameObject)
            {
                enemyList.Remove(mob);
                break;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        createTowerBtn = uiCanvas.FindChildObject("CreateTowerBtn");
        upgradeBtn = uiCanvas.FindChildObject("UpgradeBtn");
        buttonImg = uiCanvas.FindChildObject("UpTowerImg");
        GameManager.instance.clickedTower = gameObject;
        Image buttonImgComponent = buttonImg.GetComponent<Image>();

        buttonImgComponent.sprite = towerUpgradeImg;
        
        createTowerBtn.SetActive(false);
        upgradeBtn.SetActive(true);
    }
}
