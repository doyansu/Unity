using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;// [SerializeField] float moveSpeed = 5; 可在 unity 進行調整
    public float jumpHeight = 10f;
    public int HP;
    GameObject currentFloor;
    //int jump = 0, doubleJump = 1;

    // Start is called before the first frame update
    void Start()
    {
        HP = 10;
        //transform.Translate(1, 0, 0); x += 1, y += 0, z += 0
        //Debug.Log("123"); (debug)
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);  // Time.deltaTime 解決不同電腦速度不同的問題
        }
        else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }

        /*if(doubleJump > 0 && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
        {
            transform.Translate(0, 30 * jumpHeight * Time.deltaTime, 0);
            doubleJump--;
            jump += (int)jumpHeight * 10;
        }
        if(jump > 0){
            transform.Translate(0, jumpHeight * Time.deltaTime, 0);
            jump--;
        }
            
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
        */
    }

    void OnCollisionEnter2D(Collision2D other)// 碰撞處理
    {
        //doubleJump = 1;
        if(other.gameObject.tag == "Normal")
        {
            if(other.contacts[0].normal == new Vector2(0f, 1f))// 用法向量判斷撞到階梯的哪一邊
            {
                currentFloor = other.gameObject;
                ModifyHp(1);
                Debug.Log("撞到第一種階梯");
            }
        }
        else if(other.gameObject.tag == "Nails")
        {
            if(other.contacts[0].normal == new Vector2(0f, 1f))
            {
                currentFloor = other.gameObject;
                ModifyHp(-3);
                Debug.Log("撞到第二種階梯");
            }
        }
        else if(other.gameObject.tag == "Ceiling")
        {
            currentFloor.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("撞到天花板");
        }
            
    }   

    void OnTriggerEnter2D(Collider2D other) {// 觸發處理
        if(other.gameObject.tag == "DeathLine")
            Debug.Log("輸掉了!");
    }

    void ModifyHp(int num)
    {
        HP += num;
        if(HP > 10)
            HP = 10;
        else if (HP < 0)
            HP = 0;
    }

}
