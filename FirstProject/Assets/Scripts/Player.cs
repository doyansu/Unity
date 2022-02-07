using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;// [SerializeField] float moveSpeed = 5; 可在 unity 進行調整
    [SerializeField] int HP; // HP 值
    [SerializeField] GameObject HPBar; // HP 條
    [SerializeField] Text socreText; // Score 的文字
    GameObject currentFloor; // 確定當前樓層
    int score; // 分數值
    float scoreTime; // 經過多久時間 2 加一分
    Animator anim;
    SpriteRenderer render;

    //[SerializeField] float jumpHeight = 10f;
    //int jump = 0, doubleJump = 1;


    // Start is called before the first frame update
    void Start()
    {
        HP = 10;
        score = 0;
        scoreTime = 0f;
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        //transform.Translate(1, 0, 0); x += 1, y += 0, z += 0
        //Debug.Log("123"); (debug)
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);  // Time.deltaTime 解決不同電腦速度不同的問題
            render.flipX = true;// 腳色圖片左右轉
            anim.SetBool("run", true);// 設定 run 動畫之 "run" 變數為 true
        }
        else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            render.flipX = false;
            anim.SetBool("run", true);
        }
        else 
        {
            anim.SetBool("run", false);
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
        UPdateScore();

    }

    void OnCollisionEnter2D(Collision2D other)// 碰撞處理
    {
        //doubleJump = 1;
        if(other.gameObject.tag == "Normal")
        {
            if(other.contacts[0].normal == new Vector2(0f, 1f))// 用法向量判斷撞到階梯的哪一邊
            {
                Debug.Log("撞到第一種階梯");
                currentFloor = other.gameObject;// 調整當前 Floor
                ModifyHp(1);// 調整當前 HP
            }
        }
        else if(other.gameObject.tag == "Nails")
        {
            if(other.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log("撞到第二種階梯");
                currentFloor = other.gameObject;
                ModifyHp(-3);
                anim.SetTrigger("hurt");// 觸發受傷動畫
            }
        }
        else if(other.gameObject.tag == "Ceiling")
        {
            Debug.Log("撞到天花板");
            currentFloor.GetComponent<BoxCollider2D>().enabled = false;// 撞到天花板將腳下階梯的碰撞取消
            ModifyHp(-3);
            anim.SetTrigger("hurt");
        }
            
    }   

    void OnTriggerEnter2D(Collider2D other) {// 觸發處理
        if(other.gameObject.tag == "DeathLine")
            Debug.Log("輸掉了!");
    }

    void ModifyHp(int num)// 調整血量
    {
        HP += num;
        if(HP > 10)
            HP = 10;
        else if (HP < 0)
            HP = 0;
        UPdateHPBar();
    }

    void UPdateHPBar()// 血量更新
    {
        for(int i = 0; i < HPBar.transform.childCount; i++)
        {
            if(HP > i)
            {
                HPBar.transform.GetChild(i).gameObject.SetActive(true);
            }
            else 
            {
                HPBar.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    void UPdateScore()// 分數更新
    {
        scoreTime += Time.deltaTime;
        if(scoreTime > 2f)
        {
            score++;
            scoreTime = 0f;
            socreText.text = "Score:" + score.ToString();
        }
    }

}
