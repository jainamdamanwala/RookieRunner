using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    public enum PurchaseType {removeAds,Gear1, Gear2, Gear5, Gear15, Gear30, Gear70, Gear150 };
    public PurchaseType purchaseType;

    public void ClickPurchaseButton()
    {
        switch (purchaseType)
        {
            case PurchaseType.removeAds:
                IAPManager.instance.BuyRemoveAds();
                break;
            case PurchaseType.Gear1:
                IAPManager.instance.Buy1Gear();
                break;
            case PurchaseType.Gear2:
                IAPManager.instance.Buy2Gear();
                break;
            case PurchaseType.Gear5:
                IAPManager.instance.Buy5Gear();
                break;
            case PurchaseType.Gear15:
                IAPManager.instance.Buy15Gear();
                break;
            case PurchaseType.Gear30:
                IAPManager.instance.Buy30Gear();
                break;
            case PurchaseType.Gear70:
                IAPManager.instance.Buy70Gear();
                break;
            case PurchaseType.Gear150:
                IAPManager.instance.Buy150Gear();
                break;
        }
    }
}
