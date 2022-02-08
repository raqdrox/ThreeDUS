using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
namespace FrostyScripts.PlayerSystem
{
    public class CameraMovementHandler : NetworkBehaviour
    {
        Vector3 Angles;

        private PlayerMaster _Player;
        public Camera _Camera;

        private void Awake()
        {
            _Player = GetComponent<PlayerMaster>();
            _Camera = Camera.main;
        }

        [Client]
        void Update()
        {
            if (!isLocalPlayer)
                return;
            if(_Player.CanLook)
                UpdateCamPosition();
        }

        private void UpdateCamPosition()
        {
            #region old
            /*
            currentX += _Player._inputHandler._camAxis.x * _Player._masterSettings.SensitivityX * Time.deltaTime;
            currentY += _Player._inputHandler._camAxis.y * _Player._masterSettings.SensitivityY * Time.deltaTime;
            
            currentY = Mathf.Clamp(currentY, _Player._masterSettings.YClampMin, _Player._masterSettings.YClampMax);

            Vector3 Direction = new Vector3(0, 0, _Player._masterSettings.distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            _Player._Camera.transform.position = lookAt.transform.position + rotation * Direction;

            _Player._Camera.transform.LookAt(lookAt.position);
            */
            #endregion
            //float rotationY = Input.GetAxis("Mouse Y") * _Player._masterSettings.SensitivityX;
            //float rotationX = Input.GetAxis("Mouse X") * _Player._masterSettings.SensitivityY;
            float rotationY = _Player._inputHandler.i_Cam.y * _Player._masterSettings.SensitivityX;
            float rotationX = _Player._inputHandler.i_Cam.x * _Player._masterSettings.SensitivityY;
            if (rotationY > 0)
                Angles = new Vector3(Mathf.MoveTowards(Angles.x, -80, rotationY), Angles.y + rotationX, 0);
            else
                Angles = new Vector3(Mathf.MoveTowards(Angles.x, 80, -rotationY), Angles.y + rotationX, 0);
            //_Player.gameObject.transform.localEulerAngles = new Vector3(Angles.x, _Player.gameObject.transform.localEulerAngles.y, _Player.gameObject.transform.localEulerAngles.z);
            //_Player._Camera.localEulerAngles = new Vector3(_Player._Camera.localEulerAngles.x, Angles.y, _Player._Camera.localEulerAngles.z);
            _Camera.transform.localEulerAngles = Angles;
            _Camera.transform.position = _Player._CameraPos.position;
        }

    }
}