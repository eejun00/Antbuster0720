using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    public GameObject[] life = new GameObject[8];
    public GameObject[] life_ = new GameObject[8];
    GameManager gameManager = new GameManager();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < life.Length; i++)
        {
            life_[i] = Instantiate(life[i], life[i].transform.position, transform.rotation);
        }
        life_[0].transform.position = new Vector3(7.25f,-1.25f);
        life_[1].transform.position = new Vector2(7.75f,-1.25f);
        life_[2].transform.position = new Vector2(8.25f, -1.25f);
        life_[3].transform.position = new Vector2(8.75f, -1.25f);
        life_[4].transform.position = new Vector2(7.25f, -2.25f);
        life_[5].transform.position = new Vector2(7.75f, -2.25f);
        life_[6].transform.position = new Vector2(8.25f, -2.25f);
        life_[7].transform.position = new Vector2(8.75f, -2.25f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
