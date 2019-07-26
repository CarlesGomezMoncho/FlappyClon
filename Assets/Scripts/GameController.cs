using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    public State state;

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
                //mostrem pantalla de inici
                if (Input.GetMouseButtonDown(0))
                {
                    player.StartMovement();
                }
                break;
            case State.game:
                break;
            case State.end:
                //mostrem pantalla de fi
                if (Input.GetMouseButtonDown(0))
                {
                    player.Init();
                }
                break;
            default:
                break;
        }
    }

}
