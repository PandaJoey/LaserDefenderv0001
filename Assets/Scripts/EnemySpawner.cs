using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    private GameObject enemy;
    public float width = 10.0f;
    public float height = 5.0f;
    private bool movingRight = false;
    public float speed = 2.0f;
    private float xmax;
    private float xmin;
    public float padding = 0.5f;



    // Use this for initialization
    void Start() {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xmin = leftBoundary.x + padding;
        xmax = rightBoundary.x - padding;
        /* puts enemy in each of my position gizmoes.
         * transforming child.transform.position tells the game to put the child object
         * which in this case is the enemy into one of the gizmos which is its parent object
         */
        foreach (Transform child in transform) {
            enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity);
            enemy.transform.parent = child;
        }
        
        
    }

    public void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    // Update is called once per frame
    void Update() {
        if (movingRight) {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }else {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        float rightEdgeOfFormation = transform.position.x + (0.5f * width);
        float leftEdgeOfFormation = transform.position.x - (0.5f * width);

        if (leftEdgeOfFormation < xmin) {
            movingRight = true;
        } else if(rightEdgeOfFormation > xmax) {
            movingRight = false;
        }
    }
}
