using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessedGhost : MonoBehaviour
{

    private float fireRate = 0.1f;
    private float timeTillNextShot;

    private AudioSource ghostAudio;

    void Start(){
        ghostAudio = transform.GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        timeTillNextShot -= Time.deltaTime;
    }

    public void Fire()
    {


        if (timeTillNextShot <= 0)
        {
            ghostAudio.Play();
            timeTillNextShot = fireRate;
            UIManager.instance.decreaseSelectedItemAmount();

            ObjectPooler.instance.spawnFromPool(3, transform.position, transform.rotation);
        }
    }

}
