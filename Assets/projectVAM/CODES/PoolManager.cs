using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;

    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
        Debug.Log("PoolManager Awake called, pools initialized"); // ตรวจสอบว่าฟังก์ชัน Awake ถูกเรียกใช้
    }

    public GameObject Get(int index)
    {
        Debug.Log("Get function called with index: " + index); // ตรวจสอบว่าฟังก์ชัน Get ถูกเรียกใช้
        GameObject select = null;
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                Debug.Log("Reusing existing object: " + select.name); // ตรวจสอบว่ามีการใช้ object เดิม
                break;
            }
        }
        if (select == null)
        {
            if (index < prefabs.Length)
            {
                select = Instantiate(prefabs[index], transform);
                pools[index].Add(select);
                Debug.Log("Instantiated new object: " + select.name); // ตรวจสอบว่ามีการสร้างใหม่
            }
            else
            {
                Debug.LogError("Index out of range for prefabs array"); // ตรวจสอบว่ามีการอ้างอิง index ที่ไม่ถูกต้อง
            }
        }
        return select;
    }
}
