using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Jump : MonoBehaviour
{
    public float jumpForce; 
    public bool isGrounded = false; 
    private Rigidbody2D rb;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            PlayerJump();
        }
    }

    void PlayerJump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;

        Sequence s = DOTween.Sequence();
        s.Append(transform.DOScale(2, 1)).Append(transform.DOScale(1, 1));
        //s.Append(transform.DORotate(Vector3.right*100,200).SetLoops(2));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hazzard"))
        {
            collision.gameObject.SetActive(false);
            SceneManager.LoadScene("ClickPrecision");
        }
    }
}
