using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_Ctrl : MonoBehaviour
{
    private Animator anim;

    private int hp = 18000;
    private float bossTotalHp;
    public Transform bossBar;

    public float speed;

    public Transform Player;

    bool attack = true;
    bool Bdamage = true;
    private float attackSwitch = 0;
    private float damageSwitch = 0;

    private float idleSwitch = 0;

    public AudioSource Source;
    public AudioClip bossCreateSound;
    public AudioClip bossAttackSound;
    public AudioClip bossDieSound;
    public AudioClip[] bossDamageSound;

    private Player_Ctrl playerCtrl;

    void Start()
    {
        this.transform.LookAt(Player);
        bossTotalHp = hp;
        anim = GetComponent<Animator>();
        Source.PlayOneShot(bossCreateSound, 1.0f);
        //AudioSource.PlayClipAtPoint(bossCreateSound, transform.position);
        playerCtrl = FindObjectOfType<Player_Ctrl>();
    }

    void Update()
    {
        if ((idleSwitch += 1 * Time.deltaTime) > 3.0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }

        if (attack == false)
        {
            attackSwitch += 1 * Time.deltaTime;
        }
        if (attackSwitch > 5)
        {
            attack = true;
        }

        if (Bdamage == false)
        {
            damageSwitch += 1 * Time.deltaTime;
        }
        if (damageSwitch > 2)
        {
            Bdamage = true;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player") && attack == true)
        {
            playerCtrl.monsters_Hit(Random.Range(20, 30));
            speed = 0.05f;
            attackSwitch = 0;
            attack = false;
            anim.SetTrigger("Attack");
        }
    }

    void Hit(int damage)
    {
        hp -= damage;

        if ((hp == 400 || hp == 300 || hp == 200 || hp == 100) && Bdamage == true)
        {
            Bdamage = !Bdamage;
            damageSwitch = 0;
            anim.SetTrigger("Damage");
        }

        if (hp <= 0)
        {
            hp = 0;
            gameManager.instance_GM.Boss_getScore();
            gameManager.instance_GM.numberofBoss -= 1;
            //this.gameObject.layer = 0;
            anim.SetTrigger("Death");
            GetComponent<CapsuleCollider>().enabled = false;
            //Source.PlayOneShot(bossDieSound[Random.Range(0, 2)], 0.3f);
            AudioSource.PlayClipAtPoint(bossDieSound, transform.position);
            Destroy(this.gameObject, 2.0f);
        }
        bossBar.transform.localScale = new Vector3((hp / bossTotalHp) * 3.0f, 1.0f, 1.0f);
    }

    public void Attack()
    {
        AudioSource.PlayClipAtPoint(bossAttackSound, transform.position);
    }

    public void Damage()
    {
        AudioSource.PlayClipAtPoint(bossDamageSound[Random.Range(0, 3)], transform.position);
    }
}
