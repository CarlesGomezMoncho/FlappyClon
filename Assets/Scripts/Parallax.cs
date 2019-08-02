using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public float speed;
    public bool destroy;

    private float width;

    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (GameController.Instance.state != State.end)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);

            Camera cam = Camera.main;
            float height = 2f * cam.orthographicSize;
            float camWidth = height * cam.aspect;

            if (transform.position.x + (width / 2) < Camera.main.transform.position.x - (camWidth / 2))
            {
                if (destroy)
                {
                    Destroy(gameObject);
                }
                else
                {
                    transform.position = new Vector2(transform.position.x + (width * 3), transform.position.y);
                }
            }
        }
    }
}
