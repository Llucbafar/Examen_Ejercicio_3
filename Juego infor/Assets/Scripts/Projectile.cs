using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Speed_Disparo;

    private Vector2 MousePosition, ObjetoPosicion;
    private Vector3 positionpasada;

 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * Speed_Disparo;
        positionpasada = transform.position;
    }
 
    // Update is called once per frame
    void Update()
    {
        if(positionpasada != transform.position){
            transform.right = transform.position - positionpasada;
            positionpasada = transform.position;
        }
    }
}