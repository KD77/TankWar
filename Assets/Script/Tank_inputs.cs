using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TankDemo
{
    public class Tank_inputs : MonoBehaviour
    {
        [Header("Input Properties")]
        public Camera camera;

        // properties
        private Vector3 reticlePositon;
        public Vector3 ReticlePosition
        {
            get { return reticlePositon; }

        }

        private Vector3 reticleNormal;
        public Vector3 ReticleNormal
        {
            get { return reticleNormal;  }
        }
        // Update is called once per frame
        void Update()
        {
            if (camera)
            {
                HandelInputs();

            }

        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(reticlePositon, 0.5f);
            
        }
        protected virtual void HandelInputs()
        {
            Ray screenRay = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if( Physics.Raycast(screenRay,out hit))
            {
                reticlePositon = hit.point;
                reticleNormal = hit.normal;
            }
        }
    }
}