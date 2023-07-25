using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject MonsterPrefeb;    // 소환될 몬스터 프리팹
    private int spawnCount;             // 스폰 턴마다 마릿수 카운트 변수
    private float spawnTime;            // 스폰 턴을 세주는 시간 변수
    private float afterSpawnTime;       // 스폰 주기 시간 변수
    private float timeSinsceLastSpawn;  // 마지막 몬스터 스폰 이후의 시간 변수
    private float spawnInterval = 0.6f; // 몬스터 스폰간격 0.5초
    private bool isWaveActive;          // 웨이브가 활성화 중인지 여부



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
        spawnTime = 0f;
        afterSpawnTime = 0f;
        timeSinsceLastSpawn = 0f;
        spawnCount = 0;
        isWaveActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isWaveActive)
        {
            timeSinsceLastSpawn += Time.deltaTime;
            if(timeSinsceLastSpawn > spawnInterval)
            {
                timeSinsceLastSpawn = 0f;
                SpawnMonster();
            }
        }   // if: 웨이브가 활성화 중인 경우
        else
        {
            spawnTime += Time.deltaTime;
            if(spawnTime > afterSpawnTime)
            {
                StartWave();
            }
        }   // else: 웨이브가 비활성화 중인 경우
    }

    private void StartWave()
    {
        isWaveActive = true;
        spawnTime = 0f;
        spawnCount = 0; // 몬스터 스폰카운트 초기화
        afterSpawnTime= 10f; //10초마다 웨이브 시작

        timeSinsceLastSpawn = 0f;
        //마지막 스폰이후 경과시간을 초기화한다.

    }

    private void SpawnMonster()
    {        
        GameObject monster = Instantiate(MonsterPrefeb, transform.position, transform.rotation);
        spawnCount += 1;
        if(spawnCount > 5) // 6마리 소환시 웨이브 종료
        {
            isWaveActive = false;
            gameManager.PlusWaveLevel();
        }
    }
}
