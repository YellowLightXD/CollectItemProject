using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject player;
    public GameObject patrolPoints;
    List<Transform> patrol_list;
    PlayerStat player_stat;
    public int max_number_enemy;
    

    [SerializeField]
    private TextMeshProUGUI stat1_ui;

    [SerializeField]
    private TextMeshProUGUI stat2_ui;

    [SerializeField]
    private TextMeshProUGUI stat3_ui;

    [SerializeField]
    private TextMeshProUGUI stat4_ui;

    [SerializeField]
    private TextMeshProUGUI speech_ui;

    [SerializeField]
    private float dialouge_time;

    [SerializeField]
    private GameObject dialouge_panel;

    private float dialouge_remain_time;

    public void Start()
    {
        player_stat = player.GetComponent<PlayerStat>();
        GetEnemyPatrolList();
        UpdateUI();
    }

    public PlayerStat GetPlayerStat()
    {
        return player_stat;
    }

    public bool CanSpawnEnemy()
    {
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
        if (enemyCount > max_number_enemy)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void isGameOver()
    {
        if(player_stat.stat1 <= 0)
        {
            SceneManager.LoadScene("gameover_scene");
        }
        
    }

    public void GetEnemyPatrolList()
    {
        patrol_list = new List<Transform>();
	if(patrolPoints==null)return;

        foreach (Transform child in patrolPoints.transform)
        {
            patrol_list.Add(child);
        }
    }

    public Vector3 GetEnemyPatrolPoint(int ind)
    {
        if (ind < 0)
        {
            return patrol_list[0].position;
        }

        if (ind > patrol_list.Count)
        {
            return patrol_list[patrol_list.Count-1].position;
        }

        return patrol_list[ind].position;
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public void Update()
    {
        if (dialouge_remain_time > 0)
        {
            dialouge_remain_time -= Time.deltaTime;
        }
        else
        {
            dialouge_panel.SetActive(false);
        }

        isGameOver();

    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdatePlayerStatFromItem(int s1, int s2, int s3, int s4, int speech_num)
    {
        player_stat.stat1 = player_stat.stat1 + s1;
        player_stat.stat2 = player_stat.stat2 + s2;
        player_stat.stat3 = player_stat.stat3 + s3;
        player_stat.stat4 = player_stat.stat4 + s3;

        ShowDialouge(speech_num);

        UpdateUI();
    }

    public void PlayerGetAttack(int hitpoint)
    {
        player_stat.stat1 = player_stat.stat1 - hitpoint;
        ShowDialouge(1);
        UpdateUI();
    }

    public void ShowDialouge(int speech_num)
    {
        string speech = null;
        AudioClip sfx = null;
        if (speech_num >= 0 && speech_num < player_stat.speech.Length)
        {
            speech = player_stat.speech[speech_num];
        }

        if (speech_num >= 0 && speech_num < player_stat.sfx.Length)
        {
            sfx = player_stat.sfx[speech_num];
        }

        if (speech != null)
        {
            speech_ui.text = speech;
            dialouge_panel.SetActive(true);
            dialouge_remain_time = dialouge_time;
            if (sfx != null)
            {
                player_stat.audioSource.clip = sfx;
                player_stat.audioSource.Play();
            }
        }

        
    }

    public void UpdateUI()
    {
        stat1_ui.text = "HP = " + player_stat.stat1;
        stat2_ui.text = "Coin = " + player_stat.stat2;
    }



}
