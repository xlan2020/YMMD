using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaceSFX : MonoBehaviour
{
    [SerializeField] private AudioClip itemToMoneySound;
    [SerializeField] private AudioClip buyItemSound;
    [SerializeField] private AudioClip moneyToItemSound;
    [SerializeField] private AudioClip itemToInventorySound;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.loop = false;
        source.playOnAwake = false;
    }

    public void PlayItemToMoneySound()
    {
        source.clip = itemToMoneySound;
        source.Play();
    }

    public void PlayBuyItemSound()
    {
        source.clip = buyItemSound;
        source.Play();
    }

    public void PlayMoneyToItemSound()
    {
        source.clip = moneyToItemSound;
        source.Play();
    }

    public void PlayItemToInventorySound()
    {
        source.clip = itemToInventorySound;
        source.Play();
    }
}
