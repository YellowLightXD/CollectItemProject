using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public float spawn_time;
    // Use this for initialization
    void Start()
    {
        //เรียกเมธอด x หลังจากเวลาผ่านไป y วินาทีและเรียกซ้ำเรื่อยๆ ทุกๆ z วินาที
        InvokeRepeating("Spawn", spawn_time, spawn_time);
    }

    void Spawn()
    {
        //สร้างเกมออบเจคใหม่ขณะ Runtime (ควรใช้ prefab)
        //Instantiate : สร้างวัตถุเกมใหม่ขึ้นมา มี 2 แบบในการเรียกใช้
        //Instantiate(x) : สร้างวัตถุเกมใหม่ x ขึ้นมา ตำแหน่งและการหมุนจะตามค่า original ของ x
        //Instantiate(x,p, q) : สร้างวัตถุเกมใหม่ x ขึ้นมา ตำแหน่งคือ p การหมุนคือ q
        //transform.position : ตำแหน่งที่โค้ดนีั้ติดอยู่ ในบริบทนี้คือ spawn point
        if (GameManager.Instance.CanSpawnEnemy() && enemy != null) { 
            Instantiate(enemy, transform.position, enemy.transform.rotation);
        }
    }
}
