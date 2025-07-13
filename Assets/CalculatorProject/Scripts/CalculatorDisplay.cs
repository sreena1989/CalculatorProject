using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class CalculatorDisplay : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    [SerializeField]
    public TextMeshProUGUI[] historyEquation;

    public void SetText(string value)
    {
        displayText.text = value;
    }
    public void ShowHistoryText(List<string> _pastEquationList )
    {
        for (int i =0; i < historyEquation.Length; i++)
        {
            historyEquation[i].gameObject.SetActive(false);
        }
        for (int i = 0 ; i < _pastEquationList.Count; i++)
        {
            historyEquation[i].gameObject.SetActive(true);
            historyEquation[i].text = _pastEquationList[i];
        }
    }
    public void ClearHistoryData()
    {
        for (int i = 0; i < historyEquation.Length; i++)
        {
            historyEquation[i].gameObject.SetActive(true);
            historyEquation[i].text = "";
        }
    }
}
