using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseZombie_Ctrl : MonoBehaviour
{
    private Animator anim;          // 좀비의 애니메이션을 사용하기 위함

    private int hp = 100;           // 기본 체력
    private float baseZmTotalHp;    // 체력을 LocalScale을 이용하여 Image로 표현하기 위함
    public Transform baseZmBar;     // 체력바의 Transform (LocalScale을 이용하기 위함)

    public Transform Player;        // 플레이어의 위치 (플레이어에게 다가가기 위함)

    bool attack = true;             // 공격을 하기 위한 bool값
    private float attackSwitch = 0;

    public AudioSource Source;                  // 좀비의 각종 사운드를 내기 위함
    public AudioClip[] baseZombieCreateSound;
    public AudioClip[] baseZombieAttackSound;
    public AudioClip[] baseZombieDieSound;

    private Player_Ctrl playerCtrl; // 플레이어의 script를 받아오기 위함

    void Start()
    {
        this.transform.LookAt(Player); // 플레이어를 바라봄
        baseZmTotalHp = hp;
        anim = GetComponent<Animator>();
        //Source.PlayOneShot(baseZombieCreateSound, 0.3f);
        AudioSource.PlayClipAtPoint(baseZombieCreateSound[Random.Range(0, 3)], transform.position);
        gameManager.instance_GM.numberofMonster += 1;
        playerCtrl = FindObjectOfType<Player_Ctrl>();
    }

    void Update()
    {
        // 공격을 7초에 한번씩 하도록 설정
        if (attack == false)
        {
            attackSwitch += 1 * Time.deltaTime;
        }
        if (attackSwitch > 7)
        {
            attack = true;
            attackSwitch = 0;
        }
    }

    void OnTriggerStay(Collider col)
    {
        // 플레이어와 충돌할 경우 공격을 함
        if (col.CompareTag("Player") && attack == true)
        {
            playerCtrl.monsters_Hit(Random.Range(5, 10));
            
            attack = false;
            anim.SetTrigger("Attack");

            //Source.PlayOneShot(baseZombieAttackSound, 0.7f);
            AudioSource.PlayClipAtPoint(baseZombieAttackSound[Random.Range(0, 3)], transform.position);
        }
    }

    // 플레이어가 쏘는 총에 맞았을 시에 발동되는 함수
    void Hit(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            gameManager.instance_GM.BM_getScore();
            gameManager.instance_GM.numberofMonster -= 1;
            //this.gameObject.layer = 0;
            anim.SetTrigger("Die");
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            //Source.PlayOneShot(baseZombieDieSound[Random.Range(0, 2)], 0.3f);
            AudioSource.PlayClipAtPoint(baseZombieDieSound[Random.Range(0, 3)], transform.position);
            Destroy(this.gameObject, 2.0f);
        }
        baseZmBar.transform.localScale = new Vector3((hp / baseZmTotalHp) * 0.5f, 0.5f, 0.5f);
    }
}
