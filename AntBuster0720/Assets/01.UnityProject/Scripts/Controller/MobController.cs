using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    public float moveSpeed = 1f; // 몬스터 이동 속도
    public GameObject mushroom = default;
    public Transform startPoint; // 출발지
    public Transform endPoint;   // 목적지
    public Transform goal;      // 다시 돌아와서 끝지점

    GameObject objCanvas;
    private Vector2 currentTarget; // 현재 이동할 목표 위치
    private bool isMoving = true; // 이동 상태 여부
    private float moveTime;
    private float stopTime = 0.5f;       // 멈춰있는 시간
    private float reMoveTime = 1f;       // 다시움직이는 시간
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
        // 시작 위치를 출발지로 초기화
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

        // 1초마다 moveSpeed만큼 이동
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
