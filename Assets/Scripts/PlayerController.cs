using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public string pickupTag = "PickUp"; // Тег объектов, которые нужно собрать

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private int totalPickups; // Общее количество pickups на сцене

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        // Находим все объекты с тегом PickUp на сцене и считаем их
        GameObject[] pickups = GameObject.FindGameObjectsWithTag(pickupTag);
        totalPickups = pickups.Length;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString() + " / " + totalPickups.ToString();
        if (count >= totalPickups)
        {
            winTextObject.SetActive(true);
            //winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!";
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));

        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(pickupTag))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    private void OnCollisionEnter(Collision collision)
{
   if (collision.gameObject.CompareTag("Enemy"))
   {
       // Destroy the current object
       Destroy(gameObject); 
       // Update the winText to display "You Lose!"
       winTextObject.gameObject.SetActive(true);
       winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
   }
}
}