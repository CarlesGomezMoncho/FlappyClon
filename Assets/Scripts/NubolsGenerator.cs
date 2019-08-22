using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NubolsGenerator : MonoBehaviour
{
    public List<GameObject> cloudList;
    public float minSize, maxSize;

    [Range(0, 1)]
    public float intensitat;

    public float despl = -2;

    void Start()
    {
        //nubolsList = new List<GameObject>();

        StartCoroutine(CloudGenerator());
    }

    
    void Update()
    {
        Camera cam = Camera.main;
        float camHeight = 2f * cam.orthographicSize;

        float pos = Random.Range(-camHeight / 2 + despl, camHeight / 2 + despl);

        transform.position = new Vector2(transform.position.x, pos);
    }

    private IEnumerator CloudGenerator()
    {
        while(true)
        {
            yield return new WaitForSeconds(.5f);

            //if (GameController.Instance.state != State.end)
            //{
                float r = Random.value;

                if (intensitat >= r)
                {
                    DrawCloud();
                }
            //}
        }
    }

    private void DrawCloud()
    {
        float range = Random.Range(minSize, maxSize);
        int cloud = Random.Range(0, cloudList.Count);

        GameObject c = Instantiate(cloudList[cloud], transform.position, transform.rotation);
        c.transform.localScale = new Vector2(range, range);
    }
}
