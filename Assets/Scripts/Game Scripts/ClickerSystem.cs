using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickerSystem : MonoBehaviour
{
    //GameManager
    public GameManager GameManager;
    public UpgradeSystem UpgradeSystem;

    //Clicker
    public GameObject Clicker;
    public float Scaling;
    public float ScalingValue;

    void Start(){CustomUpdate();}

    void CustomUpdate()
    {
        if(Scaling < 1f){Scaling += ScalingValue; Clicker.transform.localScale = new Vector3(Scaling, Scaling, Scaling); Invoke("CustomUpdate", 0.02f);}
        else{Scaling = 1f; Clicker.transform.localScale = new Vector3(Scaling, Scaling, Scaling);}
        if(Clicker.transform.rotation.z > 0f){Clicker.transform.rotation = new Quaternion(0f, 0f, Clicker.transform.rotation.z - 0.01f, 1f);}
        else if(Clicker.transform.rotation.z < 0f){Clicker.transform.rotation = new Quaternion(0f, 0f, Clicker.transform.rotation.z + 0.01f, 1f);}
    }

    public void Click()
    {
        GameManager.ClickIncrease();
        UpgradeSystem.CheckForUpgrade();
        Scaling = 0.75f;
        Clicker.transform.localScale = new Vector3(Scaling, Scaling, Scaling);
        Clicker.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-25f, 25f));
        CancelInvoke("CustomUpdate");
        CustomUpdate();
    }
}
