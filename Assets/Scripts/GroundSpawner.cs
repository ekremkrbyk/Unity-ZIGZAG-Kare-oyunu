using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject lastGround; //Eski küp

    private void Start()
    {
        for (int i = 0; i < 70; i++) //Baþlangýçta kaç tane küp spawn olacaðýný belirleyen sayaç
        {
            groundSpawn(); //Küp spawnla
            i++;
        }
    }
    void Update()
    {

    }
    public void groundSpawn() //Zemin Spawnlama fonksiyonu
    {
        Vector3 rot;
        if(Random.Range(0,2)==0)//0 ve 1 aralýðýnda sayý seç eðer 0 ise
        {
            rot = Vector3.left; //Sola spawn et
        }
        else
        {
            rot = Vector3.forward; //Deðilse saða spawn et
        }
        lastGround = Instantiate(lastGround, lastGround.transform.position + rot, lastGround.transform.rotation);  //birden fazla obje spawn etmesi için gerekli komut
    }
}
