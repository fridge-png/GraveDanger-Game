using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item" , menuName = "Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public int itemAmount;

    public ItemInterface itemScript;

}
