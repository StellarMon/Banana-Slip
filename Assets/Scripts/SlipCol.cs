using SolarStudios;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipCol : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<StateMachine>().SetState(other.gameObject.GetComponent<SlipState>());
            Debug.Log("Slipped!");
        }
        
    }
}
