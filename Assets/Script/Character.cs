using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private GameManagerScript gameManager;
    [SerializeField] private float maxHp;
    [SerializeField] private float currentHp;
    private bool isDead;


    private void Update()
    {
        if (isDead && currentHp <= 0)
        {
            gameManager.GameOver();
        }
    }

    public void TakeDamage (float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0 && !isDead)
        {
            isDead = true;
            Debug.Log("Player is dead GAME OVER");
            //spritePlayer.SetActive(false);
            Dead();
        }

    }

    public void Dead()
    {
        Time.timeScale = 0;
    }
}
