using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class Target : MonoBehaviour
{
    public float timer;
    public float timeMax;
    public float score;

    public GameObject victoryPanel;
    public VisualEffect particles;
    public SpriteRenderer spriteRenderer;
    public AudioSource bubble;
    public Vector3 newScale = new Vector3(2.0f, 2.0f, 1.0f);

    private bool clickIsPressed = false;
    private Vector3 originalScale;
    private PanelManager panelManager;
    public SpawnTgt spawnTgt;

    private void Start()
    {
        originalScale = transform.localScale;
        spawnTgt = FindObjectOfType<SpawnTgt>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        //scoreText.text = score.ToString();
        if (Input.GetMouseButtonDown(0) && clickIsPressed)
        {
            score++;
            GameManager.Instance.IncreaseScore(1);

            StartCoroutine(DieTarget());

            //arreglar este error 
            //GameManager.Instance.IncreaseScore(1);
        }

        if (Time.deltaTime == 0)
        {
            timer = 0;
            clickIsPressed = false;
            //gameObject.SetActive(false);
            //victoryPanel.SetActive(true);
            //Time.timeScale = 0f;
            //panelManager.win();
        }
    }

    IEnumerator DieTarget()
    {
        bubble.volume = 5.0f;
        bubble.Play();
        particles.gameObject.transform.position = transform.parent.position;
        particles.SendEvent("OnPlay");
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(1f) ;
        gameObject.transform .parent.gameObject.SetActive(false);
        spawnTgt.SpawnObject();


        yield return new WaitForSeconds(3f);

        //particles.SendEvent("Stop");
        Destroy(transform.parent.gameObject);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.localScale = newScale;
            clickIsPressed = true;
            Debug.Log("esta dentro");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.localScale = originalScale;
            clickIsPressed = false;
        }
    }
}
