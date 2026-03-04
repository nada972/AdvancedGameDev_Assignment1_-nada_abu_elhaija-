using UnityEngine;

public class Colliion : MonoBehaviour
{
     public int totalIce = 5;
    private int currentIce = 0;
    [SerializeField] GameObject win ;

    void Start()
    {
        win.gameObject.SetActive(false);
    }

    bool hasPackage;
    //void OnCollisionEnter2D(Collision2D other)
    //{
      //  Debug.Log("mmm");
    //}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage )
        {
            
            //Debug.Log("Aaa");
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject);
        }  

        if (collision.CompareTag("custmare") && hasPackage)
        {
            currentIce ++;
            //Debug.Log("mmm");
            hasPackage =false;
            GetComponent<ParticleSystem>().Stop();
            Destroy(collision.gameObject);
            if (currentIce == totalIce )
            {
                Debug.Log("mmm");
                win.gameObject.SetActive(true);
                Destroy(gameObject);
            }
        } 
    }
}
