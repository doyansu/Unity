using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] string _parentName = "NoParent";
    [SerializeField] int _damage = 10;
    [SerializeField] float _speed = 20f;
    Rigidbody2D _rb;
    string _parentTag;
    Vector3 _vec;
    // Start is called before the first frame update
    void Start()
    {
        //bullet.transform.SetParent(GameObject.Find("BulletBank").transform);
        GameObject parent = GameObject.Find(_parentName);
        if(parent != null)
        {
            transform.SetParent(parent.transform);
        }
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.velocity = _speed * _vec;
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    void OnTriggerEnter2D(Collider2D other) {
        Enemy enemy = other.GetComponent<Enemy>();
        Player player = other.GetComponent<Player>();
        if(other.tag != _parentTag)
        {
            if(enemy != null)
            {
                enemy.TakeDamage(_damage);
                Die();
            }
            else if(player != null)
            {
                player.TakeDamage(_damage);
                Die();
            }
            else if(other.tag == "wall")
            {
                Die();
            }
        }
        
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void SetParent(string parent)
    {
        _parentTag = parent;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
    
    public void SetVelocity(Vector3 vector)
    {
        //Debug.Log(vector);
        _vec = vector;
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }
}
