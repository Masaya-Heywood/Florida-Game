using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoterBlockLogic : MonoBehaviour
{
    public string VoterBlockName;
    public string VoterBlockDefinition;

    [Range(0,1)]
    [SerializeField]
    private float policyBias, cultureBias, emotionalBias, radicalization;
    //[/SerializeField]
    //policy where 0 is public and 1 is private intrests
    //culture where 0 is traditional and 1 is progressive
    //emotional where 0 is positive and 1 is negative

    private float happinessGainCap = 100.0f; //determines the hard cap on where players can gain happiness from DecideHappiness, base is 100

    private List<float> biases;

    private void Start()
    {
        biases = new List<float>() { policyBias, cultureBias, emotionalBias };
    }

    //don't interact with the happinesss directly, use the input variable
    private int voterOverallHappinessProperty;
    //handles keeping the voter happiness to a maximum of 1000 and a minimum of -1000, dampens the impact of changing happiness based upon how happy the base currently is
    public float voterOverallHappiness
    {
        get 
        { 
            return voterOverallHappinessProperty; 
        }   
        set 
        {
            voterOverallHappinessProperty = Mathf.RoundToInt(value); 
        }  
    }



    //how far is the number from the bias? use this number to influence happiness 
    //how happy are the people currently? use this number to dampen the impact of sentiment on happiness, the more happy voters are, the less they care about sentiment
    public float DecideHappiness(float sentiment, int typeSwitch)
    {
        // 0 == policy, 1 == culture, 2 == emotional
        Vector2 parabolicVertex = new Vector2 (Mathf.RoundToInt(happinessGainCap), biases[typeSwitch]);
        //find the distance between .n and .n, the higher the number the worse it is
        float affinityMod = (Mathf.Abs(sentiment - biases[typeSwitch]));
        voterOverallHappiness = MathFunctions.VoterParabola(parabolicVertex, 2.0f);



        //happiness = 1 - affinity;



        return voterOverallHappiness;
    }

    //randomly simulate happiness changing then give it to the over all happiness
    public float MockLogic()
    {
        float happiness = Random.Range(-100,100);

        voterOverallHappiness = voterOverallHappiness + happiness;

        return voterOverallHappiness;
    }

}
