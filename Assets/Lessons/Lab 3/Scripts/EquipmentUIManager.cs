using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUIManager : MonoBehaviour
{


    public List<EquipmentUISlot> equipmentUISlots = new List<EquipmentUISlot>();
    private Dictionary<ArmorSlot, Image> equipmentUIDictionary = new();
    private void Start()
    {
        EquipmentManager.instance.onEquip += UpdateUI;

        foreach(var equipment in equipmentUISlots)
        {
            equipmentUIDictionary.Add(equipment.armorSlot, equipment.uiImage);
        }
    }
    public void UpdateUI(Dictionary<ArmorSlot, InventoryItemData> equipment)
    {
      foreach(ArmorSlot a in equipment.Keys)
        {
            if (equipment[a] != null)
            {
                equipmentUIDictionary[a].sprite = equipment[a].icon;
                Color tmp = equipmentUIDictionary[a].color;
                tmp.a = 1;
                equipmentUIDictionary[a].color = tmp;
            }
        }

        
    }
}

[Serializable]
public class EquipmentUISlot
{
    public ArmorSlot armorSlot;
    public Image uiImage;
}
