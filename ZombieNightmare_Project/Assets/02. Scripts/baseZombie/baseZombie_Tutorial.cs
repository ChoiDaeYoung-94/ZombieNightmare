using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseZombie_Tutorial : MonoBehaviour
{
    private Animator anim;

    private int hp = 60;
    private float baseZmTotalHp;
    public Transform baseZmBar;

    public AudioSource Source;
    public AudioClip[] baseZombieCreateSound;
    public AudioClip[] baseZombieDieSound;
    
    void Start()
    {
        Gun_main_clear.tutorialZombie += 1;
        baseZmTotalHp = hp;
        anim = GetComponent<Animator>();
        //Source.PlayOneShot(baseZombieCreateSound, 0.3f);
        AudioSource.PlayClipAtPoint(baseZombieCreateSound[Random.Range(0, 3)], transform.position);
    }

    void Hit(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Gun_main_clear.tutorialZombie -= 1;
            hp = 0;
            this.gameObject.layer = 0;
            anim.SetTrigger("Die");
            //Source.PlayOneShot(baseZombieDieSound[Random.Range(0, 2)], 0.3f);
            AudioSource.PlayClipAtPoint(baseZombieDieSound[Random.Range(0, 3)], transform.position);
            Destroy(this.gameObject, 2.0f);
        }
        baseZmBar.transform.localScale = new Vector3((hp / baseZmTotalHp) * 0.5f, 0.5f, 0.5f);
    }
}
