using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TPSController : MonoBehaviour

{   
    [SerializeField] CinemachineVirtualCamera _aimCam;  
    [SerializeField] LayerMask _aimColliderLayerMask = new LayerMask();
    [SerializeField] Transform _debugTransform;

    private void Start()
    {
        
    }
    private void Update()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, _aimColliderLayerMask)) 
        {
           _debugTransform.position = raycastHit.point;
        }
    }
}
