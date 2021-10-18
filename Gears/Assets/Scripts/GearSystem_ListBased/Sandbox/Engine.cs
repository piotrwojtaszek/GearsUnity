using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Engine : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float force = 1500f;
    private void Awake() => rb = GetComponent<Rigidbody>();

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Vertical");

        rb.AddTorque(Vector3.forward * input * Time.deltaTime * force);
    }
}
