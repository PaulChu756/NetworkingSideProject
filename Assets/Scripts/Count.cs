using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Count : MonoBehaviour
{
    public int countDown = 10;
    public Text countDownText;

    void awake()
    {
        countDownText = GetComponent<Text>();
    }
}
