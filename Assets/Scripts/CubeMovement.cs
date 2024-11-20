using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeMovement : MonoBehaviour
{
    public GameObject restartButton;
    Vector3 Rotation; //K�p�n rotastyonu
    public float speed; //K�p�n h�z�
    public GroundSpawner GroundSpawnerscript; //Zemin spawner scriptini �a��r�yorum
    public static bool cubeisdead; //K�p �ld�m� 
    public float boost; //Oyun ilerledik�e k�p�n h�z�n�n ne kadar artaca��
    void Start()
    {
        Rotation = Vector3.forward; //K�p�n pozisyonunu x ekseninde -1 azalt�r (-1,0,0)
        cubeisdead = false;
        restartButton.SetActive(false);
    }


    void Update()
    {
        if(transform.position.y<0.5f) //K�p y ekseninde 0.5f a��a�� inmi�se �lm�� demektir
        {
            cubeisdead = true;
            restartButton.SetActive(true);
        }
        if (cubeisdead)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0)) //T�klamay� veya ekrana dokunmay� al
        {
         if(Rotation.x==0) //E�er x ekseninde 0 a e�itise 
            {
                Rotation = Vector3.left; //Sola �evir
            }
            else //De�ilse
            {
                Rotation = Vector3.forward; //�leri bak
            }
            speed += boost * Time.deltaTime; //Zaman ge�tik�e h�z� artt�r
        }
    }
    private void FixedUpdate()
    {
        Vector3 Movement = Rotation * speed * Time.deltaTime; //K�p�n ileri gitmesini hesapl�yor
        transform.position += Movement; //K�p ileri gidiyor
    }
    private void OnCollisionExit(Collision collision) //E�er k�p�n zemin ile temas� bitti ise
    {
        if (collision.gameObject.tag == "ground")
        {
            GameManager.score++; //GameManager scriptindeki scoreyi artt�r 
            collision.gameObject.AddComponent<Rigidbody>(); //K�plere rigitbody ver ki k�pler d��s�n 
            GroundSpawnerscript.groundSpawn(); //Yeni k�p spawn et
            StartCoroutine(grounddelete(collision.gameObject)); //Eski k�pleri sil i �al��t�r
        }
    }

    IEnumerator grounddelete(GameObject grounddsty) //Eski k�pleri si
    {
        yield return new WaitForSeconds(3f); //3sn bekle
        Destroy(grounddsty); //K�p� yok et
    }

    public void RestartGame() // Oyunu yeniden ba�latma fonksiyonu
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Mevcut sahneyi yeniden y�kle
    }
}
