using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject GM_Prefab;

    AudioSource main;

    void Awake()
    {
        if (gameManager.instance_GM == null)
            Instantiate(GM_Prefab);
    }

    void Start()
    {
        main = gameManager.instance_GM.GetComponent<AudioSource>();
        main.Stop();
    }
}
