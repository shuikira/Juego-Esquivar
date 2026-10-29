using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public int vidas;
    public float velocidad;
    private float xMin = -7.5f, xMax = 7.5f;
    
    
    //dependiendo de la dificultad, el juego tendrá diferentes valores de vidas y velocidad de caída de los obstáculos
   

    void Start()
    {
        
    }

    void Update()
    {
        //movimiento horizontal del jugador
        //float move = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        //transform.Translate(move, 0f, 0f);

        float direccion = 0f;
        Keyboard keyboard = Keyboard.current;
        if (keyboard != null)
        {
            if (keyboard.leftArrowKey.isPressed || keyboard.aKey.isPressed)
            {
                direccion = -1f;
            }
            else if (keyboard.rightArrowKey.isPressed || keyboard.dKey.isPressed)
            {
                direccion = 1f;
            }   
        }

        Gamepad gamepad = Gamepad.current;
        if (gamepad != null && gamepad.leftStick.ReadValue().x > 0.1f)
        {
                direccion = gamepad.leftStick.ReadValue().x;
        }
        
        transform.Translate(direccion * velocidad * Time.deltaTime, 0f, 0f);

        //limitar el movimiento del jugador dentro de los limites de la pantalla
        Vector3 posicionActual = transform.position;
        posicionActual.x = Mathf.Clamp(posicionActual.x, xMin, xMax);
        transform.position = posicionActual;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
           Obstaculos obstaculo = collision.gameObject.GetComponent<Obstaculos>();
           if (obstaculo != null)
           {
               Destroy(collision.gameObject);
               vidas-= obstaculo.damage;

               if (vidas <= 0)
               {
                   //Accion cuando el jugador pierde todas las vidas
                   Debug.Log("Game Over");
                   Time.timeScale = 0f; //Detener el juego
               } else
               {
                   Debug.Log("Vidas restantes: " + vidas);
               }

           }
        }
    }
}
