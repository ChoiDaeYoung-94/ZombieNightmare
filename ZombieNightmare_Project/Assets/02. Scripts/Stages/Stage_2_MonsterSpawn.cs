using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_MonsterSpawn : MonoBehaviour
{
    public GameObject baseZombie;
    public GameObject skeleton;
    public GameObject meltyZombie;

    private Transform monstersHolder;

    void Start()
    {
        InvokeRepeating("stage2_Zombie", 5.0f, 3.0f);
        InvokeRepeating("stage2_Skeleton", 10.0f, 4.0f);
        InvokeRepeating("stage2_MeltyZombie", 20.0f, 7.0f);
        InvokeRepeating("stage2_Monster_side", 20.0f, 20.0f);
        Invoke("CancleRespawn", 100.0f);

        monstersHolder = new GameObject("Monsters").transform;
    }

    void Update()
    {
        if (gameManager.instance_GM.gameOver == true)
            CancleRespawn_GameOver();
    }

    void stage2_Zombie()
    {
        Vector3 bZombie_1_pos = new Vector3(Random.Range(-6.0f, 6.0f), 0.1f, Random.Range(2.0f, 5.0f));
        GameObject instance_1 = Instantiate(baseZombie, bZombie_1_pos, Quaternion.identity);
        instance_1.transform.SetParent(monstersHolder);

        Vector3 bZombie_2_pos = new Vector3(Random.Range(-6.0f, 6.0f), 0.1f, Random.Range(2.0f, 5.0f));
        GameObject instance_2 = Instantiate(baseZombie, bZombie_2_pos, Quaternion.identity);
        instance_2.transform.SetParent(monstersHolder);
    }

    void stage2_Skeleton()
    {
        Vector3 skeleton_1_pos = new Vector3(Random.Range(-6.0f, 6.0f), 0.1f, Random.Range(3.0f, 7.0f));
        GameObject instance_1 = Instantiate(skeleton, skeleton_1_pos, Quaternion.identity);
        instance_1.transform.SetParent(monstersHolder);
    }

    void stage2_MeltyZombie()
    {
        Vector3 meltyZombie_1_pos = new Vector3(Random.Range(-6.0f, 6.0f), 0.1f, Random.Range(3.0f, 8.0f));
        GameObject instance_1 = Instantiate(meltyZombie, meltyZombie_1_pos, Quaternion.identity);
        instance_1.transform.SetParent(monstersHolder);
    }

    void stage2_Monster_side()
    {
        Vector3 skeleton_1_pos = new Vector3(9.0f, 0.1f, 0);
        GameObject instance_1 = Instantiate(skeleton, skeleton_1_pos, Quaternion.identity);
        instance_1.transform.SetParent(monstersHolder);

        Vector3 skeleton_2_pos = new Vector3(-9.0f, 0.1f, 0);
        GameObject instance_2 = Instantiate(skeleton, skeleton_2_pos, Quaternion.identity);
        instance_2.transform.SetParent(monstersHolder);
    }

    public void CancleRespawn()
    {
        CancelInvoke("stage2_Zombie");
        CancelInvoke("stage2_Skeleton");
        CancelInvoke("stage2_MeltyZombie");
        CancelInvoke("stage2_Monster_side");
        gameManager.instance_GM.stage_2 = true;
    }

    public void CancleRespawn_GameOver()
    {
        CancelInvoke("stage2_Zombie");
        CancelInvoke("stage2_Skeleton");
        CancelInvoke("stage2_MeltyZombie");
        CancelInvoke("stage2_Monster_side");
    }
}
