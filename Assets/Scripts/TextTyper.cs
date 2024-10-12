using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTyper : MonoBehaviour
{
    private Text textBox;
    public Coroutine typingLinesCoroutine;
    [TextArea()] public string text;
    public float typingSpeed = 0.1f;
    public AudioSource typeSound;

    void Awake()
    {
        textBox = GetComponent<Text>();
    }

    void Start()
    {
        textBox.text = "";
    }

    public void StartTyping()
    {
        typingLinesCoroutine = StartCoroutine(typingLines(this.text));
    }

    public void StopTyping()
    {
        if (typingLinesCoroutine != null)
        {
            StopCoroutine(typingLinesCoroutine);
            typeSound.Stop();
        }
    }

    public void StartTypingLine(string line)
    {
        typingLinesCoroutine = StartCoroutine(typingLines(line));
    }

    private IEnumerator typingLines(string line)
    {
        textBox.text = "";

        // play sound
        typeSound.loop = false;


        yield return new WaitForSeconds(0.04f);

        // start typing effect
        foreach (char letter in line.ToCharArray())
        {
            textBox.text += letter;
            typeSound.Play();
            yield return new WaitForSeconds(typingSpeed);
        }

    }


}
