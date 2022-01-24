using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Structure of a dialogue box - name and dialogue to be said
 */

[System.Serializable]
public class Dialogue {

    // Stores the NPC name
    public string[] names;

    // Stores words in a sentence;
    [TextArea(3, 10)] // Size of text area box
    public string[] sentences;
}
