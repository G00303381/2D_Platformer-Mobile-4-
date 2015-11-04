using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager gm;
    public Transform player;
    public Transform spawnPoint;
    public float spawnDelay = 2f;
    public Transform spawnParticle;

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
        Destroy(enemy.gameObject);
    }

}
