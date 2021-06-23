using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
   public Vector3 movementScale = Vector3.one;

        public Transform _camera;

        void Awake()
        {
            _camera = Camera.main.transform;
        }

        void LateUpdate()
        {
            transform.position = Vector3.Scale(_camera.position, new Vector3(movementScale.x, transform.position.y, transform.position.z));
        }
}
