using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class SessionManager : MonoBehaviour
{
    public static SessionManager Instance { get; private set; }
    public GeneralKeywordsList generalKeywordList;
    private List<string> availibleKeywords = new List<string>();
    public GameObject[] voterBlocks;

    //public int inputText;
    public int floridaStatus;
    public static float policySentiment, cultureSentiment, emotionalSentiment;
    public float totalHappiness;

    //Dictionary<float, int> sentiments = new Dictionary<float, int>()
    //{
    //    {policySentiment, 1},
    //    {cultureSentiment, 2},
    //    {emotionalSentiment, 3}
    //};

    //private List<float> sentiments = new List<float>{ policySentiment, cultureSentiment, emotionalSentiment };

    //policy where 0 is public and 1 is private intrests
    //culture where 0 is traditional and 1 is progressive
    //emotional where 0 is positive and 1 is negative

    public GameObject billInput;
    public NLPTokenizer tokenizer;

    //make sure this is the only active version of the script
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    void Start()
    {

        //to find each keyword fom the general keywords list
        foreach (KeywordScriptObject keyword in generalKeywordList.array)
        {
            availibleKeywords.Add(keyword.keywordName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecieveText()
    {
        tokenizer.sentence = billInput.GetComponent<TMP_InputField>().text;
        CalculateSentiment(tokenizer.Tokenize());
    }

    //need to create a model that reads a sentence and decides the sentiments of the sentence, then passes the sentiment to the voters
    public void CalculateSentiment(string[] inputTokens)
    {
        var listOfHits = inputTokens.Except(availibleKeywords).ToList();

        foreach (string word in listOfHits)
        {
            Debug.Log(word);
        }
    }

    public void MockBehavior()
    {
        foreach (GameObject voters in voterBlocks)
        {
            for (int i = 0; i < 3; i++)
            {
                float randSentiment = Random.Range(.0f, 1.0f);
                //Debug.Log(randSentiment);
                Debug.Log(voters.GetComponent<VoterBlockLogic>().DecideHappiness(randSentiment, i));
            }
        }
    }

    // for each sentiment in sentiments, do DecideHappiness in for each voter block, then add up the total happiness for all floridians
    //public void MockBehavior()
    //{
    //    var voterBlockHappinessList = new List<float> { };

    //    foreach (GameObject voters in voterBlocks)
    //    {
    //        for(int i = 0; i < 4; i++)
    //        {
    //            voters.GetComponent<VoterBlockLogic>().MockLogic();
    //        }

    //        //voterBlockHappinessList.Add(voters.GetComponent<VoterBlockLogic>().voterOverallHappiness);

    //        //foreach (KeyValuePair<float, int> sentiment in sentiments)
    //        //{

    //        //}
    //    }

    //    totalHappiness = voterBlockHappinessList.Sum();

    //    if (hate == true)
    //    {
    //        totalHappiness = totalHappiness - Random.Range(-10,50);
    //    }

    //    hate = true;
    //}
}


//interface ISampleInterface
//{
//    void SampleMethod();
//}

//class KeywordComparer : IEqualityComparer<KeywordScriptObject>
//{
//    public bool Equals(Customer x, Customer y)
//    {
//        bool result = x.ID == y.ID;
//        return result;
//    }
//    public int GetHashCode(Customer obj)
//    {
//        return obj.ID.GetHashCode();
//    }
//}
