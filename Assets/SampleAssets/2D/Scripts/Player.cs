using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    [System.Serializable]
    public class PlayerStats
    {
<<<<<<< HEAD
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


=======
        public int Health = 100;
    }

>>>>>>> 0db89a7ca14b477499e546f8631dd33dab1c22e5
    public PlayerStats playerStats = new PlayerStats();

    public int fallBoundary = -20;

    void Update()
    {
        if (transform.position.y <= fallBoundary)
            DamagePlayer(9999);
    }

    public void DamagePlayer(int damage)
    {
<<<<<<< HEAD
        playerStats.currentHealth -= damage;
        if (playerStats.currentHealth <= 0)
=======
        playerStats.Health -= damage;
        if (playerStats.Health <= 0)
>>>>>>> 0db89a7ca14b477499e546f8631dd33dab1c22e5
        {
            GameManager.KillPlayer(this);
        }
    }

}
