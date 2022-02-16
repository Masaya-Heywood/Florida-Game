using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoterBlockLogic : MonoBehaviour
{
    public string VoterBlockName;
    public string VoterBlockDefinition;

    [SerializeField]
    [Range(0, 1)]
    private static float policyBias, cultureBias, emotionalBias;
 

    private List<float> biases = new List<float>() { policyBias, cultureBias, emotionalBias };

    //policy where 0 is public and 1 is private intrests, 5 is good for both
    //culture where 0 is traditional and 1 is progressive 5 is good for both
    //emotional where 0 is positive and 1 is negative 5 is good for both

    //public List[] generalKeywordsList = new List;

    public float voterOverallHappiness;


    //how far is the number from the bias? use this number to influence happiness 
    //how happy are the people currently? use this number to dampen the impact of sentiment on happiness, the more happy voters are, the less they care about sentiment
    //

    float DecideHappiness(float sentiment, int typeSwitch)
    {
        // 1 == policy, 2 == culture, 3 == emotional
        float happiness = 0;

        //find the distance between .n and .n, the higher the number the worse it is
        float affinityMod = 1 * (Mathf.Abs(sentiment - biases[typeSwitch]));

        //happiness = 1 - affinity;



    return happiness;
    }

    //randomly simulate happiness changing then give it to the over all happiness
    public float MockLogic()
    {
        float happiness = Random.Range(-100,100);

        voterOverallHappiness = voterOverallHappiness + happiness;

        return voterOverallHappiness;

        Debug.Log(voterOverallHappiness);
    }
}
