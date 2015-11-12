using UnityEngine;
using System;

public class Weapon : MonoBehaviour {

    public float fireRate = 0f;
    public int damage = 10;
    public LayerMask whatToHit;
    public Transform bulletTrail;
    public Transform hitPrefab;
    public Transform firePoint;
    public Transform muzzleFlash;
    public float effectSpawnRate = 10f;


    public float camShakeAmnt = 0.05f;
    public float camShakeLng = 0.1f;
    CameraShake camShake;

    float timetoFire = 0f;
    float timeToSpawnEffect = 0f;

	// Use this for initialization
	void Awake ()
    {
        firePoint = transform.FindChild("FirePoint");

        if (firePoint == null)
        {
            Debug.Log("Missing child object on the pistol 'FirePoint'");
        }
	}

    void Start()
    {
        camShake = GameManager.gm.GetComponent<CameraShake>();
        if (camShake == null)
        {
            Debug.LogError("No camera shake script found on gm object!");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }

        else
        {
            if (Input.GetButton("Fire1") && Time.deltaTime > timetoFire)
            {
                timetoFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
	}

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        Vector2 firePointPos = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPos, mousePosition - firePointPos, 100, whatToHit);

        //Debug.DrawLine(firePointPos, (mousePosition - firePointPos) * 100, Color.cyan);

        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPos, hit.point, Color.red);
            Enemy enemy = hit.collider.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.DamageEnemy(damage);
                Debug.Log("We hit " + hit.collider.name + " and did " + damage + " damage!");
            }
        }

        if (Time.time >= timeToSpawnEffect)
        {
            Vector3 hitPos;
            Vector3 hitNorm;

            if (hit.collider == null)
            {
                hitPos = (mousePosition - firePointPos) * 30;
                hitNorm = new Vector3(9999, 9999, 9999);
            }

            else
            {
                hitPos = hit.point;
                hitNorm = hit.normal;
            }

            Effect(hitPos, hitNorm);
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
    }

    void Effect(Vector3 hitPos, Vector3 hitNorm)
    {
        Instantiate(bulletTrail, firePoint.position, firePoint.rotation);

        Transform trail = (Transform)Instantiate(bulletTrail, firePoint.position, firePoint.rotation);
        LineRenderer lr = trail.GetComponent<LineRenderer>();

        if (lr == null)
        {
            lr.SetPosition(0, firePoint.position);
            lr.SetPosition(1, hitPos);
        }

        Destroy(trail.gameObject, 0.04f);

        if (hitNorm != new Vector3(9999,9999,9999))
        {
            Transform hitParticles = (Transform)Instantiate(hitPrefab, hitPos, Quaternion.FromToRotation(Vector3.right, hitNorm));
            Destroy(hitParticles.gameObject, 1f);
        }

        Transform clone = (Transform)Instantiate(muzzleFlash, firePoint.position, firePoint.rotation);
        clone.parent = firePoint;
        float size = UnityEngine.Random.Range(0.6f, 0.9f);
        clone.localScale = new Vector3(size, size, size);
        Destroy(clone.gameObject, 0.02f);

        camShake.shake(camShakeAmnt, camShakeLng);

    }
}
