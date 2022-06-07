using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    // Components and Game objects
    private Shield shieldScript;
    private SoulOrb soulorbScript;
    private PossessedGhost possessedghostScript;
    private TombBomb tombbombScript;
    public static Player instance;
    private Slider healthBar;

    // Logic Variables
    private bool shielded;
    public delegate void dieDelegate();
    public static event dieDelegate dieEvent;
    private bool isDead;
    private float health;

    // Serializable Fields

    [Tooltip("Health of the player.")]
    [SerializeField] private float maxHealth = 100f;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

    }
    void Start()
    {
        // Initializing Variables
        shieldScript = transform.GetComponentInChildren<Shield>();
        soulorbScript = transform.GetComponentInChildren<SoulOrb>();
        possessedghostScript = transform.GetComponentInChildren<PossessedGhost>();
        tombbombScript = transform.GetComponentInChildren<TombBomb>();
        healthBar = transform.GetComponentInChildren<Slider>();


        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        shielded = false;
        isDead = false;

    }


    void Update()
    {


        // Responsible for taking firing input and calling respective scripts
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            string selectedItemName = UIManager.instance.getSelectedItemName();
            switch (selectedItemName)
            {
                case "Spirit Shield":
                    shieldScript.Fire();
                    break;
                case "Soul Orb":
                    playerLookAt();
                    soulorbScript.Fire();
                    break;
                case "Possessed Ghost":
                    playerLookAt();
                    possessedghostScript.Fire();
                    break;
                case "Tomb Bomb":
                    tombbombScript.Fire();
                    break;

                default:
                    break;

            }
        }
    }



    public void setShielded()
    {
        shielded = !shielded;
    }

    public void takeDamage(float damage)
    {
        if (!shielded && !isDead)
        {
            health -= damage;
            healthBar.value = health;

            if (health <= 0)
            {
                isDead = true;
                die();

            }

        }
    }

    public Vector3 getPos()
    {
        return this.gameObject.transform.position;
    }

    private void playerLookAt()
    {
        Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mousePos, out RaycastHit hitInfo))
        {
            Vector3 lookPos = hitInfo.point;
            lookPos = new Vector3(lookPos.x, transform.position.y, lookPos.z);
            transform.LookAt(lookPos);
        }

    }

    private void die()
    {

        dieEvent();

    }
}
