using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private Text _moneyCount;

    private void Start()
    {
        UpdateMoney();
    }

    public void UpdateMoney()
    {
        if (PlayerPrefs.HasKey("money"))
        {
            _money = PlayerPrefs.GetInt("money");
            _moneyCount.text = _money.ToString() + "$";
        }
        else
        {
            PlayerPrefs.SetInt("money", _money);
            _moneyCount.text = _money.ToString() + "$";
        }
    }
}
