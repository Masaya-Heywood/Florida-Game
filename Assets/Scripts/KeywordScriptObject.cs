using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/KeywordScriptableObject", order = 1)]
public class KeywordScriptObject : ScriptableObject
{
    public string keywordName;
    public string keywordDesc;

    [Range(0, 1)]
    public float policyBias, cultureBias, emotionalBias;
}

