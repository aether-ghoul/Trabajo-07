using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public TMP_Text countText;
    public TMP_Text winText;

    private Rigidbody rb;
    private Animator anim;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        count = 0;
        setCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if(rb.velocity.x>0.08)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            //winText.text = "You Die!!";
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count>=12)
        {
            winText.text = "You win!!";
        }
    }
}
