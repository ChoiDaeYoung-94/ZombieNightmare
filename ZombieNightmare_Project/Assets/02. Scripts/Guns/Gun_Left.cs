using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gun_Left : Guns
{
    public ViveInputManager viveInputManager;

    protected override void Start()
    {
        base.Start();

        if (SceneManager.GetActiveScene().name == "Stage_1")
        {
            rDamage_1 = 30; rDamage_2 = 65; fireRate = 0.8f;
        }
            
        if (SceneManager.GetActiveScene().name == "Stage_2")
        {
            rDamage_1 = 70; rDamage_2 = 140; fireRate = 0.4f;
        }
            
        if (SceneManager.GetActiveScene().name == "Stage_3")
        {
            rDamage_1 = 50; rDamage_2 = 100; fireRate = 0.1f;
        }  
    }

    protected override void Update()
    {
        base.Update();

        if (viveInputManager.gunLeft == true)
            isFire = true;

        if (viveInputManager.gunLeft == false)
            isFire = false;
    }
}
