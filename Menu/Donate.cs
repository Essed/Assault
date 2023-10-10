using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donate : MonoBehaviour {

    public void BuyNoAds()
    {
        IAPManager.Instance.BuyNoAds();
    }

    public void BuySupergrade()
    {
        IAPManager.Instance.BuySupergrades();
    }
}
