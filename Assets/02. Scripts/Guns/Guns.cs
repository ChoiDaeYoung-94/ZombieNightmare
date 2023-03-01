using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Guns : MonoBehaviour
{
    // 사운드
    protected AudioSource _audio;
    public AudioClip fireSfx;

    // muzzleFlash를 표현하기 위함
    public MeshRenderer muzzleFlash;

    // 총을 발사하는 속도를 각 스테이지별로 제한하기 위함
    protected float fireRate;
    protected float nextFire = 0;

    // 총의 위력을 렌덤하게 주기 위해 2개의 Damage변수를 줌
    protected int rDamage_1, rDamage_2;

    protected bool isFire = false;

    // 총의 나가는 방식은 Ray를 이용하여 구현
    protected RaycastHit hit;

    public Transform rayStart;
    public Transform rayEnd;

    protected Animator ani;
    
    protected virtual void Start()
    {
        _audio = GetComponent<AudioSource>();
        muzzleFlash.enabled = false;
        ani = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        Debug.DrawLine(rayStart.position, rayEnd.position, Color.red);

        if (Physics.Raycast(rayStart.position, (rayEnd.position - rayStart.position).normalized, out hit, 100.0f) && !(SceneManager.GetActiveScene().name == "Main") && !(SceneManager.GetActiveScene().name == "Clear"))
        {
            if (isFire)
            {
                if (Time.time >= nextFire)
                {
                    nextFire = Time.time + fireRate;
                    Debug.Log("in_isfire_Guns");

                    if (hit.collider.gameObject.layer == 9)
                    {
                        hit.collider.SendMessage("Hit", Random.Range(rDamage_1, rDamage_2));
                    }
                    StartCoroutine(FireEffect());
                }
            }
        }
    }

    protected virtual IEnumerator FireEffect()
    {
        ani.SetTrigger("Fire");
        _audio.PlayOneShot(fireSfx);
        muzzleFlash.transform.Rotate(Vector3.forward, Random.Range(0.0f, 360.0f));
        muzzleFlash.enabled = true;

        yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
        muzzleFlash.enabled = false;
    }
}
