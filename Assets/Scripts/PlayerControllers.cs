using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour {
    public float speed = 15.0f;
    public float padding = 0.5f;
    public GameObject playerProjectile;
    float xmin;
    float xmax;
    private GameObject beam;
    public float projectileSpeed;
    public float firingRate = 0.2f;
    // Use this for initialization
    void Start()  {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;
    }

    // Update is called once per frame using GetKey to get input and 
    // using transform and detatime to make a smoothmovement of the ship
    void Update()  {
        if (Input.GetKey(KeyCode.A))  {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))  {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            InvokeRepeating("Fire", 0.000001f, firingRate);
        } else if (Input.GetKeyUp(KeyCode.UpArrow)) {
            CancelInvoke("Fire");
        }
    }

    void Fire() {
        beam = Instantiate(playerProjectile, transform.position, Quaternion.identity);
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
    }
    
}
