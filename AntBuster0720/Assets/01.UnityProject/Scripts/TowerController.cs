using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public float attackRange = 5f; // Ÿ���� ���� ����
    public GameObject bulletPrefab = default;

    public float shootRate = 1f;
    private float shootAfter = default;

    private GameObject closeEnemy = null;
    private List<GameObject> enemyList = new List<GameObject>();
    private GameObject target;

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
        if(enemyList.Count > 0) // ���� �Ѹ� �̻� �������
        {
            for(int i = 0; i < enemyList.Count; i++)
            {
                if(enemyList[i] != null)
                {
                    target = enemyList[i];
                    break;
                }
            }

            if(target != null && shootAfter > shootRate)
            {
                if(target.transform.position.x < transform.position.x)
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
        if(collision.tag == "Monster")
        {
            enemyList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach(GameObject mob in enemyList)
        {
            if(mob == collision.gameObject)
            {
                enemyList.Remove(mob);
                break;
            }
        }
    }
}
