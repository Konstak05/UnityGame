using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ClickCount
    public int ClickCount;

    //Backgrounds
    public GameObject[] Backgrounds;
    public int BackgroundIndex;
    public int ChangingBackgroundIn = 10;
    public int ChangingBackgroundInMax = 10;

    void Start()
    {

    }

    public void ClickIncrease()
    {
        ClickCount++;

        if(ChangingBackgroundIn <= 1) {BackgroundIndex++; ChangingBackgroundIn = ChangingBackgroundInMax;}
        else{ChangingBackgroundIn--;}

        if(BackgroundIndex >= Backgrounds.Length) {BackgroundIndex = 0;}

        for(int i = 0; i < Backgrounds.Length; i++) {Backgrounds[i].SetActive(i == BackgroundIndex);}
    }
}
