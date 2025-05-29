using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModularPanelSystem : MonoBehaviour
{
    public GameObject Panel;

    public int Direction;
    public bool IsOpen;

    void Start()
    {
        CustomUpdate();
    }


    void CustomUpdate()
    {
        if(Direction == 0){
            if(!IsOpen && Panel.transform.localPosition.x < 1225f){Panel.transform.localPosition = new Vector3(Panel.transform.localPosition.x + 25f, Panel.transform.localPosition.y, Panel.transform.localPosition.z);}
            else if(IsOpen && Panel.transform.localPosition.x > 750f){Panel.transform.localPosition = new Vector3(Panel.transform.localPosition.x - 25f, Panel.transform.localPosition.y, Panel.transform.localPosition.z);}
        }
        else if(Direction == 1){
            if(IsOpen && Panel.transform.localPosition.x < -750f){Panel.transform.localPosition = new Vector3(Panel.transform.localPosition.x + 25f, Panel.transform.localPosition.y, Panel.transform.localPosition.z);}
            else if(!IsOpen && Panel.transform.localPosition.x > -1225f){Panel.transform.localPosition = new Vector3(Panel.transform.localPosition.x - 25f, Panel.transform.localPosition.y, Panel.transform.localPosition.z);}
        }

        Invoke("CustomUpdate", 0.02f);
    }
    

    public void PanelClick()
    {
        IsOpen = !IsOpen;
        CancelInvoke("CustomUpdate");
        CustomUpdate();
    }
}
