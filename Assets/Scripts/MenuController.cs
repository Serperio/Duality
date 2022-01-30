using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    [SerializeField]private int index = 1;
    [SerializeField] private GameObject credits;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            index++;
            if (index > 3) index = 1;
            HighlightWord();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            index--;
            if (index < 1) index = 3;
            HighlightWord();
        }
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
            print(credits.activeSelf);
            if (credits.activeSelf)
            {
                credits.SetActive(false);
            }
            else
            {
                switch (index)
                {
                    case 1:
                        //Pasar a primer nivel
                        break;
                    case 2:
                        //Mostrar creditos
                        credits.SetActive(true);
                        break;
                    case 3:
                        //Cerrar juego
                        Application.Quit();
                        break;

                }
            }
            
        }

    }
    private void HighlightWord()
    {
        for (int i = 1; i < transform.childCount-1; i++)
        {
            transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = new Color32(164,164,164,255);
        }
        transform.GetChild(index).GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
    }
}
