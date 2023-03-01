using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public Text Score_1;
    public Text Score_2;
    public Text Score_3;

    //public int testScore;

    void OnEnable()
    {
        //PlayerPrefs.SetInt("nowScore", testScore);

        for (int i = 1; i <= 3; i++)
        {
            if (PlayerPrefs.GetInt("nowScore", 0) > PlayerPrefs.GetInt(i.ToString(), 0))
            {
                for (int a = 3; a > i; a--)
                {
                    PlayerPrefs.SetInt(a.ToString(), PlayerPrefs.GetInt((a - 1).ToString(), 0));
                }
                PlayerPrefs.SetInt(i.ToString(), PlayerPrefs.GetInt("nowScore"));
                break;
            } else if (PlayerPrefs.GetInt("nowScore") == PlayerPrefs.GetInt(i.ToString(), 0))
            {
                break;
            }
        }

        //if (testScore == 0)
        //{
        //    for (int i = 1; i <= 3; i++)
        //    {
        //        PlayerPrefs.SetInt(i.ToString(), 0);
        //    }
        //}

        int score1 = PlayerPrefs.GetInt("1");
        int score2 = PlayerPrefs.GetInt("2");
        int score3 = PlayerPrefs.GetInt("3");

        Score_1.text = score1.ToString();
        Score_2.text = score2.ToString();
        Score_3.text = score3.ToString();
    }
}
