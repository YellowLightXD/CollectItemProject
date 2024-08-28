using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEvent : MonoBehaviour
{
    [SerializeField]
    private int item_stat1;

    [SerializeField]
    private int item_stat2;

    [SerializeField]
    private int item_stat3;

    [SerializeField]
    private int item_stat4;

    [SerializeField]
    private int sfx_num;

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            GameManager.Instance.UpdatePlayerStatFromItem(item_stat1, item_stat2, item_stat3, item_stat4, sfx_num);
            Destroy(gameObject); //ทำลายตัวเองทิ้ง 
        }
    }
}

