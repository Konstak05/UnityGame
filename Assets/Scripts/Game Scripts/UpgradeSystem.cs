using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeSystem : MonoBehaviour
{
    public GameManager GameManager;

    public GameObject[] LockedButtonA,LockedButtonB;
    public GameObject[] UnlockedButtonA,UnlockedButtonB;
    public GameObject[] UpgradeButtonA,UpgradeButtonB;

    public int[] upgradeCostA,upgradeCostB;
    public int[] upgradeLevelA,upgradeLevelB;
    public int[] upgradeMaxLevelA,upgradeMaxLevelB;

    public TextMeshProUGUI[] upgradeTextA,upgradeTextB;
    public string[] upgradeNameA,upgradeNameB;

    public void Start()
    {
        for (int i = 0; i < LockedButtonA.Length; i++)
        {
            LockedButtonA[i].SetActive(true);
            UnlockedButtonA[i].SetActive(false);
        }
        for (int i = 0; i < LockedButtonB.Length; i++)
        {
            LockedButtonB[i].SetActive(true);
            UnlockedButtonB[i].SetActive(false);
        }
    }


    public void UpgradeClickCount(int upgradeIndex)
    {
        if (GameManager.ClickCount >= upgradeCostA[upgradeIndex] && upgradeLevelA[upgradeIndex] < upgradeMaxLevelA[upgradeIndex])
        {
            if (UnlockedButtonA[upgradeIndex].activeSelf == false){
                LockedButtonA[upgradeIndex].SetActive(false);
                UnlockedButtonA[upgradeIndex].SetActive(true);
            }

            GameManager.ClickCount -= upgradeCostA[upgradeIndex];
            GameManager.Multipliera[upgradeIndex] += 1;
            Refresh();
            upgradeLevelA[upgradeIndex]++;
            upgradeCostA[upgradeIndex] = (int)(upgradeCostA[upgradeIndex] * 1.1f);
            if(upgradeCostA[upgradeIndex] <= 0){upgradeCostA[upgradeIndex] = 10;}
            CheckForUpgrade();
        }
    }

    public void UpgradeAutoClick(int upgradeIndex)
    {
        if (GameManager.ClickCount >= upgradeCostB[upgradeIndex] && upgradeLevelB[upgradeIndex] < upgradeMaxLevelB[upgradeIndex])
        {
            if (UnlockedButtonB[upgradeIndex].activeSelf == false){
                LockedButtonB[upgradeIndex].SetActive(false);
                UnlockedButtonB[upgradeIndex].SetActive(true);
            }

            GameManager.ClickCount -= upgradeCostB[upgradeIndex];
            GameManager.Multiplierb[upgradeIndex] += 1;
            Refresh();
            upgradeLevelB[upgradeIndex]++;
            upgradeCostB[upgradeIndex] = (int)(upgradeCostB[upgradeIndex] * 1.1f);
            if(upgradeCostB[upgradeIndex] <= 0){upgradeCostB[upgradeIndex] = 10;}
            CheckForUpgrade();
        }
    }



    public void CheckForUpgrade(){
        for (int i = 0; i < UpgradeButtonA.Length; i++)
        {
            if (upgradeLevelA[i] < upgradeMaxLevelA[i]){
                if (GameManager.ClickCount >= upgradeCostA[i]){UpgradeButtonA[i].SetActive(true);}
                else{UpgradeButtonA[i].SetActive(false);}
            }
            else{UpgradeButtonA[i].SetActive(false);}
        }
        for (int i = 0; i < UpgradeButtonB.Length; i++)
        {
            if (upgradeLevelB[i] < upgradeMaxLevelB[i]){
                if (GameManager.ClickCount >= upgradeCostB[i]){UpgradeButtonB[i].SetActive(true);}
                else{UpgradeButtonB[i].SetActive(false);}
            }
            else{UpgradeButtonB[i].SetActive(false);}
        }  

        for (int i = 0; i < upgradeTextA.Length; i++){upgradeTextA[i].text = upgradeNameA[i] + " " + upgradeLevelA[i] + "/" + upgradeMaxLevelA[i];}
        for (int i = 0; i < upgradeTextB.Length; i++){upgradeTextB[i].text = upgradeNameB[i] + " " + upgradeLevelB[i] + "/" + upgradeMaxLevelB[i];}
    }

    public void Refresh(){GameManager.RefreshText();}
}