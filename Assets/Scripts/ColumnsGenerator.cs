using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnsGenerator : MonoBehaviour
{
    public GameObject column;
    public float minY;
    public float maxY;
    public GameObject columnsContainer;

    public float interval;

    private bool doCoroutine = false;
    private float width;

    void Start()
    {
        StartCoroutine(ColumnGenerate());

        width = column.GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        Camera cam = Camera.main;
        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        //canviem sempre la x del generador per si hem canviat el aspect ratio
        transform.position = new Vector2(Camera.main.transform.position.x + (camWidth / 2) + (width), transform.position.y);
        

        if (GameController.Instance.state == State.game)
        {
            doCoroutine = true;
        }
        else
        {
            doCoroutine = false;
        }
    }

    private IEnumerator ColumnGenerate()
    {
        while (true)
        {
            float nInterval = 0;

            if (doCoroutine)
            {
                DrawColumn();
                nInterval = interval;    
            }

            yield return new WaitForSeconds(nInterval);
        }
    }

    private void DrawColumn()
    {
        float randomY = Random.Range(minY, maxY);

        Vector2 newPos = new Vector2(transform.position.x, randomY);

        Instantiate(column, newPos, transform.rotation).transform.parent = columnsContainer.transform;
    }

}
