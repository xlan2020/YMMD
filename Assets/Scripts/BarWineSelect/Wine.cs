using UnityEngine;
using System.Collections.Generic;

public class Wine
{
    public string Name { get; set; }
    public List<string> Flavors { get; set; } // 三种口味
    public List<string> Attributes { get; set; } // 六种属性

    public Wine(string name, List<string> flavors, List<string> attributes)
    {
        Name = name;
        Flavors = flavors;
        Attributes = attributes;
    }
}