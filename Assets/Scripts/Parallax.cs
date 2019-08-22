using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public float speed;
    public bool destroy;
    public bool noReplace;

    private float width;

    void Start()
    {
        try
        {
            width = GetComponent<SpriteRenderer>().bounds.size.x;
        }
        catch (System.Exception)
        {
            try
            {
                width = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
            }
            catch
            {
                Debug.Log("peta");
                width = 1;
            }
            
        }
        
    }

    void Update()
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
                if (!noReplace)
                {
                    transform.position = new Vector2(transform.position.x + (width * 3), transform.position.y);
                }
            }
        }
        
    }
}
