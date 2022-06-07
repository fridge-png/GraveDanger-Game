using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{

    // UI Elements
    private GameObject pauseMenu;
    private GameObject controlsMenu;
    private GameObject loseScreen;
    private TextMeshProUGUI zombieHeadText;

    // Components and Game objects
    [SerializeField] private InventorySlot[] inventorySlots;

    // Logic Variables
    private int currentSlot;


    public static UIManager instance;

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

        currentSlot = -1;

        pauseMenu = GameObject.Find("PauseMenu");
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }

        controlsMenu = GameObject.Find("ControlsMenu");
        if (controlsMenu != null)
        {
            controlsMenu.SetActive(false);
        }
        if (GameObject.Find("ZombieHeadText") != null)
        {
            zombieHeadText = GameObject.Find("ZombieHeadText").GetComponent<TextMeshProUGUI>();
            zombieHeadText.text = GameManager.instance.getScore() + "";
        }

        loseScreen = GameObject.Find("LoseScreen");
        if (loseScreen != null)
        {
            loseScreen.SetActive(false);
        }

    }

    void OnEnable()
    {
        Player.dieEvent += showLoseScreen;
    }

    void OnDisable()
    {
        Player.dieEvent -= showLoseScreen;
    }

    public void showPauseMenu(bool show)
    {

        pauseMenu.SetActive(show);

    }

    public void increaseScoreText(float score)
    {
        if (zombieHeadText != null)
        {
            zombieHeadText.text = score + "";
        }

    }

    public void showControls()
    {
        controlsMenu.SetActive(true);
    }

    public void hideControls()
    {
        controlsMenu.SetActive(false);
    }

    public void showLoseScreen()
    {

        loseScreen.SetActive(true);

    }

    public void addToInventory(ItemSO item)
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.checkEmpty())
            {
                slot.assignItemUI(item);
                return;
            }
            else
            {
                if (slot.getItemName() == item.itemName)
                {
                    slot.increaseAmount();
                    return;
                }
            }

        }
    }

    public string getSelectedItemName()
    {
        if (currentSlot == -1)
        {
            return "Soul Orb";
        }
        return inventorySlots[currentSlot].getItemName();
    }

    public void selectItem(int index)
    {
        if (currentSlot == index)
        {
            deselectItem(index);
            return;
        }

        if (currentSlot != -1)
        {
            deselectItem(currentSlot);
        }

        if (!inventorySlots[index].checkEmpty())
        {
            currentSlot = index;
            inventorySlots[index].setSelected();
        }

    }

    public void deselectItem(int index)
    {

        currentSlot = -1;
        inventorySlots[index].setSelected();

    }

    public void removeSelectedItem()
    {
        inventorySlots[currentSlot].setEmpty();
        deselectItem(currentSlot);

    }

    public void decreaseSelectedItemAmount()
    {
        if (currentSlot != -1)
            inventorySlots[currentSlot].decreaseAmount();

    }

    public int getSelectedItemIndex()
    {
        return currentSlot;
    }
}
