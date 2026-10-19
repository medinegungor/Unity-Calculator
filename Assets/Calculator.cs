using UnityEngine;
using TMPro;
public class Calculator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;
    private double firstNumber = 0;
    private double secondNumber = 0;
    private string currentOperator = "";
    private bool isNewCalculation = true;
    private void Start()
    {
        if (displayText != null)
            displayText.text = "0";
    }

    public void givenNumber(string number)
    {
        if (isNewCalculation || displayText.text == "0")
        {
            displayText.text = number;
            isNewCalculation = false;
        }
        else {
            displayText.text += number;
        }
    }
    
    public void givenOperator(string op)
    {
        if (displayText == null) return;
        double.TryParse(displayText.text, out firstNumber);
        currentOperator = op;
        isNewCalculation = true;
    }
    public void OnEqualClicked()
    {
        if (displayText == null) return;
        double result = 0;
        double.TryParse(displayText.text, out secondNumber);
        if (currentOperator == "+")
            result = firstNumber + secondNumber;
        else if (currentOperator == "-")
            result = firstNumber - secondNumber;
        else if (currentOperator == "*")
            result = firstNumber * secondNumber;
        else if (currentOperator == "/")
        {
            if (secondNumber != 0)
                result = firstNumber / secondNumber;
            else
            {
                displayText.text = "Error";
                isNewCalculation = true;
                return;
            }
        }
        else
        {
            result = secondNumber;
        }
        displayText.text = result.ToString();
        firstNumber = result;
        isNewCalculation = true;
    }
    public void reset()
    {
        if (displayText != null)
            displayText.text = "0";

        firstNumber = 0;
        secondNumber = 0;
        currentOperator = "";
        isNewCalculation = true;
    }
}