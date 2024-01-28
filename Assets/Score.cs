using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
     private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PEDS")
        {
            if (scoreManager != null)
            {
                scoreManager.scoreCount += 1;
            }
            else
            {
                Debug.LogError("The ScoreBoard Manager is Not Assigned!");
            }
            
        }
    }   
}
