using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrostyPlayerSystem
{
    public class CameraMovementHandler : MonoBehaviour, ICameraHandler
    {


        public Transform lookAt => _Player.transform;

        private PlayerMaster _Player;

        private float currentX = 0.0f;
        private float currentY = 0.0f;

        private void Awake()
        {
            _Player = GetComponent<PlayerMaster>();
        }

        void LateUpdate()
        {

            currentX += _Player._inputHandler._camAxis.x * _Player._masterSettings.SensitivityX * Time.deltaTime;
            currentY += _Player._inputHandler._camAxis.y * _Player._masterSettings.SensitivityY * Time.deltaTime;

            currentY = Mathf.Clamp(currentY, _Player._masterSettings.YClampMin, _Player._masterSettings.YClampMax);

            Vector3 Direction = new Vector3(0, 0, _Player._masterSettings.distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            _Player._Camera.transform.position = lookAt.transform.position + rotation * Direction;

            _Player._Camera.transform.LookAt(lookAt.position);

        }
    }
}