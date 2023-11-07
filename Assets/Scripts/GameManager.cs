using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.CrashReportHandler;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public int currentDay;
    public int money;
    public CropData selectedCropToPlant;
    public event UnityAction onNewDay;
    public int cropInventory;

    //Singleton
    public static GameManager instance;

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

    }

    public void OnPlantCrop(CropData crop)
    {

    }

    public void OnHarvestCrop(CropData crop)
    {

    }

    public void PurchaseCrop(CropData crop)
    {

    }

    public bool CanPlantCrop()
    {
        return true;
    }

    public void OnBuyCropButton(CropData crop)
    {

    }

    void UpdateStatsText()
    {
        
    }
}
