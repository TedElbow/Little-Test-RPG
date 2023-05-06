using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    
    [SerializeField] private Sprite itemImage;
    [SerializeField] private Text itemDescription;
    [SerializeField] private Text itemPrice;
    [SerializeField] private int itemPriceCount;
                     private Inventory inventory;
    [SerializeField] private SO_BodyPart CurrentPart;
    [SerializeField] private int BodyPartNumber; 
    [SerializeField] private SO_Avaliable _avaliableParts;
                     private Money _moneyScript;

    private void Start()
    {
        _moneyScript = FindObjectOfType<Money>();
        itemPrice.text = itemPriceCount.ToString() + "$";
        inventory = FindObjectOfType<Inventory>();
        if (_avaliableParts.characterBodyParts[BodyPartNumber].bodyPartOptions.Contains(CurrentPart))
        {
            foreach (GameObject Slot in inventory.InventoryList)//check all list
            {
                if(Slot.GetComponent<Image>().sprite == null)
                {
                    Slot.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    Slot.GetComponent<Image>().sprite = itemImage;
                    break;
                }
            }
        }
    }
    public void Buy()
    {
        int _money = PlayerPrefs.GetInt("money");

            foreach (GameObject Slot in inventory.InventoryList)//check all list
            {

                if (Slot.GetComponent<Image>().sprite != itemImage && Slot.GetComponent<Image>().sprite == null && _money > itemPriceCount) //if we dont have this item in the bag
                {
                    _money = _money - itemPriceCount;
                    PlayerPrefs.SetInt("money", _money);
                    _moneyScript.UpdateMoney();

                    Slot.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    Slot.GetComponent<Image>().sprite = itemImage;
                    _avaliableParts.characterBodyParts[BodyPartNumber].bodyPartOptions.Add(CurrentPart);
                    break;
                }
                else
                {
                    
                }
            }
        
    }

    public void Sell()
    {
        foreach (GameObject Slot in inventory.InventoryList)//check all list
        {
           
            if (Slot.GetComponent<Image>().sprite == itemImage) //if we dont have this item in the bag
            {
                Slot.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                Slot.GetComponent<Image>().sprite = null;
                _avaliableParts.characterBodyParts[BodyPartNumber].bodyPartOptions.Remove(CurrentPart);

                int _money = PlayerPrefs.GetInt("money");
                _money = _money + itemPriceCount / 2;
                PlayerPrefs.SetInt("money", _money);
                _moneyScript.UpdateMoney();

                break;
            }
            else
            {
                
            }
            
        }
    }


}
