using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSystem : MonoBehaviour
{
    public GameManager GameManager;
    public UpgradeSystem UpgradeSystem;

    public GameObject[] LockedButton, UnlockedButton;

    public int SuccessfulUpgrades1, SuccessfulUpgrades10, SuccessfulUpgrades25;

    void Start(){CustomUpdate();}

    public void CustomUpdate(){
        if(GameManager.ClickCount >= 1000){
            LockedButton[0].SetActive(false);
            UnlockedButton[0].SetActive(true);
        }
        if(GameManager.ClickCount >= 100000){
            LockedButton[1].SetActive(false);
            UnlockedButton[1].SetActive(true);
        }
        if(GameManager.ClickCount >= 10000000){
            LockedButton[2].SetActive(false);
            UnlockedButton[2].SetActive(true);
        }
        if(GameManager.ClickCount >= 2147483647){
            LockedButton[3].SetActive(false);
            UnlockedButton[3].SetActive(true);
        }
        if(UpgradeSystem != null){
            SuccessfulUpgrades1 = 0;
            SuccessfulUpgrades10 = 0;
            SuccessfulUpgrades25 = 0;

            for(int i = 0; i < UpgradeSystem.upgradeLevelA.Length; i++){
                if(UpgradeSystem.upgradeLevelA[i] >= 1){SuccessfulUpgrades1++;}
            }
            for(int i = 0; i < UpgradeSystem.upgradeLevelB.Length; i++){
                if(UpgradeSystem.upgradeLevelB[i] >= 1){SuccessfulUpgrades1++;}
            }
            if(SuccessfulUpgrades1 >= 9){
                LockedButton[4].SetActive(false);
                UnlockedButton[4].SetActive(true);
            }

            for(int i = 0; i < UpgradeSystem.upgradeLevelA.Length; i++){
                if(UpgradeSystem.upgradeLevelA[i] >= 10){SuccessfulUpgrades10++;}
            }
            for(int i = 0; i < UpgradeSystem.upgradeLevelB.Length; i++){
                if(UpgradeSystem.upgradeLevelB[i] >= 10){SuccessfulUpgrades10++;}
            }
            if(SuccessfulUpgrades10 >= 9){
                LockedButton[5].SetActive(false);
                UnlockedButton[5].SetActive(true);
            }

            for(int i = 0; i < UpgradeSystem.upgradeLevelA.Length; i++){
                if(UpgradeSystem.upgradeLevelA[i] >= 25){SuccessfulUpgrades25++;}
            }
            for(int i = 0; i < UpgradeSystem.upgradeLevelB.Length; i++){
                if(UpgradeSystem.upgradeLevelB[i] >= 25){SuccessfulUpgrades25++;}
            }
            if(SuccessfulUpgrades25 >= 9){
                LockedButton[6].SetActive(false);
                UnlockedButton[6].SetActive(true);
            }
        }
        if(GameManager.ExtractionCount > 0){
            LockedButton[7].SetActive(false);
            UnlockedButton[7].SetActive(true);
        }

        if(UnlockedButton[0].activeSelf == true && UnlockedButton[1].activeSelf == true && UnlockedButton[2].activeSelf == true && UnlockedButton[3].activeSelf == true && UnlockedButton[4].activeSelf == true && UnlockedButton[5].activeSelf == true && UnlockedButton[6].activeSelf == true && UnlockedButton[7].activeSelf == true){
            LockedButton[8].SetActive(false);
            UnlockedButton[8].SetActive(true);
        }
    
        Invoke("CustomUpdate", 1);
    }
}
