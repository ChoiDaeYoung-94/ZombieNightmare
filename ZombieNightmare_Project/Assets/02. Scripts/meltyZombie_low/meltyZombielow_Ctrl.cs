using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meltyZombielow_Ctrl : MonoBehaviour
{
    private Animator anim;

    private int hp = 500;
    private float meltylowTotalHp;
    public Transform meltylowBar;

    public float speed;

    public Transform Player;

    bool attack = true;
    bool caution = true;
    bool zdamage = true;
    private float attackSwitch = 0;

    private float idleSwitch = 0;

    public AudioSource Source;
    public AudioClip[] meltylowCreateSound;
    public AudioClip meltylowAttackSound;
    public AudioClip[] meltylowDieSound;
    public AudioClip meltyCautionSound;
    public AudioClip meltyDamageSound;

    private Player_Ctrl playerCtrl;

    void Start()
    {
        this.transform.LookAt(Player);
        meltylowTotalHp = hp;
        anim = GetComponent<Animator>();
        //Source.PlayOneShot(meltylowCreateSound, 0.3f);
        AudioSource.PlayClipAtPoint(meltylowCreateSound[Random.Range(0, 3)], transform.position);
        gameManager.instance_GM.numberofMonster += 1;
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
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player") && attack == true)
        {
            playerCtrl.monsters_Hit(Random.Range(10, 15));
            speed = 0.05f;
            attackSwitch = 0;
            attack = false;
            anim.SetTrigger("Attack");
        }
    }

    void Hit(int damage)
    {
        hp -= damage;

        if (hp <= 150 && caution == true)
        {
            caution = !caution;
            anim.SetTrigger("Caution");
        }

        if (hp <= 100 && zdamage == true)
        {
            zdamage = !zdamage;
            anim.SetTrigger("Damage");
        }

        if (hp <= 0)
        {
            hp = 0;
            speed = 0;
            gameManager.instance_GM.ML_getScore();
            gameManager.instance_GM.numberofMonster -= 1;
            this.gameObject.layer = 0;
            anim.SetTrigger("Die");
            GetComponent<CapsuleCollider>().enabled = false;
            //Source.PlayOneShot(meltylowDieSound[Random.Range(0, 2)], 0.3f);
            AudioSource.PlayClipAtPoint(meltylowDieSound[Random.Range(0, 3)], transform.position);
            Destroy(this.gameObject, 2.0f);
        }
        meltylowBar.transform.localScale = new Vector3((hp / meltylowTotalHp) * 0.5f, 0.5f, 0.5f);
    }

    public void Attack()
    {
        AudioSource.PlayClipAtPoint(meltylowAttackSound, transform.position);
    }

    public void Caution()
    {
        AudioSource.PlayClipAtPoint(meltyCautionSound, transform.position);
    }

    public void Damage()
    {
        AudioSource.PlayClipAtPoint(meltyDamageSound, transform.position);
    }

}
