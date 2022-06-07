using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{

    private ItemSO item;

    private TextMeshProUGUI itemName;
    private Image itemSprite;
    private TextMeshProUGUI itemAmount;

    private Image itemBorder;

    private int currentAmount;

    bool isEmpty;
    bool selected;


    void Start()
    {

        itemName = transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        itemBorder = transform.Find("ItemBorder").GetComponent<Image>();
        itemSprite = transform.Find("ItemSprite").GetComponent<Image>();
        itemAmount = transform.Find("ItemAmount").GetComponent<TextMeshProUGUI>();

        itemName.text = "";
        itemSprite.sprite = null;
        selected = false;
        isEmpty = true;
        itemAmount.text = "";

    }

    public void setSelected()
    {
        selected = !selected;

        if (selected)
        {
            itemBorder.color = new Color(255, 255, 255);
        }
        else
        {
            itemBorder.color = new Color(0, 0, 0);

        }

    }

    public void assignItemUI(ItemSO item)
    {
        this.item = item;
        isEmpty = false;

        if (item != null)
        {
            currentAmount = item.itemAmount;

            itemName.text = item.itemName;
            itemSprite.sprite = item.itemSprite;
            itemSprite.color = new Color(0, 0, 0, 255);
            itemAmount.text = currentAmount + "";
        }

    }

    public void increaseAmount()
    {
        currentAmount += item.itemAmount;
        itemAmount.text = currentAmount + "";
    }

    public void decreaseAmount()
    {
        currentAmount -= 1;
        itemAmount.text = currentAmount + "";

        if (currentAmount <= 0)
        {
            UIManager.instance.removeSelectedItem();
        }
    }

    public bool checkEmpty()
    {
        return isEmpty;
    }

    public void setEmpty()
    {
        isEmpty = true;

        itemSprite.color = new Color(0, 0, 0, 0);
        itemName.text = "";
        itemSprite.sprite = null;
        itemAmount.text = "";

    }

    public string getItemName()
    {
        return item.itemName;

    }


}
