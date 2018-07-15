using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private AudioSource au;
    public Simple_Touchpad touchpad;
    public Fire_zone Fire_Zone;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        au = GetComponent<AudioSource>();
    }
    [SerializeField]
    public Boundary boundary;
    public float tilt;
    public float speed;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    
    private float nextFire;
    
    void start ()
    {
        GameObject gameObj = GameObject.FindWithTag("TouchPad");
        if (gameObj != null)
        {
            touchpad = gameObj.GetComponent<Simple_Touchpad>();
        }
    }

    private void Update()
    {
        if (Fire_Zone.CanFire () && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            au.Play();
        }
    }


    private void FixedUpdate()
    {
        // float moveHorizontal = Input.GetAxis("Horizontal");
        // float moveVertical = Input.GetAxis("Vertical");
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector2 direction = touchpad.GetDirection();
        Vector3 movement = new Vector3 (direction.x, 0.0f, direction.y);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
        Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
        0.0f,
        Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
