using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class PlatformGenerator : MonoBehaviour
{
    public List<GameObject> platformList = new List<GameObject>();

    public float genTime;
    public float genCountTime;
    public int maxPlatforms = 10;
    int index = 0;
    private Vector3 genPosition;
    private int numOfPlatforms;

    void Update() {
        generatePlatform();
        Debug.Log(numOfPlatforms);
    }

    public void generatePlatform() {
        if (numOfPlatforms <= maxPlatforms) {
            genCountTime += Time.deltaTime;
            genPosition = new Vector3(Random.Range(-6.5f, 5.5f), transform.position.y - 50f, 0);
            if (genCountTime >= genTime) {
                generateRandPlatform();
                genCountTime = 0;
            }
        }
    }

    public void generateRandPlatform() {
        //if (Random.value < 0.3) {
            index = Random.Range(0, platformList.Count);
            genPosition = new Vector3(Random.Range(-7f, 6f), transform.position.y - 50f + Random.Range(-6.5f, 5.5f), 0);
            Instantiate(platformList[index], genPosition, Quaternion.identity);
            numOfPlatforms+= 1;
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Platform")) {
            //generateRandPlatform();
            Destroy(collision.gameObject);
            numOfPlatforms--;
        }
    }
}
