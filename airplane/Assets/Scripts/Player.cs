using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int _HP = 300;
    [SerializeField] float _moveSpeed = 5f;
    const int _maxHP = 300;
    const float _maxMoveSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(gameObject.GetComponent<SpriteRenderer>().sprite.GetType());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(_moveSpeed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-_moveSpeed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, _moveSpeed * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -_moveSpeed * Time.deltaTime, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "enemy")
        {
            TakeDamage(30);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        //Debug.Log("撞到敵人!!!");
    }

    public void TakeDamage(int damage)
    {   
        Debug.Log("受到" + damage.ToString() + "點傷害");
        _HP -= damage;
        if(_HP >= _maxHP)
        {
            _HP = _maxHP;
        }
        if(_HP <= 0)
        {
            Die();
        }
    }

    public void UpgradeSpeed(float s)
    {
        if(_moveSpeed <= _maxMoveSpeed){
            _moveSpeed += s;
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Time.timeScale = 0f;
    }
}

