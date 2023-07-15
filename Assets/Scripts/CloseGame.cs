using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGame : MonoBehaviour
{
    public void CloseGameTrap()
    {
        Application.Quit();
        print("se cierra el juego");
    }
}
