using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.IO;

public class DialogueVariables
{
    public Dictionary<string, Ink.Runtime.Object> variables { get; private set; }
    private Story globalVariablesStory;

    public DialogueVariables(TextAsset loadGlobalsJSON)
    {
        // create the story
        globalVariablesStory = new Story(loadGlobalsJSON.text);

        // initialize the dictionary
        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in globalVariablesStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            Debug.Log("Initialized global dialogue variable: " + name + " = " + value);
        }
    }

    public void StartListening(Story story)
    {
        variablesToStory(story);
        story.variablesState.variableChangedEvent += variableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= variableChanged;

    }

    private void variableChanged(string name, Ink.Runtime.Object value)
    {
        if (variables.ContainsKey(name))
        {
            variables.Remove(name);
            variables.Add(name, value);
        }
    }

    private void variablesToStory(Story story)
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }

    public static bool TrySetInkStoryVariable(Story story, string variable, object value, bool log = true)
    {
        if (story != null)
        {
            if (!story.variablesState.GlobalVariableExistsWithName(variable))
            {
                if (log)
                {
                    Debug.Log($"[Ink] Try to set variable, but variable name {variable} does not exist!");
                }
                return false;
            }
            if (log)
            {
                Debug.Log($"[Ink] Set variable: {variable} = {value}");
            }

            story.variablesState[variable] = value;

            return true;
        }

        return false;
    }

    public void SetGlobalVariable(string variableName, object value)
    {
        StartListening(globalVariablesStory);
        TrySetInkStoryVariable(globalVariablesStory, variableName, value, true);
        StopListening(globalVariablesStory);
    }
}
