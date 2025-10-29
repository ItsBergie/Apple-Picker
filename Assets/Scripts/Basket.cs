using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;

    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision col)
    {
        GameObject collidedWith = col.gameObject;

        // Handle both regular and gold apples
        if (collidedWith.CompareTag("Apple") || collidedWith.CompareTag("Gold Apple"))
        {
            Apple appleScript = collidedWith.GetComponent<Apple>();
            if (appleScript != null)
            {
                scoreCounter.score += appleScript.points;
                HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
            }

            Destroy(collidedWith);
        }
    }
}
