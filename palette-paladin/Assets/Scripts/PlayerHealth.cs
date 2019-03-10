using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private int startingHealth;
    [SerializeField] private GameObject gameOverUI;
    private int health;


    void Start()
    {
        health = startingHealth;
    }

    // Called when a minion reaches the paladin
    void TakeDamage(int dmg)
    {
        this.health -= dmg;
        if (this.health <= 0)
        {
            this.GameOver();
        }
    }

    //  Called upon game lost
    private void GameOver()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }

    // Called when an enemy walks into the paladin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Minion")
        {
            Minion m = collision.GetComponent<Minion>();
            this.TakeDamage(1);
            m.Die();
            enemyManager.ClearEnemies();
        }
    }

}
