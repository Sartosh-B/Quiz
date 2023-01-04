using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswearButton : MonoBehaviour
{
    [SerializeField] Color defaultColor;
    [SerializeField] Color selectedColor;

    [SerializeField] Button btn;
    void Start()
    {
        ButtonChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ButtonChangeColor()
    {
        ColorBlock cb = btn.colors;
        cb.normalColor = defaultColor;
        cb.highlightedColor = selectedColor;
        cb.pressedColor = selectedColor;
        cb.selectedColor = selectedColor;
        btn.colors = cb;
    }
}
