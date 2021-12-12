using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1_MonsterSpawn : MonoBehaviour
{
    // 이 Stage에 사용할 몬스터들을 받아옴
    public GameObject baseZombie;
    public GameObject skeleton;

    private Transform monstersHolder;   // 몬스터들이 생성될 때 Hierarchy창에 하나의 오브젝트를 만들고
                                        // 그 오브젝트의 자식으로두어 보기 편하게 함

    AudioSource bgmStart;

    void Start()
    {
        bgmStart =  gameManager.instance_GM.GetComponent<AudioSource>();
        bgmStart.Play();

        // 몬스터를 생성하는 함수를 InvokeRepeating을 이용하여 반복적으로 실행
        InvokeRepeating("stage1_Zombie_Front_1", 5.0f, 5.0f);
        InvokeRepeating("stage1_Zombie_Front_2", 10.0f, 5.0f);
        InvokeRepeating("stage1_Zombie_Side", 20.0f, 10.0f);
        InvokeRepeating("stage1_Skeleton", 30.0f, 12.0f);
        Invoke("CancleRespawn", 80.0f);

        monstersHolder = new GameObject("Monsters").transform;
    }

    void Update()
    {
        // 플레이어가 체력이 다했을 때 몬스터가 더이상 나오지 않도록 함
        if (gameManager.instance_GM.gameOver == true)
            CancleRespawn_GameOver();
    }

    //몬스터들을 생성시키는 함수
    void stage1_Zombie_Front_1()
    {
        Vector3 bZombie_1_pos = new Vector3(Random.Range(-2.7f, 0.5f), -20.4f, Random.Range(-5.5f, -19.0f));
        GameObject instance_1 = Instantiate(baseZombie, bZombie_1_pos, Quaternion.identity);
        instance_1.transform.SetParent(monstersHolder);
    }

    void stage1_Zombie_Front_2()
    {
        Vector3 bZombie_1_pos = new Vector3(Random.Range(-2.7f, 0.5f), -20.4f, Random.Range(-5.5f, -19.0f));
        GameObject instance_1 = Instantiate(baseZombie, bZombie_1_pos, Quaternion.identity);
        instance_1.transform.SetParent(monstersHolder);
    }

    void stage1_Zombie_Side()
    {
        Vector3 bZombie_2_pos = new Vector3(Random.Range(8.0f, 9.0f), -20.4f, Random.Range(-20.5f, -22.7f));
        GameObject instance_1 = Instantiate(baseZombie, bZombie_2_pos, Quaternion.identity);
        instance_1.transform.SetParent(monstersHolder);

        Vector3 bZombie_3_pos = new Vector3(Random.Range(-10.0f, -9.0f), -20.4f, Random.Range(-20.5f, -22.7f));
        GameObject instance_2 = Instantiate(baseZombie, bZombie_3_pos, Quaternion.identity);
        instance_2.transform.SetParent(monstersHolder);
    }

    void stage1_Skeleton()
    {
        Vector3 skeleton_1_pos = new Vector3(Random.Range(-2.05f, -1.2f), -20.4f, Random.Range(-3.5f, 7.7f));
        GameObject instance_1 = Instantiate(skeleton, skeleton_1_pos, Quaternion.identity);
        instance_1.transform.SetParent(monstersHolder);

        Vector3 skeleton_2_pos = new Vector3(Random.Range(11.0f, 18.5f), -20.4f, -17.6f);
        GameObject instance_2 = Instantiate(skeleton, skeleton_2_pos, Quaternion.identity);
        instance_2.transform.SetParent(monstersHolder);

        Vector3 skeleton_3_pos = new Vector3(Random.Range(-10.0f, -9.0f), -20.4f, Random.Range(-20.5f, -22.7f));
        GameObject instance_3 = Instantiate(skeleton, skeleton_3_pos, Quaternion.identity);
        instance_3.transform.SetParent(monstersHolder);        
    }

    // 더이상 함수를 부르지 않도록 CancelInvoke를 이용함
    public void CancleRespawn()
    {
        CancelInvoke("stage1_Zombie_Front_1");
        CancelInvoke("stage1_Zombie_Front_2");
        CancelInvoke("stage1_Zombie_Side");
        CancelInvoke("stage1_Skeleton");
        gameManager.instance_GM.stage_1 = true;
    }

    public void CancleRespawn_GameOver()
    {
        CancelInvoke("stage1_Zombie_Front_1");
        CancelInvoke("stage1_Zombie_Front_2");
        CancelInvoke("stage1_Zombie_Side");
        CancelInvoke("stage1_Skeleton");
    }
}
