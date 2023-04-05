using UnityEngine;

public class CombinationLockController : MonoBehaviour
{
    public int[] code = { 1, 2, 3, 4 };

    private int[] currentCode = { 0, 0, 0, 0 };
    private int currentWheelIndex = 0;

    public void RotateWheel(int direction)
    {
        int currentValue = currentCode[currentWheelIndex];

        if (direction > 0)
        {
            currentValue = (currentValue + 1) % 10;
        }
        else
        {
            currentValue = (currentValue + 9) % 10;
        }

        currentCode[currentWheelIndex] = currentValue;

        currentWheelIndex++;

        if (currentWheelIndex >= currentCode.Length)
        {
            currentWheelIndex = 0;
        }
    }

    public bool IsCodeCorrect()
    {
        for (int i = 0; i < code.Length; i++)
        {
            if (code[i] != currentCode[i])
            {
                return false;
            }
        }

        return true;
    }
}

