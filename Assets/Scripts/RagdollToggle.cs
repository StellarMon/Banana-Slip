using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RagdollToggle : MonoBehaviour
{

    Collider[] colliders;
    Rigidbody[] rigis;

    public float upForce;
    public float outForce;

    // Start is called before the first frame update
    void Start()
    {
        colliders = GetComponentsInChildren<Collider>().Where(collider => collider.gameObject != gameObject).ToArray(); //Don't get the collider on this OBJ
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
        /*if(Input.GetMouseButtonDown(1))
        {
            ToggleRagdollOn();
            
        }*/
    }

    public void ToggleRagdollOn()
    {
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }
        foreach (Rigidbody rigidbody in rigis)
        {
            rigidbody.isKinematic = false;
        }

        Invoke(nameof(ApplySlipForceToLegs), 1f);
    }



    private void ApplySlipForceToLegs()
    {
        Debug.Log("LAUNCH");
        Rigidbody[] legRigbodies = GameObject.FindGameObjectsWithTag("Legs")
                                      .Select(go => go.GetComponent<Rigidbody>())
                                      .Where(rb => rb != null)
                                      .ToArray();

       
        foreach (Rigidbody legRigidbody in legRigbodies)
        {
            Vector3 outwardForce = legRigidbody.transform.forward * outForce;
            Vector3 upwardForce = Vector3.up * upForce;

            legRigidbody.AddForce(outwardForce + upwardForce, ForceMode.Force);
        }


    }

    public void ToggleRagdollOff()
    {
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
        foreach (Rigidbody rigidbody in rigis)
        {
            rigidbody.isKinematic = true;
        }
    }
}
