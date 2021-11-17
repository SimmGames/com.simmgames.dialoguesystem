using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using DialogueSystem;
using System.Reflection;

namespace DialogueSystem.Code
{
    public class DialogueCode 
    {
        protected Dictionary<string, IDialogueCode.EventDelegate> eventFunctions = new Dictionary<string, IDialogueCode.EventDelegate>();
        protected Dictionary<string, IDialogueCode.ConditionDelegate> conditionChecks = new Dictionary<string, IDialogueCode.ConditionDelegate>();
        protected Dictionary<string, IDialogueCode.ConditionDelegate> dialogueChecks = new Dictionary<string, IDialogueCode.ConditionDelegate>();
        public Dictionary<string, IDialogueCode.EventDelegate> EventFunctions => eventFunctions;
        public Dictionary<string, IDialogueCode.ConditionDelegate> ConditionChecks => conditionChecks;
        public Dictionary<string, IDialogueCode.ConditionDelegate> DialogueChecks => dialogueChecks;
        public string GetVariable(string variableName)
        {
            Type type = this.GetType();
            FieldInfo field = type.GetField(variableName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (field != null) 
            {
                try
                {
                    return field.GetValue(this).ToString();
                }
                catch 
                {
                    return string.Empty;
                }
            }
            PropertyInfo property = type.GetProperty(variableName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (property != null) 
            {
                try
                {
                    return property.GetValue(this).ToString();
                }
                catch
                {
                    return string.Empty;
                }
            }
            MethodInfo method = type.GetMethod(variableName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (method != null) 
            {
                try
                {
                    string value = method.Invoke(this, null).ToString();
                    if (string.IsNullOrEmpty(value))
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return value;
                    }
                }
                catch 
                {
                    return string.Empty;
                }
            }
            return string.Empty;
        }
    }
}