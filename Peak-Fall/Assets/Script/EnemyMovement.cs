using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public GameObject platformHolder;


public class EnemyMovement : MonoBehaviour {
    public SpriteRenderer spriteRenderer;
    public float speed = 3.0f;
    public bool isGoingRight = true;
    // float distToGround;
    public float raycastingDistance = 0.1f;
    [SerializeField] private int damage = 5;
    [SerializeField] LayerMask test;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    public Transform groundLayerChecking;

    // Start is called before the first frame update
    void Start() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = isGoingRight;
        if(Physics2D.OverlapBox(groundCheck.position,new Vector2(1,1),90f, groundLayer))
            Debug.Log("success");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<PlayerMovement>() != null)
            ScoreSystem.instance.reduceScore(damage);
    }

    // Update is called once per frame
    void Update() {
        Vector3 directionTrans = (isGoingRight) ? transform.right : -transform.right;
        directionTrans *= Time.deltaTime * speed;
        transform.Translate(directionTrans);

        checkForGround();   
    }

    private void checkForGround() {
        if(!Physics2D.CircleCast(groundCheck.position, 1f, new Vector2(0, 0) ,groundLayer) ){
            isGoingRight = !isGoingRight;
            spriteRenderer.flipX = isGoingRight;
        }
        // bool grounded = Physics.Raycast(transform.position, -Vector3.up, distToGround);
        // if(grounded) {
        //     isGoingRight = !isGoingRight;
        //     spriteRenderer.flipX = isGoingRight;
        
        Vector3 raycastDirection = (isGoingRight) ? Vector3.right : Vector3.left;
        RaycastHit2D grounded = Physics2D.Raycast(transform.position + raycastDirection * raycastingDistance -
        new Vector3(0f, 0.25f, 0f), raycastDirection, 0.045f);
        // if(){
        //     // if(grounded.transform.tag != "Platform") {
        //         isGoingRight = !isGoingRight;
        //         spriteRenderer.flipX = isGoingRight;
        // }

        //try overlapbox
    }
}
