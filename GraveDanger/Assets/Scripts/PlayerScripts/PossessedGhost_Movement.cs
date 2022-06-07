using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessedGhost_Movement : MonoBehaviour, PoolerInterface
{

    public void onSpawn()
    {
        StartCoroutine("poolTimer");
    }

    IEnumerator poolTimer()
    {

        yield return new WaitForSeconds(3f);
        ObjectPooler.instance.backToPool(3, this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {


        // transform.Translate(transform.forward * 10 * Time.deltaTime);
        transform.position += transform.forward * Time.deltaTime * 10;

    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponentInChildren<Enemy>().makeConfused();
            ObjectPooler.instance.backToPool(3, this.gameObject);
        }

    }
}
