using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{

    
    public interface IDialogueSection
    {
        string SpeakerName { get; }
        string SpeechContents { get; }
        IDialogueSection NextSection { get; }
    }

    public class Monologue : IDialogueSection
    {
        public string SpeakerName { get; set; }
        public string SpeechContents { get; set; }
        public IDialogueSection NextSection { get; set; }

        public Monologue(string speakerName = "AI", string speechContents = "There's nothing now.", IDialogueSection next = null)
        {
            SpeakerName = speakerName;
            SpeechContents = speechContents;
            NextSection = next;
        }
    }

    public class Choices : IDialogueSection
    {
        public string SpeakerName { get; set; }
        public string SpeechContents { get; set; }
        public IDialogueSection NextSection { get; set; }
        public List<(string, IDialogueSection)> Options { get; set; }

        private bool canvasGroupDisplaying;

        public Choices(string speakerName = "AI", string speechContents = "There is nothing here... Choose", List<(string, IDialogueSection)> options = null)
        {
            SpeakerName = speakerName;
            SpeechContents = speechContents;
            Options = options;
        }
    }

    [Header("Text Components")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI contentsText;

    [Header("Dialogue Choice")]
    public GameObject dialogueChoiceObject;
    public Transform parentChoicesTo;

    [Header("Fade")]
    public float canvasGroupFadeTime = 5f;
    private CanvasGroup dialogueCanvasGroup;

    private IDialogueSection currentSection;
    private int indexOfCurrentChoice;
    private bool displayingChoices;
    private bool optionsBeenDisplayed;

    private void Start()
    {
        InitializePanel();
    }

    private void InitializePanel()
    {
        dialogueCanvasGroup = GetComponent<CanvasGroup>();
        dialogueCanvasGroup.alpha = 0f;
    }

    private void Update()
    {
        UpdateCanvasOpacity();
        PrepareForOptionDisplay();
        DisplayDialogueOptions();
    }

    private void UpdateCanvasOpacity()
    {
        dialogueCanvasGroup.alpha = Mathf.Lerp(dialogueCanvasGroup.alpha, dialogueCanvasGroup.alpha = (currentSection != null ? 1f : 0f), Time.deltaTime * canvasGroupFadeTime);
    }

    private void PrepareForOptionDisplay()
    {
        if (optionsBeenDisplayed || !(currentSection is Choices))
            return;

        ResetDisplayOptionsFlags();
    }

    public void StartDialogue(IDialogueSection start)
    {
        ClearAllOptions();
        currentSection = start;
        DisplayDialogue();
    }

    public void ProceedToNext()
    {
        if (displayingChoices)
            return;

        currentSection = currentSection?.NextSection;
        DisplayDialogue();
    }

    private void DisplayDialogue()
    {
        if (currentSection == null)
        {
            EndDialogue();
            return;
        }

        bool isMonologue = currentSection is Monologue;

        nameText.text = currentSection.SpeakerName;
        contentsText.text = currentSection.SpeechContents;

        dialogueChoiceObject.SetActive(isMonologue);
        ClearAllOptions();
    }

    private void EndDialogue()
    {
        currentSection = null;
        ClearAllOptions();
    }

    private void ClearAllOptions()
    {
        foreach (Transform child in parentChoicesTo)
        {
            Destroy(child.gameObject);
        }
    }

    private void ResetDisplayOptionsFlags()
    {
        optionsBeenDisplayed = true;
        displayingChoices = true;
        indexOfCurrentChoice = 0;
    }

    public void DisplayDialogueOptions()
    {
        if (!(currentSection is Choices choices))
        {
            return;
        }

        if (displayingChoices)
        {
            foreach (var option in choices.choices)
            {
                GameObject s = Instantiate(dialogueChoiceObject, Vector3.zero, Quaternion.identity);
                s.transform.SetParent(parentChoicesTo);
                s.GetComponent<RectTransform>().localScale = Vector3.one;

                DialogueOptionDisplay optionDisplayBehavior = s.GetComponent<DialogueOptionDisplay>();

                optionDisplayBehavior.SetDisplay(option.Item1, option.Item2);
            }

            displayingChoices = false;
        }
    }





}

