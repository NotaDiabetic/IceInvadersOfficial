using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

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
    public GameObject player;

    #endregion

    #region Snowball mechanics

    // Bestimmt, wie viel Zeit zwischen einzelnen Angriffen mindestens vergehen muss
    [SerializeField] public float shootingDelay = 0.5f;
    
    // Legt die Bewegungsrichtung der Schneebälle fest
    public Vector3 _direction = new Vector3(0f, 0f, 0f);

    // Verbindung zum SnowballCatcher script (ab hier sbc genannt)
    [SerializeField] private SnowballCatcher sbc;

    // Erstellt die drei GameObjects für die drei Schneeball Typen
    public GameObject snowball_simple;
    public GameObject snowball_medium;
    public GameObject snowball_heavy;
    
    // Erstellt den Transform "firepoint", damit diesem ein Objekt in der Scene zugewiesen werden kann
    public Transform firePoint;

    // Legt die Geschwindigkeit der Spieler Angriffe fest
    public float snowballSpeed = 10;

    // Erstellt den Vector "lookDirection". Dieser soll später immer der Richtung vom Spieler zur Maus entsprechen
    public Vector2 lookDirection;

    // Bestimmt den Winkel vom lookDirection Vector im Vergleich zum Vector (1, 0, 0) (gerade nach rechts, entlang der x achse)
    public float lookAngle;

    // legt fest, ob der Spieler Angreifen kann
    private bool _canShoot = true;

    // Legt fest, ob der Spieler normal angreift oder mit der Maus zielen kann
    public bool _easyMode = false;

    private IEnumerator ShootMouse()
    {
        Debug.Log(message: "Snowball thrown");
        _canShoot = false;
        snowballSpeed = 10;
        if (sbc.ProjectileType == 0)
        {
            GameObject SB_simple = Instantiate(snowball_simple);
            SB_simple.transform.position = firePoint.position;
            SB_simple.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
            SB_simple.GetComponent<Rigidbody2D>().linearVelocity = firePoint.right * snowballSpeed;
            yield return new WaitForSeconds(shootingDelay);
        }
        else if (sbc.ProjectileType == 1)
        {
            GameObject SB_medium = Instantiate(snowball_medium);
            SB_medium.transform.position = firePoint.position;
            SB_medium.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
            SB_medium.GetComponent<Rigidbody2D>().linearVelocity = firePoint.right * snowballSpeed;
            yield return new WaitForSeconds(shootingDelay);
        }
        else if (sbc.ProjectileType == 2)
        {
            GameObject SB_heavy = Instantiate(snowball_heavy);
            SB_heavy.transform.position = firePoint.position;
            SB_heavy.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
            SB_heavy.GetComponent<Rigidbody2D>().linearVelocity = firePoint.right * snowballSpeed;
            yield return new WaitForSeconds(shootingDelay);
        }
        _canShoot = true;

    }
    private IEnumerator ShootSpace()
    {
        Debug.Log(message: "Snowball thrown");
        _canShoot = false;
        if (sbc.ProjectileType == 0)
        {
            GameObject SB_simple = Instantiate(snowball_simple);
            SB_simple.transform.position = firePoint.position;
            SB_simple.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
            _direction = new Vector3(0, 1, 0);
            snowballSpeed = 10;
            if (Keyboard.current.aKey.isPressed)
            {
                _direction += new Vector3(-1, 0, 0);
                snowballSpeed = 7;
            }
            if (Keyboard.current.dKey.isPressed)
            {
                _direction += new Vector3(1, 0, 0);
                snowballSpeed = 7;
            }
            SB_simple.GetComponent<Rigidbody2D>().linearVelocity = _direction * snowballSpeed;
            yield return new WaitForSeconds(shootingDelay);
        }
        else if (sbc.ProjectileType == 1)
        {
            GameObject SB_medium = Instantiate(snowball_medium);
            SB_medium.transform.position = firePoint.position;
            SB_medium.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
            _direction = new Vector3(0, 1, 0);
            snowballSpeed = 10;
            if (Keyboard.current.aKey.isPressed)
            {
                _direction += new Vector3(-1, 0, 0);
                snowballSpeed = 7;
            }
            if (Keyboard.current.dKey.isPressed)
            {
                _direction += new Vector3(1, 0, 0);
                snowballSpeed = 7;
            }
            SB_medium.GetComponent<Rigidbody2D>().linearVelocity = _direction * snowballSpeed;
            yield return new WaitForSeconds(shootingDelay);
        }
        else if (sbc.ProjectileType == 2)
        {
            GameObject SB_heavy = Instantiate(snowball_heavy);
            SB_heavy.transform.position = firePoint.position;
            SB_heavy.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
            _direction = new Vector3(0, 1, 0);
            snowballSpeed = 10;
            if (Keyboard.current.aKey.isPressed)
            {
                _direction += new Vector3(-1, 0, 0);
                snowballSpeed = 7;
            }
            if (Keyboard.current.dKey.isPressed)
            {
                _direction += new Vector3(1, 0, 0);
                snowballSpeed = 7;
            }
            SB_heavy.GetComponent<Rigidbody2D>().linearVelocity = _direction * snowballSpeed;
            yield return new WaitForSeconds(shootingDelay);
        }
        _canShoot = true;
        
    }

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
            
            lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(player.transform.position.x, player.transform.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            if (_canShoot == true && _easyMode == true)
            {
                StartCoroutine(ShootMouse());
            }
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (_canShoot == true && _easyMode == false)
            {
                StartCoroutine(ShootSpace());
            }
        }

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            sbc.ProjectileType--;
            if (sbc.ProjectileType <= -1)
            {
                sbc.ProjectileType = 2;
            }
            sbc.UpdateProjectileType(sbc.ProjectileType);
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            sbc.ProjectileType++;
            if (sbc.ProjectileType >= 3)
            {
                sbc.ProjectileType = 0;
            }
            sbc.UpdateProjectileType(sbc.ProjectileType);
        }
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