using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int amount = 3;
    public AudioClip explosionSound;
    public AudioClip hitSound;
    public string playerName;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
    }

    public void TakeDamage()
    {
        amount -= 1;
        gameManager.PlaySound(hitSound);
        if (amount == 0)
        {
            gameManager.PlaySound(explosionSound);
            gameObject.SetActive(false);
            gameManager.GameEnded(playerName);
        }
    }
}
