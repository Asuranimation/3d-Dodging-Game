using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody rb;

    [SerializeField] float minX;
    [SerializeField] float maxX;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float axisH = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime ;
        Vector3 position = new Vector3(transform.position.x + axisH, transform.position.y, transform.position.z);
        float clampPos = Mathf.Clamp(position.x, minX, maxX);
        Vector3 newPos = new Vector3 (clampPos, transform.position.y, transform.position.z);
        transform.position = newPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
