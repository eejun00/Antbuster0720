using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject MonsterPrefeb;    // ��ȯ�� ���� ������
    private int spawnCount;             // ���� �ϸ��� ������ ī��Ʈ ����
    private float spawnTime;            // ���� ���� ���ִ� �ð� ����
    private float afterSpawnTime;       // ���� �ֱ� �ð� ����
    private float timeSinsceLastSpawn;  // ������ ���� ���� ������ �ð� ����
    private float spawnInterval = 0.6f; // ���� �������� 0.5��
    private bool isWaveActive;          // ���̺갡 Ȱ��ȭ ������ ����



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
        }   // if: ���̺갡 Ȱ��ȭ ���� ���
        else
        {
            spawnTime += Time.deltaTime;
            if(spawnTime > afterSpawnTime)
            {
                StartWave();
            }
        }   // else: ���̺갡 ��Ȱ��ȭ ���� ���
    }

    private void StartWave()
    {
        isWaveActive = true;
        spawnTime = 0f;
        spawnCount = 0; // ���� ����ī��Ʈ �ʱ�ȭ
        afterSpawnTime= 10f; //10�ʸ��� ���̺� ����

        timeSinsceLastSpawn = 0f;
        //������ �������� ����ð��� �ʱ�ȭ�Ѵ�.

    }

    private void SpawnMonster()
    {        
        GameObject monster = Instantiate(MonsterPrefeb, transform.position, transform.rotation);
        spawnCount += 1;
        if(spawnCount > 5) // 6���� ��ȯ�� ���̺� ����
        {
            isWaveActive = false;
            gameManager.PlusWaveLevel();
        }
    }
}
