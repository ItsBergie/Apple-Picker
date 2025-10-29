using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public GameObject goldApplePrefab; // New gold apple prefab

    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;
    public float goldAppleChance = 0.1f; // 10% chance to drop gold apple

    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
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
            speed *= -1;
        }
    }

    void DropApple()
    {
        GameObject appleToDrop;

        // Random chance to drop gold apple
        if (Random.value < goldAppleChance)
            appleToDrop = Instantiate<GameObject>(goldApplePrefab);
        else
            appleToDrop = Instantiate<GameObject>(applePrefab);

        appleToDrop.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }
}
