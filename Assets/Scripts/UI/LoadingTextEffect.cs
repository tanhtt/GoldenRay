using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingTextEffect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    float timer;
    int dotCount;

    private void Start()
    {
        timer = 0;
        dotCount = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= .5f)
        {
            timer = 0;
            dotCount = (dotCount + 1) % 4;
            this.UpLoadingText();
        }
    }

    void UpLoadingText()
    {
        string dots = new string('.', dotCount);
        this.text.text = "Loading" + dots;
    }
}
