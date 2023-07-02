using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {

    }
    public List<GameObject> platformList = new List<GameObject>();

    public float genTime;
    private float genCountTime;
    private Vector3 genPosition;

    // Update is called once per frame
    void Update()
    {
        generatePlatform();
    }
    
    public void generatePlatform() {
        genCountTime += Time.deltaTime;
        genPosition = transform.position;
        genPosition.x = Random.Range(-6.5f, 5.5f);

        if (genCountTime > genTime) {
            typeOfPlatform();
            genCountTime = 0;
        }
    }

    public void typeOfPlatform() {
        int index = Random.Range(0, platformList.Count);
        Instantiate(platformList[index], genPosition, Quaternion.identity);
    }
}
