using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gate : MonoBehaviour
{
    // Serializable Fields
    [Tooltip("Score needed to finish level.")]
    [SerializeField] private int gateScore = 5;

    // Components and Game objects
    private TextMeshProUGUI gateScoreText;

    void Start()
    {

        gateScoreText = transform.GetComponentInChildren<TextMeshProUGUI>();
        gateScoreText.text ="x"+ gateScore;

        if (GameManager.instance.getGateOpened())
        {
            GetComponent<Animator>().Play("GateOpenAnimation");
            BoxCollider[] colliders = GetComponents<BoxCollider>();

            foreach (BoxCollider bc in colliders)
            {
                bc.enabled = false;
            }
        }
    }


    void OnTriggerStay(Collider col)
    {

        if (col.gameObject.tag == "Player" && Input.GetKey(KeyCode.E) && GameManager.instance.getScore() >= gateScore)
        {
            GetComponent<Animator>().Play("GateOpenAnimation");
            BoxCollider[] colliders = GetComponents<BoxCollider>();

            foreach (BoxCollider bc in colliders)
            {
                bc.enabled = false;
                GameManager.instance.setGateOpened();
                GameManager.instance.setScore(GameManager.instance.getScore()-gateScore);

            }

        }
    }
}
