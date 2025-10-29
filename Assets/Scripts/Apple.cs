using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [Header("Inscribed")]
    public int points = 100; // Regular apple worth 100 by default

    public static float bottomY = -20f;

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            // Get a reference to the ApplePicker component of Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // Call a public AppleMissed() in apScript
            apScript.AppleMissed();
        }
    }
}
