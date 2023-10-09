using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SawController : MonoBehaviour
{
    public GameObject o_gameManager;
    GameManager gameManager;    

    public float movementSpeed;
    public float offset;
    private bool moveUp;
    private float originY;

    // Start is called before the first frame update
    void Start()
    {
        moveUp = false;
        originY = transform.position.y;
        gameManager = o_gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        moveSaw();

        if (Mathf.Abs((transform.position.y - originY)) >= offset)
        {
            moveUp = true;
        }

        if (transform.position.y >= originY)
        {
            moveUp = false;
                
        }
    }

    public void moveSaw()
    {

        if (moveUp)
        {
            transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.setGameOver(true);
        }
    }
}
