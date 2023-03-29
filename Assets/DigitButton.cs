using UnityEngine;
using UnityEngine.UI;

public class DigitButton : MonoBehaviour
{
    // The index of the wheel that this button affects
    public int wheelIndex;

    // The digit that this button represents
    public int digit;

    // The combination lock script component
    private CombinationLock combinationLock;

    private void Start()
    {
        combinationLock = GameObject.Find("CombinationLock").GetComponent<CombinationLock>();

        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        combinationLock.OnDigitEntered(digit, wheelIndex);
    }
}


