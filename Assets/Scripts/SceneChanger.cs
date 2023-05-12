using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nextSceneName; // The name of the scene you want to load next
    public string originalSceneName; // The name of the original scene

    private bool canChangeScene = false;

    private void Update()
    {
        if (canChangeScene)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ChangeScene(nextSceneName);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeScene(originalSceneName);
            }
        }
    }

    private void OnMouseDown()
    {
        canChangeScene = true;
    }

    private void OnMouseUp()
    {
        canChangeScene = false;
    }

    // Call this method to load the specified scene
    private void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

