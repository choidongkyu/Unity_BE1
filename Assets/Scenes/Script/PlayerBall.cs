using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    new Rigidbody rigidbody;
    float jumpPower = 30;
    public int score = 0;
    private bool isJump;
    private AudioSource audio;
    public GameManagerLogic manager;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        isJump = false;
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigidbody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigidbody.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            audio.Play();
            other.gameObject.SetActive(false);
            score++;
        }

        if (other.tag == "Goal")
        {
            if(manager.totalItemCount == score)
            {
                SceneManager.LoadScene("SampleScene");
            } else
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
