using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaceSFX : MonoBehaviour
{
    [SerializeField] private AudioClip itemToMoneySound;
    [SerializeField] private AudioClip buyItemSound;
    private AudioSource source; 

    void Awake(){
        source = GetComponent<AudioSource>();
        source.loop = false;
        source.playOnAwake = false;
    }

    public void PlayItemToMoneySound(){
        source.clip = itemToMoneySound;
        source.Play();
    }

    public void PlayBuyItemSound(){
        source.clip = buyItemSound;
        source.Play();
    }
}