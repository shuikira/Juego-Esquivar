using UnityEngine;

public class Obstaculos : MonoBehaviour
{

    public float fallSpeed;
    public float minY = -15f;
    public int damage; //Daño que el obstáculo inflige al jugador
    public GameManager gameManager; //Referencia al GameManager para acceder a la dificultad del juego

    void Awake()
    {
        //Obtenemos la referencia al GameManager
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void Start()
    {

        //Ajustamos la velocidad de caída y el daño del obstáculo según la dificultad
        switch (gameManager.nivel)
        {
            case GameManager.dificultad.Facil:
                fallSpeed = 2f;
                damage = 1;
                break;
            case GameManager.dificultad.Normal:
                fallSpeed = 4f;
                damage = 2;
                break;
            case GameManager.dificultad.Dificil:
                fallSpeed = 6f;
                damage = 3;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
      if (transform.position.y < minY)
      {
          Destroy(gameObject);
      }  
    }
}
