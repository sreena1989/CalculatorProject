using System.Collections.Generic;
using System;

public class EquationMaker
{
    private List<string> inputList = new List<string>();
    private string currentInput = "";
    private List<string> historyList = new List<string>();

    // Append number or dot to the current input
    public void Input(string value)
    {
        currentInput += value;
    }
    public string TestCurrentInputValue()
    {
        return currentInput;
    }
    // Remove the last character
    public void Backspace()
    {
        /*if (currentInput.Length > 0)
            currentInput = currentInput.Substring(0, currentInput.Length - 1);*/


        // If currentInput has something, remove last character
        /*  if (!string.IsNullOrEmpty(currentInput))
          {
              currentInput = currentInput.Substring(0, currentInput.Length - 1);
          }
          else if (inputList.Count > 0)
          {
              // Remove last token (operator or number) if currentInput is empty
              inputList.RemoveAt(inputList.Count - 1);
          }*/


        // Step 1: If we are currently typing a number, just remove the last digit
        if (!string.IsNullOrEmpty(currentInput))
        {
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            return;
        }

        // Step 2: If currentInput is empty, check if we have anything stored in inputlist
        if (inputList.Count == 0)
            return;

        // Step 3: Look at the last item in the inputList 
        string lastToken = inputList[inputList.Count - 1];

        // Step 4: If the last token is a number (not an operator)
        if (double.TryParse(lastToken, out _))
        {
            // Remove it from the inputList 
            inputList.RemoveAt(inputList.Count - 1);

            // Put it back into currentInput so we can delete it digit by digit
            if (inputList.Count > 1)
                currentInput = lastToken.Substring(0, lastToken.Length - 1);
            else
                currentInput = ""; // If only one digit, clear it
        }
        else
        {
            // Step 5: If it's an operator (+, -, *, /), just remove it
            inputList.RemoveAt(inputList.Count - 1);
        }
    }

    // Change the sign of the current input
    public void ToggleSign()
    {
        if (currentInput.StartsWith("-"))
            currentInput = currentInput.Substring(1);
        else if (currentInput.Length > 0)
            currentInput = "-" + currentInput;
    }

    // Clear all input
    public void Clear()
    {
        inputList.Clear();
        historyList.Clear();
        currentInput = "";
    }
    // Find the percentage
    public void Percent()
    {
        if (!string.IsNullOrEmpty(currentInput) && double.TryParse(currentInput, out double value))
        {
            currentInput = (value / 100f).ToString();
        }
    }
    // Add an operator (+, -, *, /)
    public void AddOperator(string op)
    {
        if (!string.IsNullOrEmpty(currentInput))
        {
            inputList.Add(currentInput);
            currentInput = "";
        }

        if (inputList.Count > 0 && "+-*/".Contains(op))
        {
            inputList.Add(op);
            
        }
    }

    // Evaluate the expression (tokens + currentInput)
    public string Evaluate()
    {
        if (!string.IsNullOrEmpty(currentInput))
        {
            inputList.Add(currentInput);
            currentInput = "";
        }

        try
        {
            double result = double.Parse(inputList[0]);

            for (int i = 1; i < inputList.Count; i += 2)
            {
                string op = inputList[i];
                double next = double.Parse(inputList[i + 1]);

                if (op == "+") result += next;
                else if (op == "-") result -= next;
                else if (op == "*") result *= next;
                else if (op == "/") result /= next;
            }
            AddHistoryEquation(inputList, result.ToString());
            inputList.Clear();
            currentInput = result.ToString();
            return currentInput;
        }
        catch
        {
            inputList.Clear();
            currentInput = "";
            return "Error";
        }
    }
    public void AddHistoryEquation(List<string> _inputList, string _result )
    {
        string equation = "";
       
        for (int i = 0; i < _inputList.Count; i++)
        {
            equation += _inputList[i] + " ";
        }

        equation += " = " +_result;
        historyList.Add(equation);
        if (historyList.Count >3)
        {
            historyList.RemoveAt(0);
            //historyList.Clear();
        }
     
    }
    public List<string> HistoryData()
    {
        //string history
        
        return historyList ;
        //return 
    }

    // Return the full equation string to display
    public string GetEquation()
    {
      
        string equation = string.Join(" ", inputList);
        if (!string.IsNullOrEmpty(currentInput))
            equation += " " + currentInput;

        return equation.Trim();
    }
}
