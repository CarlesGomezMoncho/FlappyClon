using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float impuls = 5;
    public GameObject limitSuperior;
    public Animator playerAnimator;

    private Rigidbody2D rb;
    private bool addForce = false;
    private Vector2 startPosition;
    private Quaternion startRotation;

    private Parallax parallax;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        startPosition = transform.position;
        startRotation = transform.rotation;

        parallax = GetComponent<Parallax>();

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

        switch (GameController.Instance.state)
        {
            case State.start:
                parallax.enabled = false;
                break;
            case State.game:
                break;
            case State.end:
                parallax.enabled = true;
                break;
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
        //end si colisiona en coses de la capa 8 (capa colisions)
        if (collision.gameObject.layer == 8)
        {
            End();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) //capa puntuació
        {
            GameController.Instance.AddPoint();
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
        rb.velocity = Vector2.zero;
        rb.simulated = false;
        transform.position = startPosition;
        transform.rotation = startRotation;
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
