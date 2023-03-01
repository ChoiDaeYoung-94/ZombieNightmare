using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Percent : MonoBehaviour
{
    float i = 0;
    public Text percent_Text;
    
    void Update()
    {
        percent_Text.text = i.ToString("N0") + " %";

        if (i <= 100)
        {
            i += 30 * Time.deltaTime;
        }

        if (i >= 100)
            i = 100;
    }
}
