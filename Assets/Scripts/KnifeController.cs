using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeController : MonoBehaviour
{
    private KnifeManager knifeManager;
    private Rigidbody2D knifeRigidbody;
    public float moveSpeed;
    private bool canShoot;
    private GameManager gameManager;

    private void Start()
    {
        knifeRigidbody = GetComponent<Rigidbody2D>();
        knifeManager = FindObjectOfType<KnifeManager>();
        gameManager = FindObjectOfType<GameManager>();  
        moveSpeed = knifeManager.knifeMoveSpeed;
    }
    private void Update()
    {
        HandleShootInput();
    }

    private void FixedUpdate()
    {
        Shoot();
    }

    private void HandleShootInput()
    {
        if (!gameManager.isGamePaused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                knifeManager.SetDisableKnifeIconColor();

                canShoot = true;
            }
        }
       
    }
    private void Shoot()
    {
        if (canShoot)
        { 
            //knifeRigidbody.velocity = Vector2.up * moveSpeed;

            knifeRigidbody.AddForce(Vector2.up * moveSpeed * Time.fixedDeltaTime);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.CompareTag("Circle"))
        {
            knifeManager.SetActiveKnife();
            canShoot = false;
            knifeRigidbody.isKinematic = true;
            knifeRigidbody.velocity = Vector2.zero;
            knifeRigidbody.angularVelocity = 0f;
            knifeRigidbody.bodyType = RigidbodyType2D.Kinematic;
            transform.SetParent(collision.gameObject.transform);
            knifeManager.hit++;
            knifeManager.hitText.text = knifeManager.hit.ToString();
        }
        else if (collision.gameObject.CompareTag("Knife"))
        {
            //Time.timeScale = 0;
            //SceneManager.LoadScene(0);
            gameManager.GameOver();

        }
    }

}
