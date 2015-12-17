using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    [System.Serializable]
    public class EnemyStats
    {
<<<<<<< HEAD
        public int damage = 40;
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
=======
        public int Health = 100;
>>>>>>> 0db89a7ca14b477499e546f8631dd33dab1c22e5
    }

    public EnemyStats stats = new EnemyStats();

    public int fallBoundary = -20;

<<<<<<< HEAD
    public Transform deathParticles;
    public float shakeAmnt = 0.1f;
    public float shakeLength = 0.1f;

    void Update()
    {
        stats.init();
        
       
=======
    void Update()
    {
>>>>>>> 0db89a7ca14b477499e546f8631dd33dab1c22e5
        if (transform.position.y <= fallBoundary)
            DamageEnemy(9999);
    }

    public void DamageEnemy(int damage)
    {
<<<<<<< HEAD
        stats.currentHealth -= damage;
        if (stats.currentHealth <= 0)
        {
            GameManager.KillEnemy(this);
        }

    }

    void OnCollisionEnter2D(Collision2D colInfo)
    {
        Player player = colInfo.collider.GetComponent<Player>();
        if (player != null)
        {
            player.DamagePlayer(stats.damage);
            DamageEnemy(99999);
        }

    }
=======
        stats.Health -= damage;
        if (stats.Health <= 0)
        {
            GameManager.KillEnemy(this);
        }
    }

>>>>>>> 0db89a7ca14b477499e546f8631dd33dab1c22e5
}
