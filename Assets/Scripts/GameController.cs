using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    public State state;

    public GameObject panelStart;
    public GameObject panelEnd;

    private static GameController _instance;

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

                if (Input.GetMouseButtonDown(0))
                {
                    player.StartMovement();
                }
                break;
            case State.game:
                panelStart.SetActive(false);
                break;
            case State.end:
                panelEnd.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    player.Init();
                    player.InitAnimation();//sols se crida al initanimation quan mor i ha de resucitar
                }
                break;
            default:
                break;
        }
    }

}
