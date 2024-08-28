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
        //���¡���ʹ x ��ѧ�ҡ���Ҽ�ҹ� y �Թҷ�������¡���������� �ء� z �Թҷ�
        InvokeRepeating("Spawn", spawn_time, spawn_time);
    }

    void Spawn()
    {
        //���ҧ���ͺਤ���袳� Runtime (����� prefab)
        //Instantiate : ���ҧ�ѵ������������ �� 2 Ẻ㹡�����¡��
        //Instantiate(x) : ���ҧ�ѵ�������� x ����� ���˹���С����ع�е����� original �ͧ x
        //Instantiate(x,p, q) : ���ҧ�ѵ�������� x ����� ���˹觤�� p �����ع��� q
        //transform.position : ���˹觷���鴹���Դ���� 㹺�Ժ������ spawn point
        if (GameManager.Instance.CanSpawnEnemy() && enemy != null) { 
            Instantiate(enemy, transform.position, enemy.transform.rotation);
        }
    }
}
