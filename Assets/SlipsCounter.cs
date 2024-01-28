using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipsCounter : MonoBehaviour
{
    public ScoreManager scoreManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            scoreManager.scoreCount += 1;
        }
    }
}
