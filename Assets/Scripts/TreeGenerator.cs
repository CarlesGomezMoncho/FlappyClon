using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public List<GameObject> treeList;
    public float minSize, maxSize;

    [Range(0, 1)]
    public float intensity;

    void Start()
    {
        StartCoroutine(TreeGenerate());
    }


    private IEnumerator TreeGenerate()
    {
        while (true)
        {
            yield return new WaitForSeconds(.5f);

            //if (GameController.Instance.state != State.end)
            //{
                float r = Random.value;

                if (intensity >= r)
                {
                    DrawTree();
                }
            //}
        }
    }

    private void DrawTree()
    {
        float range = Random.Range(minSize, maxSize);
        int cloud = Random.Range(0, treeList.Count);

        GameObject c = Instantiate(treeList[cloud], transform.position, transform.rotation);
        c.transform.localScale = new Vector2(range, range);
    }
}
