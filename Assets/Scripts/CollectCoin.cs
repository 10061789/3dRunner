using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{

    public int score;
    public PlayerController playerController;

    public TextMeshProUGUI CoinText;
    public Animator Anim;
    public GameObject Player;
    public GameObject EndPanel;

    private void Start()
    {
        Anim = Player.GetComponentInChildren<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("End"))
        {
            Debug.Log("Done..");
            playerController.runningSpeed = 0;
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z,Space.Self);
            EndPanel.SetActive(true);
            if (score>=5)
            {
                Debug.Log("You win..");
                Anim.SetBool("win", true);
            }
            else
            {
                Debug.Log("You lost..");
                Anim.SetBool("lose", true);
            }
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collusion"))
        {

            Debug.Log("touched");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

    public void AddCoin()
    {
        score++;
        CoinText.text = score.ToString();
    }


}
