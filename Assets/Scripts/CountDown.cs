using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{

    private TextMeshProUGUI text;
    [SerializeField]private int min;
    [SerializeField]private int seconds;
    
    public void StartTimer()
    {
        text = GetComponent<TextMeshProUGUI>();
        if (seconds < 10)
        {
            text.text = min + "   0" + seconds;
        }
        else
        {
            text.text = min + "   " + seconds;
        }
        Invoke("Tick", 1);
    }

    private void Tick()
    {
        seconds--;
        if (seconds < 0)
        {
            min--;
            seconds = 59;
            if(min < 0)
            {
                print("perdiste");
                LevelManager.instance.ResetLevel();
            }
        }
        if(seconds < 10)
        {
            text.text = min + "   0" + seconds;
        }
        else
        {
            text.text = min + "   " + seconds;
        }
        
        Invoke("Tick", 1);
    }

}
