using UnityEngine;

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
    
    #region Sprite rotation

    private float spriteY;
    private float spriteX;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite spriteUp;
    [SerializeField] private Sprite spriteDown;
    [SerializeField] private Sprite spriteLeft;
    [SerializeField] private Sprite spriteRight;
    
    #endregion
    
    // Wird einmal pro Frame aufgerufen – Eingabe lesen
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal"); // -1 (links), 0, 1 (rechts)
        input.y = Input.GetAxisRaw("Vertical");   // -1 (unten), 0, 1 (oben)
        spriteX = Input.GetAxisRaw("Horizontal");
        spriteY = Input.GetAxisRaw("Vertical");
        
        if (spriteX > 0)
            spriteRenderer.sprite = spriteRight;
        else if (spriteX < 0)
            spriteRenderer.sprite = spriteLeft;
        else if (spriteY > 0)
            spriteRenderer.sprite = spriteUp;
        else if (spriteY < 0)
            spriteRenderer.sprite = spriteDown;
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
        rb.velocity = velocity;
    }
}