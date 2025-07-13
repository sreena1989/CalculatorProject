using UnityEngine;
using System.Collections.Generic;

public class CalculatorManager : MonoBehaviour
{
    public CalculatorDisplay display;
    private EquationMaker equationMaker = new();

    public void OnButtonPress(string value)
    {
        switch (value)
        {
            case "C":
                equationMaker.Clear();
                display.ClearHistoryData();
                break;
            case "BS":
                equationMaker.Backspace();
                Debug.Log(equationMaker.TestCurrentInputValue());
                break;
            case "+/-":
                equationMaker.ToggleSign();
                break;
            case "=":
                string result = equationMaker.Evaluate();
                display.SetText(result);
                if(equationMaker.HistoryData().Count > 0)
                {
                    display.ShowHistoryText(equationMaker.HistoryData());
                }
               
                return;
            case "%":
                equationMaker.Percent(); 
                break;
            case "+":
            case "-":
            case "*":
            case "/":
                equationMaker.AddOperator(value);
                break;
            default:
                equationMaker.Input(value); // numbers or dot
                break;
        }
       
        display.SetText(equationMaker.GetEquation());
    }
}

