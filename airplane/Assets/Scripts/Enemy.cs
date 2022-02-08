using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _HP = 100;
    [SerializeField] int moveType = 0;
    [SerializeField] float _moveSpeed = 1f;
    Rigidbody2D _rb;
    static float _growUp = 0f;
    const float _maxGrow = 1000f;
    // Start is called before the first frame update
    void Start()
    { 
        _HP += (int)(_growUp * (float)_HP);
        _moveSpeed += _growUp;
        _rb = gameObject.GetComponent<Rigidbody2D>();
        MoveStart();
    }
    
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "DeathLine")
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {   
        _HP -= damage;
        if(_HP <= 0)
        {
            Die();
        }
    }

    void MoveStart()
    {
        _rb.velocity = _moveSpeed * transform.up;
        switch(moveType)
        {
            case 0:
                break;
            default:
                break;
        }
    }

    void Move()
    {
        switch(moveType)
        {
            case 1:
                if(transform.position.y <= 4.5)
                {
                    _rb.velocity = new Vector2(0.0f, 0.0f);
                }
                break;
            default:
                break;
        }
    }

    public void Upgrade(float up = 0.5f)
    {
        if(_growUp <= _maxGrow)
            _growUp += up;
    }


    void Die()
    {
        Destroy(gameObject);
    }
}
