using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gun_main_clear : Guns
{
    public GameObject ranking;

    public GameObject zombie_Tutorial;
    public static int tutorialZombie = 0;
    
    public bool scenetest_main = false;
    public bool scenetest_start = false;

    public ViveInputManager viveInputManager;

    protected override void Start()
    {
        base.Start();
        fireRate = 1.0f;
        nextFire = 0.0f;
    }

    protected override void Update()
    {
        base.Update();

        if (scenetest_start)
            StartCoroutine(Loading_Scene(0));

        if (scenetest_main)
            StartCoroutine(Loading_Scene(3));

        if (viveInputManager.gunRight == true)
            isFire = true;

        if (viveInputManager.gunRight == false)
            isFire = false;

        if (Physics.Raycast(rayStart.position, (rayEnd.position - rayStart.position).normalized, out hit, 100.0f))
        {
            if (isFire)
            {
                if (Time.time >= nextFire)
                {
                    nextFire = Time.time + fireRate;
                    StartCoroutine(FireEffect());
                    
                    if (hit.collider.gameObject.layer == 9)
                        hit.collider.SendMessage("Hit", 15);

                    if (hit.collider.gameObject.name == "Tutorial")
                    {
                        Debug.Log("tutorial");
                        if (tutorialZombie == 0)
                            Instantiate(zombie_Tutorial);
                        else
                            return;
                    }

                    if (hit.collider.gameObject.name == "GameStart")
                        StartCoroutine(Loading_Scene(0));

                    if (hit.collider.gameObject.name == "Ranking")
                    {
                        if (ranking.activeSelf)
                            ranking.SetActive(false);
                        else
                            ranking.SetActive(true);
                    }

                    if (hit.collider.gameObject.name == "Main")
                        StartCoroutine(Loading_Scene(3)); 
                }
            }
        }
    }

    IEnumerator Loading_Scene(int i)
    {
        gameManager.instance_GM.Reset();
        GameObject.Find("Loading_find").transform.Find("Loading").gameObject.SetActive(true);

        GameObject player = GameObject.Find("Player_mian&clear");
        player.transform.position = new Vector3(100, 101, 100);

        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(i);
    }
}
