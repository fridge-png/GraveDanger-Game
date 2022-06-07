using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    private GameObject shieldObject;

    private AudioSource shieldAudio;

    private bool activated = false;

    private float shieldTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
        shieldObject = transform.Find("ShieldModel").gameObject;
        shieldAudio = transform.GetComponentInChildren<AudioSource>();
        shieldObject.SetActive(false);

    }


    public void Fire()
    {

        if (!activated)
        {
            UIManager.instance.decreaseSelectedItemAmount();
            StartCoroutine("activateShield");
        }

    }

    IEnumerator activateShield()
    {

        shieldObject.SetActive(true);
        activated = true;
        Player.instance.setShielded();
        shieldAudio.Play();

        yield return new WaitForSeconds(shieldTime);

        shieldObject.SetActive(false);
        activated = false;
        Player.instance.setShielded();





    }
}
