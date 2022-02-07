using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed = 5;// [SerializeField] float moveSpeed = 5; 可在 unity 進行調整
    public float jumpHeight = 10;
    int jump = 0, doubleJump = 1;


    // Start is called before the first frame update
    void Start()
    {
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

        if(doubleJump > 0 && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
        {
            transform.Translate(0, 30 * jumpHeight * Time.deltaTime, 0);
            doubleJump--;
            jump += (int)jumpHeight * 10;
        }
        if(jump > 0){
            transform.Translate(0, jumpHeight * Time.deltaTime, 0);
            jump--;
        }
            
        /*
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
        */
    }

    void OnCollisionEnter2D(Collision2D other)// 碰撞處理
    {
        doubleJump = 1;
        if(other.gameObject.tag == "Normal")
            Debug.Log("bong1");
        else if(other.gameObject.tag == "Nails")
            Debug.Log("bong2");
    }   

    void OnTriggerEnter2D(Collider2D other) {// 觸發處理
        if(other.gameObject.tag == "DeathLine")
            Debug.Log("lose");
    }

}
