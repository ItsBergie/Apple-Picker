using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    
    public GameObject applePrefab;

    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directins
    public float changeDirChance = 0.1f;

    // Seconds beteen Aplle instatiations
    public float appleDropDelay = 1f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // Start dropping apples
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic movement pg 643
        Vector3 pos = transform.position;

        // Time based use time that elapse from last frame (deltaTime)
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        
        // Changing directions
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Move Right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        
    }

    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1; // Change Direction randomoly
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        // Time Delay Recursive Function kinda...
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }
}
