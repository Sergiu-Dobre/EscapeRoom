using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationLock : MonoBehaviour
{
    public int[] combination = { 1, 2, 3, 4 };  // the correct combination
    public GameObject[] wheels;  // array of the four wheels
    public float rotationSpeed = 1.0f;  // rotation speed of the wheels
    public float minAngle = -18.0f;  // minimum angle of the wheels
    public float maxAngle = 342.0f;  // maximum angle of the wheels
    public GameObject unlockedObject;  // object to be unlocked
    public AudioClip unlockSound;  // sound to be played when the lock is unlocked

    private int[] currentCombination = { 0, 0, 0, 0 };  // the current combination entered by the player
    private bool isLocked = true;  // whether the lock is currently locked
    private AudioSource audioSource;  // AudioSource component to play the unlock sound

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isLocked)
        {
            // rotate each wheel when clicked
            for (int i = 0; i < 4; i++)
            {
                if (Input.GetMouseButton(0) && wheels[i].GetComponent<Collider>().Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity))
                {
                    float rotation = Input.GetAxis("Mouse X") * rotationSpeed;
                    float angle = Mathf.Clamp(wheels[i].transform.localEulerAngles.z - rotation, minAngle, maxAngle);
                    wheels[i].transform.localEulerAngles = new Vector3(0, 0, angle);
                    currentCombination[i] = Mathf.RoundToInt((angle - minAngle) / ((maxAngle - minAngle) / 9)) + 1;
                }
            }

            // check if the current combination is correct
            if (currentCombination[0] == combination[0] && currentCombination[1] == combination[1] && currentCombination[2] == combination[2] && currentCombination[3] == combination[3])
            {
                isLocked = false;
                unlockedObject.SetActive(true);
                if (unlockSound != null)
                {
                    audioSource.PlayOneShot(unlockSound);
                }
            }
        }
    }
}
