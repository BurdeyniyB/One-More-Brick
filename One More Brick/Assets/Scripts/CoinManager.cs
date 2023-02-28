using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
   [SerializeField] private Text coinCount;
   int coins;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        coinCount.text = coins.ToString();
    }

    public void AddCoin()
    {
      coins++;
      PlayerPrefs.SetInt("Coins", coins);
      coinCount.text = coins.ToString();
    }
}
