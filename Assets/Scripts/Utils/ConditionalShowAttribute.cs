using System;
using UnityEngine;

// Original version of the ConditionalHideAttribute created by Brecht Lecluyse (www.brechtos.com)

[AttributeUsage(AttributeTargets.Field)]
public class ConditionalShowAttribute : PropertyAttribute
{
    public readonly string ConditionalSourceField;
    public string ConditionalSourceField2 = "";
    public bool HideInInspector = false;
    public bool Inverse = false;

    // Use this for initialization
    public ConditionalShowAttribute(string conditionalSourceField)
    {
        ConditionalSourceField = conditionalSourceField;
    }
}