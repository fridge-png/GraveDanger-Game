using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    [SerializeField] ItemSO so;

    private AudioSource pickAudio;
    void Start()
    {

        pickAudio = transform.GetComponentInChildren<AudioSource>();
        StartCoroutine("rotate");


    }

    IEnumerator rotate()
    {

        while (true)
        {
            transform.Rotate(0, 100f * Time.deltaTime, 0);
            yield return null;

        }
    }



    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            pickAudio.Play();
            UIManager.instance.addToInventory(so);

            switch (so.itemName)
            {
                case "Spirit Shield":
                    ObjectPooler.instance.backToPool(7,this.gameObject);
                    break;
                case "Possessed Ghost":
                    ObjectPooler.instance.backToPool(5,this.gameObject);
                    break;
                case "Tomb Bomb":
                    ObjectPooler.instance.backToPool(6,this.gameObject);
                    break;

                default:
                    break;

            }

        }

    }
}
