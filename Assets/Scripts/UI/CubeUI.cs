using System.Collections;
using System.Collections.Generic;
using Models;
using TMPro;
using UnityEngine;

public class CubeUI : MonoBehaviour
{

    public TextMeshProUGUI text;

    public void UpdateText(string number)
    {
        text.text = number;
    }
}
