using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollToggle : MonoBehaviour
{

    Collider[] colliders;
    Rigidbody[] rigis;
   
    // Start is called before the first frame update
    void Start()
    {
        colliders = GetComponentsInChildren<Collider>();
        rigis = GetComponentsInChildren<Rigidbody>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
        foreach (Rigidbody rigidbody in rigis)
        {
            rigidbody.isKinematic = true;
        }
        
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ToggleRagdoll();
        }
    }

    public void ToggleRagdoll()
    {
        

        foreach (Collider collider in colliders)
        {
            collider.enabled = !collider.enabled;
        }
        foreach (Rigidbody rigidbody in rigis)
        {
            rigidbody.isKinematic = !rigidbody.isKinematic;
        }
    }
}
