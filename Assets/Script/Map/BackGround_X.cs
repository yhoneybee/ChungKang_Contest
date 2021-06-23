using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_X : MonoBehaviour
{
    // Start is called before the first frame update
        public Vector3 movementScale = Vector3.one;

        public Transform _camera;

        void Awake()
        {
            _camera = Camera.main.transform;
        }

        void LateUpdate()
        {
            transform.position = Vector3.Scale(_camera.position, new Vector3(movementScale.x, movementScale.y, transform.position.z));
        }
}
