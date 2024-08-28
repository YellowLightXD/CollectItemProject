using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    public bool patrol;
    public bool chasePlayer;
    public float chaseDist;

    public int[] points;
    
    public int attack_point;
    int desPoint;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameManager.Instance.GetPlayer(); // FPSController
        desPoint = 0;
        

    }


    // Update is called once per frame
    void Update()
    {
        if (agent != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            
            if (chasePlayer && distance <= chaseDist)
            {
                agent.destination = player.transform.position;
            } else if (patrol && points.Length > 0)
            {
                if (agent.remainingDistance < 0.5f)
                {
                    desPoint = (desPoint + 1) % points.Length; 
                    agent.destination = GameManager.Instance.GetEnemyPatrolPoint(points[desPoint]);
                }
            }

            


        }
            
        

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            GameManager.Instance.PlayerGetAttack(attack_point);
            Destroy(gameObject);
        }

    }




}

