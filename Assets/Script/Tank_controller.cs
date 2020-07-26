using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankDemo {
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Tank_inputs))]
    public class Tank_controller : MonoBehaviour
    {
        public float tankSpeed = 15f;
        public float tankRotationSpeed = 20f;


        private Rigidbody rb;
        private Tank_inputs inputs;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            inputs = GetComponent<Tank_inputs>();

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (rb && inputs)
            {
                HandelMovement();


            }
        }
        protected virtual void HandelMovement()
        { // move tank forword
            Vector3 wantedPosition = transform.position + (transform.forward * tankSpeed * Time.deltaTime);
            rb.MovePosition(wantedPosition);

            // rotation
            Quaternion wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * (tankRotationSpeed * inputs.RotationInput * Time.deltaTime));
            rb.MoveRotation(wantedRotation);
        }
    }
}