using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterPanelUI : MonoBehaviour
{
    [SerializeField] PlayerInventory LinkedCharacter;
    [SerializeField] TextMeshProUGUI InventoryText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAddWornItem()
    {
        // create a new item
        BaseItem item = new EquippableItem();
        item.RandomiseItem();

        // add the item
        LinkedCharacter.WornItems.Add(item);

        // refresh the inventory
        RefreshInventory();
    }

    public void OnRemoveWornItem()
    {
        // remove a random item
        if (LinkedCharacter.WornItems.Count > 0)
        {
            LinkedCharacter.WornItems.RemoveAt(Random.Range(0, LinkedCharacter.WornItems.Count));

            RefreshInventory();
        }
    }

    public void OnAddCarriedItem()
    {
        // create a random item
        BaseItem item = null;
        if (Random.Range(0, 2) == 0)
            item = new ConsumableItem();
        else
            item = new EquippableItem();
        item.RandomiseItem();

        // add the item
        LinkedCharacter.CarriedItems.Add(item);

        // refresh the inventory
        RefreshInventory();            
    }

    public void OnRemoveCarriedItem()
    {
        // remove a random item
        if (LinkedCharacter.CarriedItems.Count > 0)
        {
            LinkedCharacter.CarriedItems.RemoveAt(Random.Range(0, LinkedCharacter.CarriedItems.Count));

            RefreshInventory();
        }
    }

    public void RefreshInventory()
    {
        string inventoryText = string.Empty;

        // add in the worn items
        inventoryText += "Worn Items";
        foreach(var item in LinkedCharacter.WornItems)
        {
            inventoryText += System.Environment.NewLine;

            inventoryText += item.GetDescription();
        }

        inventoryText += System.Environment.NewLine;

        // add in the carried items
        inventoryText += "Carried Items";
        foreach (var item in LinkedCharacter.CarriedItems)
        {
            inventoryText += System.Environment.NewLine;

            inventoryText += item.GetDescription();
        }

        InventoryText.text = inventoryText;    
    }
}
