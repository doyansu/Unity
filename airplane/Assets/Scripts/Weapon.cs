using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform _firePoint = null;
    [SerializeField] Bullet[] _bullets;
    [SerializeField] string _target = "NoTarget";
    [SerializeField] int _damage = 10;
    [SerializeField] float _IntervalTime = 0.35f; 
    [SerializeField] float _bulletSpeed = 15f;
    int _bulletType;
    float _nowTime;
    const int _maxDamage = 10000;
    const float _minInterTime = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        _bulletType = 0;
        _nowTime = 0;
    }
    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void UpgradeDamage(int up)
    {
        if(_damage + up < _maxDamage)
        {
            Debug.Log("武器升級 10 點傷害");
            _damage += up;
        }
    }

    public void UpgradeSpeed(float t)
    {
        if(_IntervalTime - t >= _minInterTime)
        {
            Debug.Log("武器升級 速度加快");
            _IntervalTime -= t;
        }
    }
    public void UpgradeBullet()
    {
        if(_bulletType < _bullets.Length)
            _bulletType++;
    }
    public void Shoot()
    {
        _nowTime += Time.deltaTime;
        if(_nowTime >= _IntervalTime && _firePoint != null)
        {
            Bullet bullet = Instantiate(_bullets[_bulletType], _firePoint.position, _firePoint.rotation);
            bullet.SetParent(gameObject.tag);
            bullet.SetSpeed(_bulletSpeed);
            bullet.SetDamage(_damage);
            GameObject target = GameObject.Find(_target);
            if(target != null)
            {
                Vector3 v = target.transform.position - transform.position;
                bullet.SetVelocity(v / Mathf.Sqrt(v.x * v.x + v.y * v.y));
                //Debug.Log(Mathf.Atan(v.y / v.x) * (180.0f / Mathf.PI));
                bullet.transform.Rotate(0f, 0f, Mathf.Atan(v.x / v.y) * (180f / Mathf.PI));
            }
            else
            {
                bullet.SetVelocity(bullet.transform.up);
            }
            _nowTime = 0;
        }
    }
}
