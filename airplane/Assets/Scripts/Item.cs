using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 2f;
    Rigidbody2D _rb;
    string _type;
    Vector3 _vec;
    // Start is called before the first frame update
    
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.velocity = _moveSpeed * _vec;
    }

    // Update is called once per frame
    /*
    void Update()
    {
        
    }
    */

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "player")
        {
            //"HPpuls", "ATKup", "Speedup"
            switch(_type)
            {
                case "HPpuls":
                    other.GetComponent<Player>().TakeDamage(-30);
                    break;
                case "ATKup":
                    other.GetComponent<Weapon>().UpgradeDamage(20);
                    break;
                case "Speedup":
                    other.GetComponent<Player>().UpgradeSpeed(0.03f);
                    other.GetComponent<Weapon>().UpgradeSpeed(0.03f);
                    break;
            }
            Die();
        }
        else if(other.tag == "wall")
        {
            _vec[0] = -_vec[0];
            _rb.velocity = _moveSpeed * _vec;
        }
        else if(other.tag == "DeathLine")
        {
            Die();
        }
    }

    public void SetType(string type)
    {
        _type = type;
    }
    
    public void SetVelocity(Vector3 vector)
    {
        _vec = vector;
    }

    public void SetImage(Sprite image)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = image;
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
