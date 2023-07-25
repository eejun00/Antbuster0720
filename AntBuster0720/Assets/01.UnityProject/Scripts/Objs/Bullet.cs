using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 30f; // �Ѿ� �̵� �ӵ�
    public Vector3 targetPosition = Vector3.zero;
    public int bulletDamage = 1;

    private Rigidbody2D bulletRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();           
        Destroy(gameObject, 5f);
        //5�ʵ� �����
    }

    private void OnTriggerEnter2D(Collider2D other) //�÷��̾� �Ѿ��� ������ ������� Ʈ���� �Լ�
    {
        if (other.tag == "Monster") //���Ϳ��� ����� ���
        {
            MobController mobController = other.GetComponent<MobController>();
            mobController.Die(bulletDamage);

            Destroy(gameObject); //������� ���������
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(targetPosition * Time.deltaTime * bulletSpeed);
    }
  
}
