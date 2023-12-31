﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;


public class IAPManager : MonoBehaviour, IStoreListener
{
    public static IAPManager Instance { set; get; } 


    private static IStoreController m_StoreController;          // The Unity Purchasing system.
    private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

    
     public static string PRODUCT_SUPERGRADES = "supregrades";
     public static string PRODUCT_REMOVEADS = "removeadsid";   


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {      

        if (m_StoreController == null)
        {     
            InitializePurchasing();
        }
    }
    public void InitializePurchasing()
    {
       
        if (IsInitialized())
        {
            
            return;
        }

        
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

       
         
        builder.AddProduct(PRODUCT_SUPERGRADES, ProductType.NonConsumable);
        builder.AddProduct(PRODUCT_REMOVEADS, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }
    private bool IsInitialized()
    {
       
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }
    public void BuySupergrades()
    {
        BuyProductID(PRODUCT_SUPERGRADES);
    }
    public void BuyNoAds()
    {
        BuyProductID(PRODUCT_REMOVEADS);
    }
    private void BuyProductID(string productId)
    {
        // If Purchasing has been initialized ...
        if (IsInitialized())
        {
            // ... look up the Product reference with the general product identifier and the Purchasing 
            // system's products collection.
            Product product = m_StoreController.products.WithID(productId);

            // If the look up found a product for this device's store and that product is ready to be sold ... 
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                // asynchronously.
                m_StoreController.InitiatePurchase(product);
            }
            // Otherwise ...
            else
            {
                // ... report the product look-up failure situation  
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        // Otherwise ...
        else
        {
            // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
            // retrying initiailization.
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }    
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        // Purchasing has succeeded initializing. Collect our Purchasing references.
        Debug.Log("OnInitialized: PASS");

        // Overall Purchasing system, configured with products for this application.
        m_StoreController = controller;
        // Store specific subsystem, for accessing device-specific store features.
        m_StoreExtensionProvider = extensions;
    }
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
       
        if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_SUPERGRADES, StringComparison.Ordinal))
        {
            Debug.Log("You`ve supergrades in your character");
            PlayerPrefs.SetString("Supergrades", "yes");
        }
       else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_REMOVEADS, StringComparison.Ordinal))
        {
            Debug.Log("You`ve remove ads in game! Good time");
            PlayerPrefs.SetString("NoAds", "yes");
        }

        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }
        
        return PurchaseProcessingResult.Complete;
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
        // this reason with the user to guide their troubleshooting actions.
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}
