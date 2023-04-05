using UnityEngine;
using System.Collections;

public class DialController : MonoBehaviour
{

    // The current value of the dial
    public int CurrentValue { get; private set; }

    // The maximum value of the dial
    public int MaxValue = 9;

    // The minimum value of the dial
    public int MinValue = 1;

    // The amount by which the dial should rotate with each click
    public float RotationAmount = 40f;

    // The audio clip to play when the dial is clicked
    public AudioClip ClickSound;

    // The audio source component to play the click sound
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        // Set the initial value of the dial
        CurrentValue = MinValue;

        // Get the audio source component
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Rotate the dial when it is clicked
    void OnMouseDown()
    {
        // Rotate the dial by the specified amount
        transform.Rotate(0f, 0f, RotationAmount);

        // Increment the current value of the dial
        CurrentValue++;

        // If the current value is greater than the maximum value, reset it to the minimum value
        if (CurrentValue > MaxValue)
        {
            CurrentValue = MinValue;
        }

        // Play the click sound
        if (ClickSound != null)
        {
            audioSource.PlayOneShot(ClickSound);
        }
    }
}

