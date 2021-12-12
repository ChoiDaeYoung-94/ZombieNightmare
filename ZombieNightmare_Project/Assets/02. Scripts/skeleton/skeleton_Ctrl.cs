using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton_Ctrl : MonoBehaviour
{
    private Animator anim;

    private int hp = 200;
    private float skeletonTotalHp;
    public Transform skeletonBar;

    public float speed;

    public Transform Player;

    bool attack = true;
    bool sdamage = true;
    bool knockback = true;
    private float attackSwitch = 0;

    private float idleSwitch = 0;

    public AudioSource Source;
    public AudioClip[] skeletonCreateSound;
    public AudioClip[] skeletonAttackSound;
    public AudioClip skeletonDieSound;
    public AudioClip skeletonDamageSound;
    public AudioClip skeletonKnockbackSound;

    private Player_Ctrl playerCtrl;

    void Start()
    {
        this.transform.LookAt(Player);
        skeletonTotalHp = hp;
        anim = GetComponent<Animator>();
        //Source.PlayOneShot(skeletonCreateSound, 0.3f);
        AudioSource.PlayClipAtPoint(skeletonCreateSound[Random.Range(0, 3)], transform.position);
        gameManager.instance_GM.numberofMonster += 1;
        playerCtrl = FindObjectOfType<Player_Ctrl>();
    }

    void Update()
    {
        if ((idleSwitch += 1 * Time.deltaTime) > 6.5f)
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
            attackSwitch = 0;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player") && attack == true)
        {
            playerCtrl.monsters_Hit(Random.Range(5, 10));
            speed = 0.01f;
            attack = false;
            anim.SetTrigger("Attack");
        }
    }

    void Hit(int damage)
    {
        hp -= damage;

        if (hp <= 100 && sdamage == true)
        {
            sdamage = !sdamage;
            anim.SetTrigger("Damage");
        }

        if (hp <= 50 && knockback == true)
        {
            knockback = !knockback;
            anim.SetTrigger("Knockback");
        }

        if (hp <= 0)
        {
            hp = 0;
            speed = 0;
            gameManager.instance_GM.S_getScore();
            gameManager.instance_GM.numberofMonster -= 1;
            //this.gameObject.layer = 0;
            anim.SetTrigger("Die");
            GetComponent<CapsuleCollider>().enabled = false;
            //Source.PlayOneShot(skeletonDieSound[Random.Range(0, 2)], 0.3f);
            AudioSource.PlayClipAtPoint(skeletonDieSound, transform.position);
            Destroy(this.gameObject, 2.0f);
        }
        skeletonBar.transform.localScale = new Vector3((hp / skeletonTotalHp) * 0.1f, 0.07f, 0.05f);
    }

    public void Attack()
    {
        AudioSource.PlayClipAtPoint(skeletonAttackSound[Random.Range(0, 3)], transform.position);
    }

    public void Damage()
    {
        AudioSource.PlayClipAtPoint(skeletonDamageSound, transform.position);
    }

    public void Knockback()
    {
        AudioSource.PlayClipAtPoint(skeletonKnockbackSound, transform.position);
    }
}
