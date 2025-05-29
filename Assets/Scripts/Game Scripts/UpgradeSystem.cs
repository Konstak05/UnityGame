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
            CheckForUpgrade();
            upgradeLevelA[upgradeIndex]++;
            upgradeCostA[upgradeIndex] = (int)(upgradeCostA[upgradeIndex] * 1.1f);
            upgradeTextA[upgradeIndex].text = upgradeNameA[upgradeIndex] + " " + upgradeLevelA[upgradeIndex] + "/" + upgradeMaxLevelA[upgradeIndex];
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
            CheckForUpgrade();
            upgradeLevelB[upgradeIndex]++;
            upgradeCostB[upgradeIndex] = (int)(upgradeCostB[upgradeIndex] * 1.1f);
            upgradeTextB[upgradeIndex].text = upgradeNameB[upgradeIndex] + " " + upgradeLevelB[upgradeIndex] + "/" + upgradeMaxLevelB[upgradeIndex];
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
    }

    public void Refresh(){GameManager.RefreshText();}
}