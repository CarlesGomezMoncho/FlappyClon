using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    public State state;

    public GameObject panelStart;
    public GameObject panelEnd;
    public GameObject panelPlay;

    public GameObject columnContainer;

    private static GameController _instance;
    private int points;

    public static GameController Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        state = State.start;
    }

    void Update()
    {
        switch (state)
        {
            case State.start:
                player.Init();

                panelStart.SetActive(true);
                panelEnd.SetActive(false);
                panelPlay.SetActive(false);

                if (Input.GetMouseButtonDown(0))
                {
                    player.StartMovement();
                }
                break;
            case State.game:
                panelStart.SetActive(false);
                panelPlay.SetActive(true);
                break;
            case State.end:
                panelEnd.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    player.Init();
                    player.InitAnimation();//sols se crida al initanimation quan mor i ha de resucitar
                    DeleteColumns();
                    DeletePoints();
                }
                break;
            default:
                break;
        }
    }

    private void DeleteColumns()
    {
        foreach (Transform t in columnContainer.transform)
        {
            Destroy(t.gameObject);
        }
    }

    private void DeletePoints()
    {
        points = 0;
    }

    public void AddPoint()
    {
        points++;
    }

    public int GetPoints()
    {
        return points;
    }


}
