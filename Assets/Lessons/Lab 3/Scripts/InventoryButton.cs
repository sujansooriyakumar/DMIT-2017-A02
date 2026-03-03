using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text flavourText;
    public TMP_Text quantityDisplay;
    public Image icon;

    public void InitializeButton(InventoryItemData item)
    {
        itemName.text = item.itemName;
        flavourText.text = item.flavourText;
        quantityDisplay.text = item.quantity.ToString();
        icon.sprite = item.icon;
    }
}
