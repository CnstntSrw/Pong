using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown _ColorDropdown;

    private List<Color> _Colors = new List<Color>();


    // Start is called before the first frame update
    void Start()
    {
        FillListOfColors();
        var currentColor = GameManager.Instance.GetBallColor();
        _ColorDropdown.value = _Colors.IndexOf(currentColor);
    }
    private void FillListOfColors()
    {
        _Colors.Add(Color.white);
        _Colors.Add(Color.blue);
        _Colors.Add(Color.green);
        _Colors.Add(Color.cyan);
        _Colors.Add(Color.grey);
        _Colors.Add(Color.red);
        _Colors.Add(Color.yellow);
    }

    public void OnColorChanged()
    {
        var color = _Colors[_ColorDropdown.value];
        GameManager.Instance.SetBallColor(color);
    }
}
