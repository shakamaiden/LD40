﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

    public int carryingGold;
    public int carryingSilver;
    public int score;
    int carryingTotal;
    PlayerController playerController;
    public AudioClip dropSound;
    AudioSource audioSource;
    public Text scoreFinal;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        carryingGold = 0;
        carryingSilver = 0;
        carryingTotal = 0;
        score = 0;
    }

    private void Update()
    {
        if (GameManager.Instance.gameOver == true)
            scoreFinal.text = score.ToString();
    }

    // itemTypes> 1 == gold, 2 == silver
    public void ItemPicked(int itemType)
    {
        if (itemType == 1)
        {
            carryingGold += 1;
        }
        if (itemType == 2)
        {
            carryingSilver += 1;
        }

        playerController.SpeedDown();
        carryingTotal += 1;
        
    }

    public void DropPoint(int dropType)
    {
        if (carryingTotal > 0)
        {
            if(dropType == 1 && carryingGold > 0)
            {
                carryingTotal -= 1;
                carryingGold -= 1;
                score += 20;
                playerController.StepUpSpeed();
                audioSource.PlayOneShot(dropSound, 0.1f);
            }
            if (dropType == 2 && carryingSilver > 0)
            {
                carryingSilver -= 1;
                carryingTotal -= 1;
                score += 10;
                playerController.StepUpSpeed();
                audioSource.PlayOneShot(dropSound, 0.1f);
            }
        }
        
        if(carryingTotal == 0)
        {
            playerController.ResetSpeed();
        }
        
    }

    public void GetHit()
    {
        carryingGold = 0;
        carryingSilver = 0;
        carryingTotal = 0;
        playerController.ResetSpeed();
    }
}
