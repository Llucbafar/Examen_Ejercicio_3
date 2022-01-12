using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
	
    public string currentColor;

	public UILives uilives;

	public Color colorBlue; //40CEE2
	public Color colorYellow; //FFBC47
	public Color colorGreen; //9BFF5F
	public Color colorRed; //F45E5D

	public Color colorin;

	public GameObject projectilePrefab;
    public float fireRate = 0.5f;

	private Rigidbody2D rigidbody2d;

	Vector2 lookDirection = new Vector2(1,0);

	public Vector2 movementDirection;

    public SpriteRenderer sr;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

	public UIGameover uigameover;


	void Start ()
	{
		SetRandomColor();
		rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
	}
	

	
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);

        if (movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

		if ((uigameover.finished) && (Input.GetKeyDown(KeyCode.F)))
		{
			Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
			Time.timeScale = 1;
		}

    }

	void fire()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }


    void OnTriggerEnter2D (Collider2D col)
	{

		if (col.tag == "ColorChanger")
		{
			UIScore.points += 1;
			UITimer.timeRemaining += 30;
			if (UIScore.points == 15)
			{
				uigameover.win();
			}

		}

		else if (col.tag != gameObject.tag)
		{
			uilives.RestLives();
		}

	}

	void SetRandomColor ()
	{
		int index = Random.Range(0, 4);

		switch (index)
		{
			case 0:
				currentColor = "Blue";
				sr.color = colorBlue;
				gameObject.tag = "Blue";
				break;
			case 1:
				currentColor = "Yellow";
				sr.color = colorYellow;
				gameObject.tag = "Yellow";
				break;
			case 2:
				currentColor = "Green";
				sr.color = colorGreen;
				gameObject.tag = "Green";
				break;
			case 3:
				currentColor = "Red";
				sr.color = colorRed;
				gameObject.tag = "Red";
				break;
		}
	}

	void SetColor ()
	{

		sr.color = colorin;

	}	
}