using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.CrashReportHandler;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int currentDay;
    public int money;
    public CropData selectedCropToPlant;
    public event UnityAction onNewDay;
    public int cropInventory;
    public TextMeshProUGUI statsText;

    //Singleton
    public static GameManager instance;

    void OnEnable()
    {
        Crop.onPlantCrop += OnPlantCrop;
        Crop.onHarvestCrop += OnHarvestCrop;    
    }

    void OnDisable()
    {
        Crop.onPlantCrop -= OnPlantCrop;
        Crop.onHarvestCrop -= OnHarvestCrop;  
    }

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }

    public void SetNextDay()
    {
        currentDay++;
        onNewDay?.Invoke();
        UpdateStatsText();
    }

    public void OnPlantCrop(CropData crop)
    {
        cropInventory --;
        UpdateStatsText();
    }

    public void OnHarvestCrop(CropData crop)
    {
        money += crop.sellPrice;
        UpdateStatsText();
    }

    public void PurchaseCrop(CropData crop)
    {
        money -= crop.purchasePrice;
        cropInventory++;
        UpdateStatsText();
    }

    public bool CanPlantCrop()
    {
        return cropInventory > 0;
    }

    public void OnBuyCropButton(CropData crop)
    {
        if(money >= crop.purchasePrice)
        {
            PurchaseCrop(crop);
        }
    }

    void UpdateStatsText()
    {
        statsText.text = $"Day: {currentDay}\nMoney: ${money}\nCrop Inventory: {cropInventory}";
    }
}
