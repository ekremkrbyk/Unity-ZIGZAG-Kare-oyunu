using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject lastGround; //Eski k�p

    private void Start()
    {
        for (int i = 0; i < 70; i++) //Ba�lang��ta ka� tane k�p spawn olaca��n� belirleyen saya�
        {
            groundSpawn(); //K�p spawnla
            i++;
        }
    }
    void Update()
    {

    }
    public void groundSpawn() //Zemin Spawnlama fonksiyonu
    {
        Vector3 rot;
        if(Random.Range(0,2)==0)//0 ve 1 aral���nda say� se� e�er 0 ise
        {
            rot = Vector3.left; //Sola spawn et
        }
        else
        {
            rot = Vector3.forward; //De�ilse sa�a spawn et
        }
        lastGround = Instantiate(lastGround, lastGround.transform.position + rot, lastGround.transform.rotation);  //birden fazla obje spawn etmesi i�in gerekli komut
    }
}
