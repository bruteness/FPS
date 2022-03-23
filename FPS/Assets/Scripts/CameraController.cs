using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private float _mouseMovement = 200; //[SerializedField] attribute used to show private variable in the inspector-- controls how fast we want to rotate

    //private GameManager _gameManager;
    private Transform parent; //reference to our parent object
    private Camera _fpsCamera;
    private float xRotation = 0f;

    private void Start() {
        //_gameManager = FindObjectOfType<GameManager>();
        _fpsCamera = Camera.main; //Accessing our object camera
        parent = transform.parent; //the parent of our object is the object we want to rotate
        Cursor.lockState = CursorLockMode.Locked; //locks mouse to the center of the screen
    }

    private void Update() {
        float horizontalRotation = Input.GetAxis("Mouse X") * _mouseMovement * Time.deltaTime; //horizontal rotation calculation
        float verticalRotation = Input.GetAxis("Mouse Y") * _mouseMovement * Time.deltaTime; // vertical rotation calculation

        xRotation -= verticalRotation;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        parent.Rotate(Vector3.up * horizontalRotation); //rotate parent around the vertical axis-- horizontal movement

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                Transform objectHit = hit.transform;
                IDamage damagable = objectHit.GetComponent<IDamage>();
                if(damagable != null)
                {
                    damagable.TakeDamage();
                }
            }
        }
    }
}