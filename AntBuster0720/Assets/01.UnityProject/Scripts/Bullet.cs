using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 30f; // 총알 이동 속도
    public Vector3 targetPosition = Vector3.zero;
    public int bulletDamage = 1;

    private Rigidbody2D bulletRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();           
        Destroy(gameObject, 5f);
        //5초뒤 사라짐
    }

    private void OnTriggerEnter2D(Collider2D other) //플레이어 총알이 적에게 닿았을때 트리거 함수
    {
        if (other.tag == "Monster") //몬스터에게 닿았을 경우
        {
            MobController mobController = other.GetComponent<MobController>();
            mobController.Die(bulletDamage);

            Destroy(gameObject); //닿았을때 사라지게함
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(targetPosition * Time.deltaTime * bulletSpeed);
    }
  
}
