using UnityEngine;

public class CombinationLockWheelController : MonoBehaviour
{
    public CombinationLockController lockController;
    public int wheelIndex;

    private void OnMouseDown()
    {
        lockController.RotateWheel(1);

        transform.Rotate(Vector3.forward, -36);

        if (lockController.IsCodeCorrect())
        {
            Debug.Log("Code is correct!");
        }
    }
}

