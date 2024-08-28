using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalEvent : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Player")
        {
            if (GameManager.Instance.GetPlayerStat().stat2 >= 2 
             && GameManager.Instance.GetPlayerStat().stat2 < 5)
            {
                SceneManager.LoadScene("ending1");
            }

            if (GameManager.Instance.GetPlayerStat().stat2 >= 5
             && GameManager.Instance.GetPlayerStat().stat2 < 10)
            {
                SceneManager.LoadScene("ending2");
            }

        }
        
    }
}
