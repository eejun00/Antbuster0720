using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    public float moveSpeed = 1f; // ���� �̵� �ӵ�
    public GameObject mushroom = default;
    public Transform startPoint; // �����
    public Transform endPoint;   // ������
    public Transform goal;      // �ٽ� ���ƿͼ� ������

    GameObject objCanvas;
    private Vector2 currentTarget; // ���� �̵��� ��ǥ ��ġ
    private bool isMoving = true; // �̵� ���� ����
    private float moveTime;
    private float stopTime = 0.5f;       // �����ִ� �ð�
    private float reMoveTime = 1f;       // �ٽÿ����̴� �ð�
    private bool arriveDest = false;

    public int maxHp = 4;
    private int currentHp;

    private void Awake()
    {
        objCanvas = GFunc.GetRootObject("ObjCanvas");
        startPoint = objCanvas.FindChildObject("MonsterSpawner").transform;
        endPoint = objCanvas.FindChildObject("Destination").transform;
        goal = objCanvas.FindChildObject("MonsterSpawner").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        // ���� ��ġ�� ������� �ʱ�ȭ
        transform.position = startPoint.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        moveTime += Time.deltaTime;
        if (moveTime < stopTime)
        {
            isMoving = false;

        }
        else if (moveTime > reMoveTime)
        {
            moveTime = 0f;

        }
        else if (moveTime >= stopTime)
        {
            isMoving = true;
 

        }


        if (isMoving)
        {
            if (Random.value > 0.3f)
            {
                MoveToTarget();
            }
            else
            {
                RandomizeDirection();
            }

        }

        if(arriveDest && Vector2.Distance(transform.position, new Vector2(-9f,5f)) < 1.0f)
        {
            ArriveMob();
        }

        if (!arriveDest && Vector2.Distance(transform.position, endPoint.position) < 0.1f)
        {
            
            if (GameManager.instance.mushCount > 0)
            {
                Destination destination = FindAnyObjectByType<Destination>();
                Transform temp = endPoint;
                endPoint = startPoint;
                startPoint = temp;
                arriveDest = true;
                mushroom.SetActive(true);
                GameManager.instance.mushCount -= 1;
                Debug.Log(GameManager.instance.mushCount);
                destination.life_[GameManager.instance.mushCount].SetActive(false);
                
            }
            
        }
        
    }

    private void MoveToTarget()
    {
        Vector2 direction = (endPoint.position - transform.position).normalized;

        // 1�ʸ��� moveSpeed��ŭ �̵�
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
    }

    private void RandomizeDirection()
    {
        if (arriveDest)
        {
            float randomX = Random.Range(-1f, 0f);
            float randomY = Random.Range(-2f, 2f);
            Vector2 direction = new Vector2(randomX, randomY).normalized;
            transform.position += (Vector3)direction * moveSpeed * 5f * Time.deltaTime;
        }
        else if (!arriveDest && transform.position.x < 8f)
        {
            float randomX = Random.Range(0f, 1f);
            float randomY = Random.Range(-2f, 2f);
            Vector2 direction = new Vector2(randomX, randomY).normalized;
            transform.position += (Vector3)direction * moveSpeed * 5f * Time.deltaTime;
        }    
    }

    private void ArriveMob()
    {
        Destroy(gameObject);
        GameManager.instance.life -= 1;
    }

    public void Die(int damage)
    {
        if (currentHp > damage)
        {
            currentHp -= damage;
        }
        else
        {
            if(GameManager.instance.mushCount < 8 && arriveDest)
            {
                Destination destination = FindAnyObjectByType<Destination>();
                destination.life_[GameManager.instance.mushCount].SetActive(true);
                GameManager.instance.mushCount++;
            }
            GameManager.instance.AddScore(1);
            GameManager.instance.GetMoney(20);
            Destroy(gameObject);
        }
    }
}
