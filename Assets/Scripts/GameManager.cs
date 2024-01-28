using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
   public List<GameObject> NPCs;

    private void Start()
    {
       NPCs = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        if(NPCs.Count <= 0 )
        {
            SceneManager.LoadScene("Title");
        }
    }
}
