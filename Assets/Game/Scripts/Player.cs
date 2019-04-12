using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    private CharacterController _controller;
    public int currentAmmo;
    private bool reloading = false;
    private UIManager uiManager;

    public bool coin = false;
    public float playerSpeed = 0.0f;
    public float gravity = 0.0f;
    public GameObject muzzleFlash;
    public GameObject hitMarker;
    public GameObject rifleSound;
    public int maxAmmo = 0;
    public float reloadDelay = 0.0f;
    public GameObject coinSound;
    public GameObject gun;
    public bool hasGun = false;
   
	// Use this for initialization
	void Start ()
    {
        gun.SetActive(false);
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        muzzleFlash.SetActive(false);
        currentAmmo = maxAmmo;
        //uiManager.UpdateAmmo(currentAmmo, maxAmmo);
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Volvemos el cursor visible
        if (Input.GetButtonDown("Cancel"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        //Lanzamos un raycast desde el centro de la pantalla
        if(Input.GetButton("Fire1") && currentAmmo > 0)
        {
            if(hasGun == true)
            {
                Shoot();
            }
        }
        else
        {
            //Muzzle COntroller
            muzzleFlash.SetActive(false);
            rifleSound.GetComponent<AudioSource>().Stop();
        }

        //Recargamos el arma
        if (Input.GetButtonDown("Fire2") && reloading == false)
        {
            if(hasGun)
            {
                StartCoroutine(Reload());
            }
            
        }

    }

    public void CoinPick()
    {
        coinSound.GetComponent<AudioSource>().Play();
        coin = true;
    }

    IEnumerator Reload ()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadDelay);
        currentAmmo = maxAmmo;
        uiManager.UpdateAmmo(currentAmmo, maxAmmo);
        reloading = false;
    }

    private void Shoot ()
    {
        muzzleFlash.SetActive(true);
        if (rifleSound.GetComponent<AudioSource>().isPlaying == false)
        {
            rifleSound.GetComponent<AudioSource>().Play();
        }
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        //Guardamos la info de a lo que le pegamos
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            //Miramos si pega con algo
            Debug.Log("RayCast hit" + hitInfo.transform.name);
            Instantiate(hitMarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

            //Miramos si damos contra una caja y si es así ejecutamos el metodo del script de la caja
            Destructible crate = hitInfo.transform.GetComponent<Destructible>();
            if(crate != null)
            {
                crate.CrateDestroy();
            }
        }
        currentAmmo--;
        uiManager.UpdateAmmo(currentAmmo, maxAmmo);
    }

    private void FixedUpdate()
    {
        CalculateMovement();
    }

    //Metodo para el moviento del player
    void CalculateMovement ()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * playerSpeed;
        velocity.y -= gravity;
        //Tranformamos el movimiento a worldspace
        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime * playerSpeed);
    }
}
