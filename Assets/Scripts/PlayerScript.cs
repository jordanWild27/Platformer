using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rd2d;   //establishes rigidbody component
    public float speed;         //float value for movement speed
    public Text score;          //creates text variable for score
    private int scoreValue = 0;     //integer to store score in for updating

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();     //saves reference to rigidbody
        score.text = scoreValue.ToString();     //sets score to 0
    }

    // Update is fixed from start
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");    //assigns float variables to get axis values
        float verMovement = Input.GetAxis("Vertical");

        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));   //saves values on the axis to the rigidbody
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Coin")    //when player hits coin it is destroyed and adds a point to score
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)   //if W key is pressed player jumps
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);  //adds impulse force against gravity
            }
        }

    }

    void Update()   //quits game when escape key is pressed
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
