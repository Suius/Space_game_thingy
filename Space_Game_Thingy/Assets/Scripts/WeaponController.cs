using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    public GameObject shot;
    public Transform shotSpawn;
    public Transform shotSpawn1;
    public Transform shotSpawn2;
    public float fireRate;
    public float delay;
    public AudioSource audiosource;

	void Start ()
    {
        audiosource = GetComponent<AudioSource>();
        InvokeRepeating ("fire", delay, fireRate);
	}
	
	
	void fire () {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audiosource.Play();
        if (shotSpawn1 !=null)
        {
            Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
            audiosource.Play();
        }
        if (shotSpawn2 != null)
        {
            Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
            audiosource.Play();
        }
    }
}
