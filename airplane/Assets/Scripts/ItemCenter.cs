using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCenter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float _spanTime = 20f;
    [SerializeField] GameObject _item;
    [SerializeField] Sprite[] _images;
    string[] _items = {"HPpuls", "ATKup", "Speedup"};
    float _nowTime;
    void Start()
    {
        _nowTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SpanItem();
    }

    void SpanItem()
    {
        _nowTime += Time.deltaTime;
        if(_nowTime >= _spanTime)
        {
            int r = Random.Range(0, _items.Length);
            GameObject itemObj = Instantiate(_item, transform);
            itemObj.transform.position = new Vector3(Random.Range(-3f, 4f), 5f, 0f);
            Item item = itemObj.GetComponent<Item>();
            item.SetType(_items[r]);
            item.SetImage(_images[r]);
            GameObject target = GameObject.Find("Player");
            if(target != null)
            {
                Vector3 v = target.transform.position - item.transform.position;
                item.SetVelocity(v / Mathf.Sqrt(v.x * v.x + v.y * v.y));
            }
            else
            {
                item.SetVelocity(new Vector3(0f, -1f, 0f));
            }
            _nowTime = 0;
        }
    }
}
