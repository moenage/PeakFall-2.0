using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public Transform generatorTarget;

    private void LateUpdate() {
        if(target.position.y < transform.position.y) {
            Vector3 newPosititon = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newPosititon;

            Vector3 newGenPosition = new Vector3(0, target.position.y + 12, 0);
            generatorTarget.position = newGenPosition;
        }
    }
}
