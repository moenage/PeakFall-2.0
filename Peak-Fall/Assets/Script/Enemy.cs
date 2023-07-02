using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private int damage = 5;

    // Start is called before the first frame update
    void Start() {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<PlayerMovement>() != null)
            ScoreSystem.instance.reduceScore(damage);
    }

}