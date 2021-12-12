using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_3_MonsterSpawn : MonoBehaviour
{
    public GameObject baseZombie;
    public GameObject skeleton;
    public GameObject meltyZombie;
    public GameObject lowMeltyZombie;
    public GameObject boss;

    private Transform monstersHolder;

    void Start()
    {
        Invoke("stage3_Boss", 120);
        InvokeRepeating("stage3_Zombie", 5, 2);
        InvokeRepeating("stage3_Skeleton", 5, 5);
        InvokeRepeating("stage3_MeltyZombie", 10, 5);
        InvokeRepeating("stage3_LowMeltyZombie", 10, 5);
        InvokeRepeating("stage3_Monster_Side", 10, 30);

        monstersHolder = new GameObject("Monsters").transform;
    }

    void Update()
    {
        if (gameManager.instance_GM.gameOver == true)
            CancleRespawn_GameOver();
    }

    void stage3_Zombie()
    {
        Vector3 bZombie_1_pos = new Vector3(Random.Range(23.2f, 29.7f), -5.7f, Random.Range(-38.0f, -23.0f));
        Vector3 bZombie_2_pos = new Vector3(Random.Range(23.2f, 29.7f), -5.7f, Random.Range(-38.0f, -23.0f));
        Vector3 bZombie_3_pos = new Vector3(Random.Range(23.2f, 29.7f), -5.7f, Random.Range(-38.0f, -23.0f));

        GameObject instance_1 = Instantiate(baseZombie, bZombie_1_pos, Quaternion.identity);
        GameObject instance_2 = Instantiate(baseZombie, bZombie_2_pos, Quaternion.identity);
        GameObject instance_3 = Instantiate(baseZombie, bZombie_2_pos, Quaternion.identity);

        instance_1.transform.SetParent(monstersHolder);
        instance_2.transform.SetParent(monstersHolder);
        instance_3.transform.SetParent(monstersHolder);
    }

    void stage3_Skeleton()
    {
        Vector3 skeleton_1_pos = new Vector3(Random.Range(27.5f, 31.2f), -3.5f, -9.6f);
        GameObject instance_1 = Instantiate(skeleton, skeleton_1_pos, Quaternion.identity);

        Vector3 skeleton_2_pos = new Vector3(Random.Range(23.2f, 29.7f), -5.7f, Random.Range(-38.0f, -30.0f));
        GameObject instance_2 = Instantiate(skeleton, skeleton_2_pos, Quaternion.identity);

        instance_1.transform.SetParent(monstersHolder);
        instance_2.transform.SetParent(monstersHolder);
    }

    void stage3_MeltyZombie()
    {
        Vector3 meltyZombie_1_pos = new Vector3(Random.Range(22.0f, 31.0f), 0.1f, Random.Range(-5.5f, -8.0f));
        GameObject instance_1 = Instantiate(meltyZombie, meltyZombie_1_pos, Quaternion.identity);
        instance_1.transform.SetParent(monstersHolder);

        Vector3 meltyZombie_2_pos = new Vector3(Random.Range(23.2f, 29.7f), -5.7f, Random.Range(-38.0f, -30.0f));
        GameObject instance_2 = Instantiate(meltyZombie, meltyZombie_2_pos, Quaternion.identity);
        instance_2.transform.SetParent(monstersHolder);
    }

    void stage3_LowMeltyZombie()
    {
        Vector3 lowMeltyZombie_1_pos = new Vector3(Random.Range(22.0f, 31.0f), 0.1f, Random.Range(-5.5f, -8.0f));
        GameObject instance_1 = Instantiate(lowMeltyZombie, lowMeltyZombie_1_pos, Quaternion.identity);
        instance_1.transform.SetParent(monstersHolder);

        Vector3 lowMeltyZombie_2_pos = new Vector3(Random.Range(23.2f, 29.7f), -5.7f, Random.Range(-38.0f, -30.0f));
        GameObject instance_2 = Instantiate(meltyZombie, lowMeltyZombie_2_pos, Quaternion.identity);
        instance_2.transform.SetParent(monstersHolder);
    }

    void stage3_Monster_Side()
    {
        Vector3 lowMeltyZombie_1_pos = new Vector3(22.0f, -5.7f, -40);
        GameObject instance_1 = Instantiate(lowMeltyZombie, lowMeltyZombie_1_pos, Quaternion.identity);
        instance_1.transform.SetParent(monstersHolder);

        Vector3 meltyZombie_2_pos = new Vector3(30.0f, -5.7f, -40);
        GameObject instance_2 = Instantiate(meltyZombie, meltyZombie_2_pos, Quaternion.identity);
        instance_2.transform.SetParent(monstersHolder);
    }

    void stage3_Boss()
    {
        Vector3 boss_pos = new Vector3(26.0f, -5.7f, -26.0f);
        GameObject instance_1 = Instantiate(boss, boss_pos, Quaternion.identity);
        instance_1.transform.SetParent(monstersHolder);

        stage3_Zombie();
        stage3_Zombie();
        stage3_Zombie();

        Vector3 skeleton_2_pos = new Vector3(Random.Range(23.2f, 29.7f), -5.7f, Random.Range(-38.0f, -30.0f));
        GameObject instance_2 = Instantiate(skeleton, skeleton_2_pos, Quaternion.identity);

        Vector3 meltyZombie_3_pos = new Vector3(Random.Range(23.2f, 29.7f), -5.7f, Random.Range(-38.0f, -30.0f));
        GameObject instance_3 = Instantiate(meltyZombie, meltyZombie_3_pos, Quaternion.identity);
        instance_3.transform.SetParent(monstersHolder);

        Vector3 lowMeltyZombie_4_pos = new Vector3(Random.Range(23.2f, 29.7f), -5.7f, Random.Range(-38.0f, -30.0f));
        GameObject instance_4 = Instantiate(meltyZombie, lowMeltyZombie_4_pos, Quaternion.identity);
        instance_4.transform.SetParent(monstersHolder);

        CancleRespawn();
    }

    public void CancleRespawn()
    {
        CancelInvoke("stage3_Zombie");
        CancelInvoke("stage3_Skeleton");
        CancelInvoke("stage3_MeltyZombie");
        CancelInvoke("stage3_LowMeltyZombie");
        CancelInvoke("stage3_Monster_Side");
        gameManager.instance_GM.stage_3 = true;
    }

    public void CancleRespawn_GameOver()
    {
        CancelInvoke("stage3_Zombie");
        CancelInvoke("stage3_Skeleton");
        CancelInvoke("stage3_MeltyZombie");
        CancelInvoke("stage3_LowMeltyZombie");
        CancelInvoke("stage3_Boss");
        CancelInvoke("stage3_Monster_Side");
    }
}
