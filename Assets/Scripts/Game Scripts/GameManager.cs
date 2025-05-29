using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public UpgradeSystem UpgradeSystem;

    //ClickCount
    public GameObject ExtractIndicator, ExtractButton;
    public int ClickCount, ExtractionCount;
    public int[] Multipliera;
    public int[] Multiplierb;
    public int Multiplier;
    public TextMeshProUGUI ClickerText, ExtractionText;

    //Backgrounds
    //public GameObject[] Backgrounds;
    //public int BackgroundIndex;
    //public int ChangingBackgroundIn = 10;
    //public int ChangingBackgroundInMax = 10;

    //Effects
    public ParticleSystem ParticleClick;
    public int ClickCountParticle = 1;

    public void Start(){AutoIncrease();}

    public void AutoIncrease(){
        if(ClickCount >= 0 && ClickCount < 2147483647) {
            Multiplier = 1;
            Multiplier += Multiplier * Multiplierb[1];
            Multiplier += Multiplier * Multiplierb[2];
            Multiplier += Multiplier * Multiplierb[3];

            ClickCount += Multiplierb[0] * Multiplier; 
        }

        if(ClickCount >= 2147483647) {ClickCount = 2147483647;}
        if(ClickCount < 0) {ClickCount = 2147483647;}

        if(ClickCount >= 0 && ClickCount < 1000){ClickCountParticle = 1;}
        else if(ClickCount >= 1000 && ClickCount < 10000){ClickCountParticle = 5;}
        else if(ClickCount >= 10000 && ClickCount < 100000){ClickCountParticle = 15;}
        else if(ClickCount >= 100000 && ClickCount < 1000000){ClickCountParticle = 25;}
        else if(ClickCount >= 1000000){ClickCountParticle = 50;}

        if(ClickCount < 2147483647) {
            ParticleClick.Play();
            if(Multiplierb[0] > 0 || Multiplierb[1] > 0 || Multiplierb[2] > 0 || Multiplierb[3] > 0) {ParticleClick.Emit(ClickCountParticle);}
        }

        UpgradeSystem.CheckForUpgrade();
        RefreshText();
        Invoke("AutoIncrease", 1f);
    }

    public void ClickIncrease()
    {
        if(ClickCount >= 0 && ClickCount < 2147483647) {
            Multiplier = 1;
            Multiplier += Multipliera[0];
            Multiplier += Multiplier * Multipliera[1];
            Multiplier += Multiplier * Multipliera[2];
            Multiplier += Multiplier * Multipliera[3];
            Multiplier += Multiplier * Multipliera[4];

            ClickCount += 1 * Multiplier; 
        }

        if(ClickCount >= 2147483647) {ClickCount = 2147483647;}
        if(ClickCount < 0) {ClickCount = 2147483647;}

        if(ClickCount >= 0 && ClickCount < 1000){ClickCountParticle = 1;}
        else if(ClickCount >= 1000 && ClickCount < 10000){ClickCountParticle = 5;}
        else if(ClickCount >= 10000 && ClickCount < 100000){ClickCountParticle = 15;}
        else if(ClickCount >= 100000 && ClickCount < 1000000){ClickCountParticle = 25;}
        else if(ClickCount >= 1000000){ClickCountParticle = 50;}

        if(ClickCount < 2147483647) {
            ParticleClick.Play();
            ParticleClick.Emit(ClickCountParticle);
        }

        RefreshText();

        //if(ChangingBackgroundIn <= 1) {BackgroundIndex++; ChangingBackgroundIn = ChangingBackgroundInMax;}
        //else{ChangingBackgroundIn--;}

        //if(BackgroundIndex >= Backgrounds.Length) {BackgroundIndex = 0;}

        //for(int i = 0; i < Backgrounds.Length; i++) {Backgrounds[i].SetActive(i == BackgroundIndex);}
    }

    public void Extract(){
        if(ClickCount >= 2147483647){
            ClickCount = 0;
            ExtractionCount++;
        }
        for(int i = 0; i < UpgradeSystem.upgradeLevelA.Length; i++) {
            if(UpgradeSystem.upgradeLevelA[i] >= 1) {UpgradeSystem.upgradeLevelA[i] = 1;}
        }
        for(int i = 0; i < UpgradeSystem.upgradeLevelB.Length; i++) {
            if(UpgradeSystem.upgradeLevelB[i] >= 1) {UpgradeSystem.upgradeLevelB[i] = 1;}
        }
        for (int i = 0; i < UpgradeSystem.upgradeCostA.Length; i++) {
            if(UpgradeSystem.upgradeLevelA[i] >= 1) {UpgradeSystem.upgradeCostA[i] = 25;}
        }
        for (int i = 0; i < UpgradeSystem.upgradeCostB.Length; i++) {
            if(UpgradeSystem.upgradeLevelB[i] >= 1) {UpgradeSystem.upgradeCostB[i] = 25;}
        }
        for(int i = 0; i < Multipliera.Length; i++) {Multipliera[i] = 0;}
        for(int i = 0; i < Multiplierb.Length; i++) {Multiplierb[i] = 0;}
        UpgradeSystem.CheckForUpgrade();
        RefreshText();
    }

    public void RefreshText(){
        ClickerText.text = ClickCount.ToString(); ExtractionText.text = ExtractionCount.ToString();

        //MaxRelatedReplacements
        if(ClickCount >= 2147483647) {ClickerText.text = "MAX!"; ExtractionText.text = ExtractionCount.ToString();}
        if(ExtractionCount >= 1000) {ExtractionText.text = "CHEATER!!";}

        //ExtractIndicator
        if(ExtractionCount >= 1) {ExtractIndicator.SetActive(true);}
        else{ExtractIndicator.SetActive(false);}
        //ExtractButton
        if(ClickCount >= 2147483647) {ExtractButton.SetActive(true);}
        else{ExtractButton.SetActive(false);}
    }
}
