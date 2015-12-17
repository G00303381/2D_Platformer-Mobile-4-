using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    [System.Serializable]
    public class EnemyStats
    {
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
    }

    public EnemyStats stats = new EnemyStats();

    public int fallBoundary = -20;

    public Transform deathParticles;
    public float shakeAmnt = 0.1f;
    public float shakeLength = 0.1f;

    void Update()
    {
        stats.init();
        
       
        if (transform.position.y <= fallBoundary)
            DamageEnemy(9999);
    }

    public void DamageEnemy(int damage)
    {
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
}
