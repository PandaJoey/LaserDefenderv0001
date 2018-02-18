using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition : MonoBehaviour {
    public Gizmos enemyGizmo;

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
