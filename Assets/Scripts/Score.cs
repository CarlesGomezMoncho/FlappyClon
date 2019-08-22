using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        text.text = GameController.Instance.GetPoints().ToString();
    }
}
