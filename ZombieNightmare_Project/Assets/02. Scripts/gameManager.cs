using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager instance_GM = null;

    public int score;
    public int numberofMonster;
    public int numberofBoss;

    public bool stage_1 = false;
    public bool stage_2 = false;
    public bool stage_3 = false;

    public bool boss = true;

    public bool gameOver;

    private int scene_Number;

    void Awake()
    {
        if (instance_GM == null)
            instance_GM = this;
        else if (instance_GM != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        score = 0;
        numberofMonster = 0;
        numberofBoss = 1;
        gameOver = false;
    }

    void Update()
    {
        if (stage_1 == true && numberofMonster == 0)
        {
            stage_1 = false;
            StartCoroutine(Loading_Scene(1, 1));
        }

        if (stage_2 == true && numberofMonster == 0)
        {
            stage_2 = false;
            StartCoroutine(Loading_Scene(2, 2));
        }

        if (stage_3 == true && numberofBoss == 0)
        {
            stage_3 = false;
            StartCoroutine(End_Loading(3));
        }
    }

    public void GameOver()
    {
        Debug.Log("gm -> gameover");
        gameOver = true;
        GameObject destroy_monsters = GameObject.Find("Monsters");
        Destroy(destroy_monsters);

        for (int i = 1; i <= 3; i++)
        {
            if (SceneManager.GetActiveScene().name == "Stage_" + i.ToString())
            {
                scene_Number = i;
                break;
            }
        }
        StartCoroutine(End_Loading(scene_Number));
    }

    public void Reset()
    {
        score = 0;
        numberofMonster = 0;
        numberofBoss = 1;
        stage_1 = false;
        stage_2 = false;
        stage_3 = false;
        gameOver = false;
    }

    public void BM_getScore()
    {
        score += Random.Range(100, 300);
    }

    public void S_getScore()
    {
        score += Random.Range(200, 400);
    }

    public void M_getScore()
    {
        score += Random.Range(500, 700);
    }

    public void ML_getScore()
    {
        score += Random.Range(500, 800);
    }

    public void Boss_getScore()
    {
        score += Random.Range(1000, 1500);
    }

    IEnumerator Loading_Scene(int sceneNumber,int playerNumber)
    {
        GameObject.Find("Loading_find").transform.Find("Loading").gameObject.SetActive(true);

        GameObject player = GameObject.Find("Player_" + playerNumber.ToString());
        player.transform.position = new Vector3(100, 101, 100);

        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(sceneNumber);
    }

    IEnumerator End_Loading(int playerNumber)
    {
        Debug.Log("die_Loading coroutine진입");
        yield return new WaitForSeconds(5.0f);
        GameObject.Find("Loading_find").transform.Find("Loading").gameObject.SetActive(true);

        GameObject player = GameObject.Find("Player_" + playerNumber.ToString());
        player.transform.position = new Vector3(100, 101, 100);

        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(4);
    }
}