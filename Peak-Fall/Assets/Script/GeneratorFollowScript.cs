using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorFollowScript : MonoBehaviour
{
    public Transform target;

    private void LateUpdate() {
        if (target.position.y < transform.position.y) {
            Vector3 newPosititon = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newPosititon;
        }
    }
}
