using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSystem : MonoBehaviour
{
    //StartGame
    public void StartGame(){Application.LoadLevel("Game");}

    //ExitApp
    public void ExitApp(){Application.Quit();}
}
