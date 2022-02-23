using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoterBlockLogic : MonoBehaviour
{
    public string VoterBlockName;
    public string VoterBlockDefinition;

    [Range(0, 1)]
    [SerializeField]
    [Tooltip("Policy where 0 is for public intrests and 1 is private intrests. \nCulture where 0 is traditional and 1 is progressive. \nEmotional where 0 is positive and 1 is negative.")]
    private float policyBias, cultureBias, emotionalBias;
    //policy where 0 is public and 1 is private intrests
    //culture where 0 is traditional and 1 is progressive
    //emotional where 0 is positive and 1 is negative

    [Range(1, 100)]
    [SerializeField]
    [Tooltip("Radicalization is from 1 to 100, where 0 ambvalent and 100 is max extremism. Moving around ~20 will give a positive values up to 2 tenths away from the bias.")]
    private int radicalizationProperty;
    //radicalization is from 1 to 100, where 0 is nothing and 100 is max extremism

    private float happinessGainCap = 100.0f; //determines the soft cap on where players can gain happiness from DecideHappiness, base is 100
    private int happinessMax = 1000;
    private int happinessMin = -1000;
    private int dampenMax = 120;
    private int dampenMin = 75;
    private int dampenMod = 0; //Gives a flat increase or decrease the amount of dampening

    private List<float> biases;

    //don't interact with the happinesss directly, use the input variable
    private int voterOverallHappinessProperty = 500;

    //handles keeping the voter happiness to a maximum of 1000 and a minimum of -1000, dampens the impact of changing happiness based upon how happy the voterbase currently is
    public float voterOverallHappiness
    {
        get
        {
            return voterOverallHappinessProperty;
        }
        set
        {
            /*Imports a value. Clamps that value down to above or below -happinessGainCap or happinessGainCap. Finds the percentage the current happiness is at, then 
            increases or decreases the happiness gain (importedValue) by that amount.
            */

            var importedValue = Mathf.Clamp(Mathf.RoundToInt(value), -(happinessGainCap), happinessGainCap);

            //var percentageAmount = Mathf.Clamp(((Mathf.InverseLerp(happinessMax, happinessMin, voterOverallHappinessProperty) * 100) + dampenMod), dampenMin, dampenMax);

            var percentageAmount = ((Mathf.InverseLerp(happinessMax, happinessMin, voterOverallHappinessProperty) * 100) + dampenMod);

            var dampenedValue = (importedValue / 100) * percentageAmount;

            voterOverallHappinessProperty += Mathf.RoundToInt(dampenedValue);

            voterOverallHappinessProperty = Mathf.Clamp(voterOverallHappinessProperty, happinessMin, happinessMax);

            Debug.Log($"Dampening {value} to {percentageAmount}% for a value of {dampenedValue}");
        }
    }

    public int radicalization
    {
        get
        {
            return radicalizationProperty;
        }
        set
        {
            radicalizationProperty = value * 100;
        }
    }

    private void Start()
    {
        biases = new List<float>() { policyBias, cultureBias, emotionalBias };
        radicalizationProperty = radicalizationProperty * 100;
    }

    private void Update()
    {
        //radicalizationProperty = radicalizationProperty * 100; //use only for testing of radicalization
    }



    //how far is the number from the bias? use this number to influence happiness 
    //how happy are the people currently? use this number to dampen the impact of sentiment on happiness, the more happy voters are, the less they care about sentiment
    //Each time DecideHappiness is called, it returns the calculation for the specific bias AND actively modifies the voter's current overall happiness.
    public float DecideHappiness(float sentiment, int typeSwitch)
    {
        // 0 == policy, 1 == culture, 2 == emotional
        Vector2 parabolicVertex = new Vector2 (biases[typeSwitch], Mathf.RoundToInt(happinessGainCap));
        //find the distance between .n and .n, the higher the number the worse it is
        var affinityMod = (Mathf.Abs(sentiment - biases[typeSwitch]));

        float testReturns = MathFunctions.VoterParabola(parabolicVertex, radicalization, sentiment);

        voterOverallHappiness = testReturns;


        //happiness = 1 - affinity;

        if (affinityMod < .5)
        {
            Debug.Log($"As a {VoterBlockName}, I shouldn't be happy {testReturns} change. Bias: {biases[typeSwitch]}, Senti: {sentiment}, Affinity: {affinityMod}, Total Happy: {voterOverallHappiness}");
        } else if (affinityMod > .5)
        {
            Debug.Log($"As a {VoterBlockName}, I should be happy with {testReturns} change.  Bias: {biases[typeSwitch]}, Senti: {sentiment}, Affinity: {affinityMod}, Total Happy: {voterOverallHappiness}");
        }

        return testReturns;
    }

    //randomly simulate happiness changing then give it to the over all happiness
    public float MockLogic()
    {
        float happiness = Random.Range(-100,100);

        voterOverallHappiness = voterOverallHappiness + happiness;

        return voterOverallHappiness;
    }

}
