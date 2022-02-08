using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCenter : MonoBehaviour
{
    [SerializeField] GameObject[] _enemys;
    [SerializeField] float _spanTime = 5f;
    [SerializeField] float _grow = 0.01f;
    float _nowTime;
    const float _minSpanTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        _nowTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SpanEnemy();
    }

    void SpanEnemy()
    {
        _nowTime += Time.deltaTime;
        if(_nowTime >= _spanTime)
        {
            int r = Random.Range(0, _enemys.Length);
            GameObject enemy = Instantiate(_enemys[r], transform);
            enemy.transform.position = new Vector3(Random.Range(-3f, 4f), 6f, 0f);
            Adjust_spanTime(-_grow);
            UpgradeEnemy(enemy);
            _nowTime = 0;
        }
    }

    void UpgradeEnemy(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().Upgrade(_grow);
    }

    void Adjust_spanTime(float t)
    {
        if(_spanTime + t > _minSpanTime)
        {
            _spanTime += t;
        }
    }
    
}
