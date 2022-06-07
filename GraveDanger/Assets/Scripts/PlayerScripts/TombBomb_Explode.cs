using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombBomb_Explode : MonoBehaviour, PoolerInterface
{
    private ParticleSystem explosionEffect;
    private AudioSource bombAudio;
    void Start()
    {

        explosionEffect = GetComponentInChildren<ParticleSystem>();
        bombAudio = transform.GetComponentInChildren<AudioSource>();

    }

    public void onSpawn()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            StartCoroutine("explodeAndPoolExplosion");

        }
    }

    IEnumerator explodeAndPoolExplosion()
    {
        explosionEffect.Play();
        bombAudio.Play();

        Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
        foreach (Collider c in colliders)
        {
            if (c.gameObject.tag == "Enemy")
            {
                c.gameObject.GetComponentInChildren<Enemy>().takeDamage(30f);
            }

        }

        yield return new WaitForSeconds(explosionEffect.main.duration);
        ObjectPooler.instance.backToPool(4, this.gameObject);
    }
}
