using System.Collections.Generic; 
using UnityEngine;


public class Gravity : MonoBehaviour

{
    Rigidbody rb;
    const float G = 0.00674f;

    public static List<Gravity> otherObjectslist;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (otherObjectslist == null)
        {
            otherObjectslist = new List<Gravity> ();
        }

        otherObjectslist.Add(this);
    }

    private void FixedUpdate()
    {
        foreach (Gravity obj in otherObjectslist)
        {
            if (obj != this)
            {
                Attract(obj);
            }
        
        }

    }

    private void Attrct (Gravity other)
    {
       Rigidbody otherRB = other.rb;

        Vector3 direction = rb.position - otherRB.position;

        float distance = direction.magnitude;

        if (distance < 0f) { return;

    }

       float forceMagnitude = G * (rb.mass * otherRB.mass) / Mathf.Pow(distance, 2);

        Vector3 gravityForce = forceMagnitude * direction.normalized;

        otherRB.AddForce(gravityForce);


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
