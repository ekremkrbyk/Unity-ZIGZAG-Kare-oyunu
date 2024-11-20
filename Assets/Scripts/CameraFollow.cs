using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform cube; //Küpün transform deðeri
    Vector3 distance; //Küp ile kamera arasýndaki mesafe farký 
    void Start() 
    {
        distance = transform.position - cube.position; //Küp ile kamera arasýndaki mesafe farkýný ölç
    }

    void Update()
    {
        if (CubeMovement.cubeisdead == false) //CubeMovement scriptindeki küp ölmemiþ ise
        {
            transform.position = cube.position + distance; //Kameranýn transform posisiona aradaki farký ekle
        }
    }
}
