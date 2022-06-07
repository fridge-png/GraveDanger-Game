using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, PoolerInterface
{

    // Components and Game objects
    private Animator FSManim;


    // Serializable Field
    [Tooltip("Health of the enemy.")]
    [SerializeField] private float maxHealth = 50;

    // Logic Variables
    private float health;
    private bool isDead;
    private bool isConfused;

    void Start()
    {

        FSManim = transform.GetComponent<Animator>();

    }

    public void onSpawn()
    {
        isDead = false;
        isConfused = false;
        health = maxHealth;

        health = maxHealth;

        Player.dieEvent += stopAttacking;

    }

    void Update()
    {

        transform.LookAt(Player.instance.getPos() + new Vector3(0, transform.position.y - Player.instance.getPos().y, 0));

        FSManim.SetFloat("distance", Vector3.Distance(transform.position, Player.instance.transform.position));

    }


    void Disable()
    {
        Player.dieEvent -= stopAttacking;
    }

    private void stopAttacking()
    {
        // Debug.Log(FSManim);
        FSManim.SetBool("playerDead", true);

    }

    public void damagePlayer()
    {
        Player.instance.takeDamage(10f);

    }

    public void makeConfused()
    {
        health -= 5f;
        StartCoroutine("makeConfusedCoroutine");

    }

    IEnumerator makeConfusedCoroutine()
    {
        isConfused = true;
        FSManim.SetBool("confused", isConfused);

        yield return new WaitForSeconds(3f);

        isConfused = false;
        FSManim.SetBool("confused", isConfused);


    }

    public void takeDamage(float damage)
    {

        health -= damage;

        if (health <= 0)
        {
            FSManim.SetBool("zombieDead", true);
        }

        GameObject obj = ObjectPooler.instance.spawnFromPool(2, transform.position, transform.rotation);
        if (obj != null)
        {
            ParticleSystem bloodEffect = obj.GetComponentInChildren<ParticleSystem>();
            StartCoroutine(playAndPoolEffect(obj, bloodEffect));

        }

    }

    IEnumerator playAndPoolEffect(GameObject obj, ParticleSystem bloodEffect)
    {
        bloodEffect.Play();
        yield return new WaitForSeconds(bloodEffect.main.duration);
        ObjectPooler.instance.backToPool(2, obj);
    }

    public void die()
    {

        GameManager.instance.increaseScore();
        ObjectPooler.instance.backToPool(1, transform.parent.gameObject);
    }

}
