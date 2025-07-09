using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class IceMovement : MonoBehaviour
{
    #region Ice Movment
    
    // Verbindung zum Rigidbody2D (damit die Physik funktioniert)
    [SerializeField] private Rigidbody2D rb;

    // Wie schnell der Charakter beschleunigt (je höher, desto schneller reagiert er)
    [SerializeField] private float acceleration = 0.5f;

    // Maximalgeschwindigkeit – höher = schneller
    [SerializeField] private float maxSpeed = 10f;

    // Reibung / Abbremsen – je kleiner, desto länger gleitet der Spieler
    [SerializeField] private float friction = -20f;

    // Eingabewert von Tastatur (WASD oder Pfeiltasten)
    private Vector2 input;

    // Der aktuelle Bewegungsvektor (z.B. in welche Richtung und wie schnell er rutscht)
    private Vector2 velocity;
    
    #endregion
    
    #region Animation

    public Animator animator;

    private bool moving;
    private bool isFacingRight;

    #endregion

   
    // Wird einmal pro Frame aufgerufen – Eingabe lesen
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal"); // -1 (links), 0, 1 (rechts)
        input.y = Input.GetAxisRaw("Vertical");   // -1 (unten), 0, 1 (oben)

        Animate();
    }

    private void Animate()
    {
        //magnitude is how big the input is, so if there is any input at all the moving = true or if no input the moving = false
        //and checking if an input is positive or negative
        if(input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (moving)
        {
            animator.SetFloat("X", input.x);
            animator.SetFloat("Y", input.y);
        }

        animator.SetBool("Moving", moving);

        //If statement schaut wo hin der character im Moment ausgerichtet ist
        if(!isFacingRight && input.x > 0)
        {
            Flip();
        }
        else if (isFacingRight && input.x < 0)
        {
            Flip();
        }
    }

    //Funktion die überprüft ob die Animation des Charakters nach links oder nach rechts ausgerichtet ist
    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    // Wird 50x pro Sekunde aufgerufen – perfekt für Physik
    void FixedUpdate()
    {
        // Die Zielgeschwindigkeit in Richtung der Eingabe
        Vector2 targetVelocity = input.normalized * maxSpeed;

        // Gleiche die aktuelle Geschwindigkeit mit der Zielgeschwindigkeit an:
        // → `Lerp` bewegt sich weich von A (current) zu B (target) in acceleration (Stücke)
        velocity = Vector2.Lerp(velocity, targetVelocity, acceleration * Time.fixedDeltaTime);

        // Wenn keine Tasten gedrückt werden -> bremse langsam ab (wie auf Eis)
        if (input == Vector2.zero)
        {
            velocity = Vector2.Lerp(velocity, Vector2.zero, friction * Time.fixedDeltaTime);
        }

        // Wende die Bewegung auf das Rigidbody an → bewegt das Objekt in der Welt
        rb.linearVelocity = velocity;
    }
}