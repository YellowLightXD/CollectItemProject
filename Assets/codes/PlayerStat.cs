using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerStat : MonoBehaviour
{
    public int stat1; //hp
    public int stat2; //coin
    public int stat3; //
    public int stat4; //
    public AudioSource audioSource;
    public string[] speech;
    public AudioClip[] sfx;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



}
