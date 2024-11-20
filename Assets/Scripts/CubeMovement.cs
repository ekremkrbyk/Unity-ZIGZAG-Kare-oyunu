using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeMovement : MonoBehaviour
{
    public GameObject restartButton;
    Vector3 Rotation; //Küpün rotastyonu
    public float speed; //Küpün hýzý
    public GroundSpawner GroundSpawnerscript; //Zemin spawner scriptini çaðýrýyorum
    public static bool cubeisdead; //Küp öldümü 
    public float boost; //Oyun ilerledikçe küpün hýzýnýn ne kadar artacaðý
    void Start()
    {
        Rotation = Vector3.forward; //Küpün pozisyonunu x ekseninde -1 azaltýr (-1,0,0)
        cubeisdead = false;
        restartButton.SetActive(false);
    }


    void Update()
    {
        if(transform.position.y<0.5f) //Küp y ekseninde 0.5f aþþaðý inmiþse ölmüþ demektir
        {
            cubeisdead = true;
            restartButton.SetActive(true);
        }
        if (cubeisdead)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0)) //Týklamayý veya ekrana dokunmayý al
        {
         if(Rotation.x==0) //Eðer x ekseninde 0 a eþitise 
            {
                Rotation = Vector3.left; //Sola çevir
            }
            else //Deðilse
            {
                Rotation = Vector3.forward; //Ýleri bak
            }
            speed += boost * Time.deltaTime; //Zaman geçtikçe hýzý arttýr
        }
    }
    private void FixedUpdate()
    {
        Vector3 Movement = Rotation * speed * Time.deltaTime; //Küpün ileri gitmesini hesaplýyor
        transform.position += Movement; //Küp ileri gidiyor
    }
    private void OnCollisionExit(Collision collision) //Eðer küpün zemin ile temasý bitti ise
    {
        if (collision.gameObject.tag == "ground")
        {
            GameManager.score++; //GameManager scriptindeki scoreyi arttýr 
            collision.gameObject.AddComponent<Rigidbody>(); //Küplere rigitbody ver ki küpler düþsün 
            GroundSpawnerscript.groundSpawn(); //Yeni küp spawn et
            StartCoroutine(grounddelete(collision.gameObject)); //Eski küpleri sil i çalýþtýr
        }
    }

    IEnumerator grounddelete(GameObject grounddsty) //Eski küpleri si
    {
        yield return new WaitForSeconds(3f); //3sn bekle
        Destroy(grounddsty); //Küpü yok et
    }

    public void RestartGame() // Oyunu yeniden baþlatma fonksiyonu
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Mevcut sahneyi yeniden yükle
    }
}
