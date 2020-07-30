using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bebaSpace
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float smoothSpeed = 0.15f;

        private Vector3 offset;
        private Transform target;

        void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            offset = transform.position - target.position;
        }

        void LateUpdate()
        {
            Vector3 newPosition = target.position + offset;

            transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed);
        }
    }
}
