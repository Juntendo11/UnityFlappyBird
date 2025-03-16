using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class birdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdAlive = true;
    public float floor = -15;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.name="Bob Bird"
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
        //Check for bottom
        if (transform.position.y < floor)
        {
            logic.gameOver();
            birdAlive = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdAlive = false;
    }
}
