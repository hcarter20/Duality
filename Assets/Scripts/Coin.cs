﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // play the coin collection sound
            SoundManager.S.PlayCoinSound();

            // tell GameManager that player collected coin
            GameManager.S.PlayerCollectedCoin();

            // destroy this coin
            Destroy(gameObject);
        }
    }
}