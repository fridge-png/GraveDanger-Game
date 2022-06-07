using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombBomb : MonoBehaviour
{
    private float fireRate = 1f;
    private float timeTillNextShot;

    void Start()
    {

    }

    void Update()
    {
        timeTillNextShot -= Time.deltaTime;
    }

    public void Fire()
    {

        if (timeTillNextShot <= 0)
        {
            UIManager.instance.decreaseSelectedItemAmount();
            ObjectPooler.instance.spawnFromPool(4, transform.position, transform.rotation);
        }
    }
}
