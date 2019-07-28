using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float impuls = 5;
    public GameObject limitInferior;
    public Animator playerAnimator;

    private Rigidbody2D rb;
    private bool addForce = false;
    private Vector2 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        startPosition = transform.position;
        
        Init();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (GameController.Instance.state)
            {
                case State.start:
                    break;
                case State.game:
                    addForce = true;
                    playerAnimator.SetTrigger("Fly");
                    break;
                case State.end:
                    break;
                default:
                    break;
            }
            
        }
    }

    private void FixedUpdate()
    {
        if (addForce)
        {
            rb.AddForce(Vector2.up * impuls, ForceMode2D.Impulse);
            addForce = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //CANVIAR ESTE IF DE UN OBJECTE CONCRET A UNA CAPA
        if (collision.gameObject == limitInferior)
        {
            End();
        }
    }

    public void End()
    {
        GameController.Instance.state = State.end;
        playerAnimator.SetTrigger("End");
    }

    public void Init()
    {

        GameController.Instance.state = State.start;
        rb.simulated = false;
        transform.position = startPosition;
    }

    public void StartMovement()
    {
        GameController.Instance.state = State.game;
        playerAnimator.SetTrigger("Game");
        rb.simulated = true;
    }

    public void InitAnimation()
    {
        playerAnimator.SetTrigger("Init");
    }
}
