using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */

    [SerializeField] GameObject[] FloorPrefbs;// 存放階梯
    public void SpanFloor()
    {
        int r = Random.Range(0, FloorPrefbs.Length);
        GameObject floor = Instantiate(FloorPrefbs[r], transform);// 生成新階梯並設為 FloorManager 子物件
        floor.transform.position = new Vector3(Random.Range(-3f, 4f), -6f, 0f);
    }
}
