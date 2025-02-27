using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject o_gameManager;
    private GameManager gameManager;

    //gravity: 5
    private Rigidbody2D playerRigidBody;
    //8
    public float movementSpeed;
    private float inputHorizontal;
    //12
    public float jumpForce;
    private int numJumps;
    private int maxNumJumps;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start");
        //I can only get this compenent using the following line of code
        //becuase the rigidbody2d is attached to the player and this script
        //is also attached to the player.
        playerRigidBody = GetComponent<Rigidbody2D>();

        numJumps = 1;
        maxNumJumps = 1;

        gameManager = o_gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");

        //Basic movement not ideal
        //moves an object but will ignore collisions
        //transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);

        movePlayerLateral();
        jump();
    }

    private void movePlayerLateral()
    {
        //Value returned will be 0, 1, or -1 depending on what button is pressed
        //no button press: 0
        //right arrow key or d: 1
        //left arrow key or a: -1
        //"Horizontal" is defined in the input section of project settings
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        playerRigidBody.velocity = new Vector2(movementSpeed * inputHorizontal, playerRigidBody.velocity.y);
        flipPlayer();
    }

    private void flipPlayer()
    {
        if(inputHorizontal > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if(inputHorizontal < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && numJumps <= maxNumJumps)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);

            numJumps++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject);

        if(collision.gameObject.CompareTag("OB"))
        {
            gameManager.setGameOver(true);
            Debug.Log("Game Over")
;        }
        else if(collision.gameObject.CompareTag("Grounded"))
        {
            numJumps = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("DoubleJump"))
        {
            //give player double jump
            maxNumJumps = 2;
            //delete object from screen
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("CoinCollectable"))
        {

            Collectable collectable = collision.gameObject.GetComponent<Collectable>();
            PlayerScore playerScore = this.gameObject.GetComponent<PlayerScore>();

            // Collectable Value.
            int collectableValue = collectable.getCollectableValue();

            // Set the players score with the score manager.
            playerScore.setPlayerScore(collectableValue);

            // Destroy Collectable.
            collectable.destroyCollectable();
        }
    }
}
