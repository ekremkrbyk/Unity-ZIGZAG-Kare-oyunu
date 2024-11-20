using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform cube; //K�p�n transform de�eri
    Vector3 distance; //K�p ile kamera aras�ndaki mesafe fark� 
    void Start() 
    {
        distance = transform.position - cube.position; //K�p ile kamera aras�ndaki mesafe fark�n� �l�
    }

    void Update()
    {
        if (CubeMovement.cubeisdead == false) //CubeMovement scriptindeki k�p �lmemi� ise
        {
            transform.position = cube.position + distance; //Kameran�n transform posisiona aradaki fark� ekle
        }
    }
}
