using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.IO;

public class DialogueVariables
{
    public Dictionary<string, Ink.Runtime.Object> variables { get; private set; }


    public DialogueVariables(string globalFilePath)
    {
        string inkFileContents = File.ReadAllText(globalFilePath);
        Ink.Compiler compiler = new Ink.Compiler(inkFileContents);
        Story globalVariblesStory = compiler.Compile();

        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in globalVariblesStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariblesStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            Debug.Log("initialize global dialogue variable: " + name + "=" + value);
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
}
