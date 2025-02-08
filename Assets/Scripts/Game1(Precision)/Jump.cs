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
    private Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
        animator.SetBool("isJumping", true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hazzard"))
        {
            collision.gameObject.SetActive(false);
            PanelManager.Instance.GameOver();
            //Pierde
            //SceneManager.LoadScene("ClickPrecision");
        }
    }
}
