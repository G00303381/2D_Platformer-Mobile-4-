using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager gm;
    public Transform player;
    public Transform spawnPoint;
    public float spawnDelay = 2f;
    public Transform spawnParticle;

<<<<<<< HEAD
    public CameraShake camShake;


    void Start()
    {
        if (camShake == null)
        {
            Debug.Log("No cam shake found on game manager!");
        }
    }
=======
>>>>>>> 0db89a7ca14b477499e546f8631dd33dab1c22e5
    void Awake()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameManager>();
        }
    }

    public IEnumerator RespawnPlayer()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(player, spawnPoint.position, spawnPoint.rotation);
        Transform clone = (Transform)Instantiate(spawnParticle, spawnPoint.position, spawnPoint.rotation);
        Destroy(clone.gameObject, 3f);
        
    }

	public static void KillPlayer (Player player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine (gm.RespawnPlayer());
    }

    public static void KillEnemy(Enemy enemy)
    {
<<<<<<< HEAD
        gm.EnemeyDeath(enemy);
    }

    public void EnemeyDeath(Enemy enemy)
    {
        GameObject clone = (GameObject)Instantiate(enemy.deathParticles, enemy.transform.position, Quaternion.identity);
        Destroy(clone, 5f);
        camShake.shake(enemy.shakeAmnt, enemy.shakeLength);
        Destroy(enemy.gameObject);

=======
        Destroy(enemy.gameObject);
>>>>>>> 0db89a7ca14b477499e546f8631dd33dab1c22e5
    }

}
