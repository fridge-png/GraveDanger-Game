using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulOrb : MonoBehaviour
{

    [Tooltip("Fire rate of shots.")]
    [SerializeField] private float fireRate = 0.1f;

    private ParticleSystem orbEffect;
    private RaycastHit hitInfo;

    private float timeTillNextShot;
    private AudioSource shootAudio;


    void Start()
    {

        orbEffect = GameObject.Find("OrbEffect").GetComponent<ParticleSystem>();
        shootAudio = transform.GetComponentInChildren<AudioSource>();

    }

    void Update()
    {
        timeTillNextShot -= Time.deltaTime;

    }

    public void Fire()
    {
        if (timeTillNextShot <= 0)
        {
            timeTillNextShot = fireRate;

            shootAudio.Play();
            orbEffect.Play();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit camerHitInfo))
            {
                Vector3 lookPos = camerHitInfo.point;
                Vector3 direction = (lookPos - transform.position).normalized;
                ray = new Ray(transform.position, direction);
            }

            if (Physics.Raycast(ray, out hitInfo))
            {

                if (hitInfo.collider.gameObject.tag == "Enemy")
                {
                    hitInfo.collider.gameObject.GetComponentInChildren<Enemy>().takeDamage(5f);
                }
            }
        }


    }
}
