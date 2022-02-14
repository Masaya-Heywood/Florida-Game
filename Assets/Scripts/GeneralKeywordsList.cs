using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//contains all of the keywords
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GeneralKeywordsList", order = 1)]
public class GeneralKeywordsList : ScriptableObject
{
    public KeywordScriptObject[] list;
}
