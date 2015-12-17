using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    [System.Serializable]
    public class PlayerStats
    {
        public int maxHealth = 100;
        private int currHealth;
        public int currentHealth
        {
            get { return currHealth; }
            set { currHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public void init()
        {
            currHealth = maxHealth;
        }
    }


    public PlayerStats playerStats = new PlayerStats();

    public int fallBoundary = -20;

    void Update()
    {
        if (transform.position.y <= fallBoundary)
            DamagePlayer(9999);
    }

    public void DamagePlayer(int damage)
    {
        playerStats.currentHealth -= damage;
        if (playerStats.currentHealth <= 0)
        {
            GameManager.KillPlayer(this);
        }
    }

}
