using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Ctrl : MonoBehaviour
{
    // 시아에 점수가 보이게 하기 위함
    private int score;
    public Text scoreText;

    // 플레이어의 체력
    private float total_HP;
    public float now_HP;
    public Transform hp_Bar;

    public GameObject hp_f;
    public GameObject hp_b;
    
    public GameObject[] bloods;     // 만들어둔 혈흔들을 가져오고 렌덤으로 재생시키기 위해 배열로 표현

    public GameObject stageText;    // 각 스테이지가 시작될 때 나오는 Text
    public GameObject dieText;      // 플레이어가 죽었을 시 나오는 Text
    public GameObject clearText;

    void Start()
    {
        SetHp(100);                 // 플레이어의 시작 체력을 100으로 설정
        Invoke("StageText", 3.0f);  // 스테이지를 잠시 보여주는 함수
    }

    void Update()
    {
        score = gameManager.instance_GM.score;          // 점수는 gamemanager에서 받아옴
        scoreText.text = "Score: " + score.ToString();  // 받아온 점수를 화면에 표현하기 위함

        if (gameManager.instance_GM.numberofBoss == 0)
        {
            hp_f.SetActive(false);
            hp_b.SetActive(false);
            clearText.SetActive(true);
        }
    }

    public void monsters_Hit(float damage)
    {   
        // 체력이 0이 아닐 때 피격을 당하게되면 체력이 깎이고 혈흔이 화면에 보이게 됨 
        if (now_HP > 0)
        {
            now_HP -= damage;
            hp_Bar.transform.localScale = new Vector3((now_HP / total_HP) * 1.0f, 1.0f, 1.0f);

            int a;
            bloods[a = Random.Range(0, 3)].SetActive(true);
            StartCoroutine(ActiveDown(bloods[a]));
        }
        //체력이 0이되면 게임이 종료됨
        if (now_HP <= 0)
        {
            gameManager.instance_GM.GameOver();
            now_HP = 0;
            hp_Bar.transform.localScale = new Vector3((now_HP / total_HP) * 1.0f, 1.0f, 1.0f);
            dieText.SetActive(true);
            GetComponent<SphereCollider>().enabled = false;
            hp_f.SetActive(false);
            hp_b.SetActive(false);
        }
    }

    public void SetHp(int hp)
    {
        now_HP = total_HP = hp;
    }

    public void StageText()
    {
        stageText.SetActive(false);
    }

    // 코루틴을 사용하여 혈흔을 표현하는데 도움을 줌
    IEnumerator ActiveDown(GameObject activeImage)
    {
        yield return new WaitForSeconds(2.5f);
        activeImage.SetActive(false);
    }
}
