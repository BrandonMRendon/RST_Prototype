using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 5.0f;
    //private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public Transform pivot, cameraPivot, currentPos;
    public bool inVehichle;
    public Camera cameraMain;
    public GameObject currentVehichle;
    public IWeapon weapon;
    public bool inField;
    public Transform targetedEnemy;
    public EnableEstateCreature creatureField;

    private static PlayerController instance;

    public static PlayerController Instance { get { return instance; } }

    public void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }

    }
    public void ResetTracker()
    {
        currentPos.parent = transform;
        currentPos.position = Vector3.zero;
        currentPos.rotation = Quaternion.identity;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = gameObject.GetComponent<CharacterController>();
        inVehichle = false;
        inField = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Debug.Break();
        }
        if (weapon != null && Input.GetButtonDown("Fire1"))
        {
            weapon.Attack();
            if (inField)
            {
                currentPos.parent = null;
                creatureField.ChangeTarget(currentPos);
            }
        }
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        float x = 0;
        float z = Input.GetAxis("Vertical");
        if (!inVehichle)
        {
            x = Input.GetAxis("Horizontal");
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                leaveVehichle();
            }
        }


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * playerSpeed * Time.deltaTime);



        // Changes the height position of the player..
        /*
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }*/

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void EnterVehichle(GameObject vehichle)
    {

        currentVehichle = vehichle;
        controller.enabled = false; ///Controller overrides manual transform changes, this is the cleanest way to do what I want... probably
        gravityValue = 0;
        transform.position = vehichle.GetComponent<IVehichle>().CameraLocation.position;
        transform.rotation = vehichle.GetComponent<IVehichle>().CameraLocation.rotation;
        vehichle.GetComponent<Transform>().SetParent(transform);
        cameraMain.transform.SetParent(vehichle.GetComponent<IVehichle>().CameraLocation, true);
        cameraMain.transform.position = cameraPivot.position;
        cameraMain.transform.rotation = cameraPivot.rotation;

        controller.enabled = true;
        playerSpeed = vehichle.GetComponent<IVehichle>().speed;

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        inVehichle = true;
    }
    public void leaveVehichle()
    {
        gravityValue = -9.81f;
        inVehichle = false;
        //cameraMain.transform.position = cameraPivot.position;
        playerSpeed = 2;
        currentVehichle.transform.parent = null;
        cameraMain.transform.SetParent(cameraPivot, true);
    }
}
