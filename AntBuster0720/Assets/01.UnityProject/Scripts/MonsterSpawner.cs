using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject MonsterPrefeb;    // 소환될 몬스터 프리팹
    private int spawnCount;             // 스폰 턴마다 마릿수 카운트 변수
    private float spawnTime;            // 스폰 턴을 세주는 시간 변수
    private float afterSpawnTime;       // 스폰 주기 시간 변수

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = 0f;
        afterSpawnTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        if(spawnTime > afterSpawnTime)
        {
            spawnTime = 0f;
            //for(int i = 0; i < spawnCount; i++)
            //{
                GameObject monster = Instantiate(MonsterPrefeb, transform.position, transform.rotation);
            //}
            afterSpawnTime = 5f;
        }
    }
}
