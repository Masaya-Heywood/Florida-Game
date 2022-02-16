using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FeedbackManager : MonoBehaviour
{
    public GameObject happyFeedback;
    public GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        happyFeedback.GetComponent<TMP_Text>().text = manager.GetComponent<SessionManager>().totalHappiness.ToString();
    }
}
