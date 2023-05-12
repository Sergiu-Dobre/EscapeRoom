using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class Dialogue : MonoBehaviour
{
    public interface DialogueSection
    {
        string GetSpeakerName();
        string GetSpeechContents();
        DialogueSection GetNextSection();
    }

    public class Monologue : DialogueSection
    {
        public string speaker_name;
        public string contents;
        public DialogueSection next;

        public Monologue(
            string speaker_Name = "AI",
            string contents = "There's nothing now.",
            DialogueSection next = null)
        {
            this.speaker_name = speaker_name;
            this.contents = contents;
            this.next = next;
        }

        public DialogueSection GetNextSection()
        {
            return next;
        }

        public string GetSpeakerName()
        {
            return speaker_name;
        }

        public string GetSpeechContents()
        {
            return contents;
        }
    }

    public class Choices : DialogueSection
    {
        public string speaker_name;
        public string contents;
        public List<Tuple<string, DialogueSection>> choices;

        public Choices(
            string speaker_name = "AI",
            string contents = "There is nothing here...Choose",
            List<Tuple<string, DialogueSection>> choices = null)
        {
            this.speaker_name = speaker_name;
            this.contents = contents;
            this.choices = choices;
        }

        public string GetSpeakerName()
        {
            return speaker_name;
        }

        public string GetSpeechContents()
        {
            return contents;
        }

        public DialogueSection GetNextSection()
        {
            return null;
        }
    }

    public static Tuple<string, DialogueSection> Choice(string choice, DialogueSection next)
    {
        return new Tuple<string, DialogueSection>(choice, next);
    }

    public static List<Tuple<string, DialogueSection>> ChoiceList(params Tuple<string, DialogueSection>[] entries)
    {
        List<Tuple<string, DialogueSection>> result = new List<Tuple<string, DialogueSection>>();

        foreach (var entry in entries)
        {
            result.Add(entry);
        }

        return result;
    }
}
