using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject MonsterPrefeb;    // ��ȯ�� ���� ������
    private int spawnCount;             // ���� �ϸ��� ������ ī��Ʈ ����
    private float spawnTime;            // ���� ���� ���ִ� �ð� ����
    private float afterSpawnTime;       // ���� �ֱ� �ð� ����

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
