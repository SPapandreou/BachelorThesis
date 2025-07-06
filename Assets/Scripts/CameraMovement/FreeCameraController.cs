using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CameraMovement
{
    public class FreeCameraController : MonoBehaviour, FreeCameraControls.ICameraControlMapActions
    {
        public float moveSpeed;
        public float boostSpeed;
        public float mouseSensitivity;
        
        private Vector3 _moveInput = Vector3.zero;
        private Vector2 _lookInput = Vector2.zero;
        private bool _boost;

        private FreeCameraControls _controls;

        private void Awake()
        {
            _controls = new FreeCameraControls();
            _controls.CameraControlMap.AddCallbacks(this);
        }

        private void OnEnable()
        {
            _controls.CameraControlMap.Enable();
        }

        private void OnDisable()
        {
            _controls.CameraControlMap.Disable();
        }

        private void Update()
        {
            transform.position += transform.TransformDirection(_moveInput) * (_boost ?  boostSpeed : moveSpeed) * Time.deltaTime;
            
            var yaw = _lookInput.x * mouseSensitivity;
            var pitch = -_lookInput.y * mouseSensitivity;

            transform.Rotate(Vector3.up, yaw, Space.World);
            transform.Rotate(Vector3.right, pitch, Space.Self);
        }
        
        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _moveInput = context.ReadValue<Vector3>();
            }
            else if (context.canceled)
            {
                _moveInput = Vector3.zero;
            }
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _lookInput = context.ReadValue<Vector2>();
            }
            else if (context.canceled)
            {
                _lookInput = Vector2.zero;
            }
        }

        public void OnBoost(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _boost = true;
            }
            else if (context.canceled)
            {
                _boost = false;
            }
        }
    }
}