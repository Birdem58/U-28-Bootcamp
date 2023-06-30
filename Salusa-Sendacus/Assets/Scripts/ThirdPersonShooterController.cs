using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;
using TMPro;
public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private Rig aimRig;
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;

    [SerializeField] GameObject gun;

    [SerializeField] GameObject cursor;

    [SerializeField] private float aimSensitivity;

    [SerializeField] private LayerMask aimColliderMask = new LayerMask();

    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;

    [SerializeField] private Transform spawnBulletPosition;




    private float aimRigWeight;

    private ThirdPersonController thirdPersonController;

    private StarterAssetsInputs starterAssetsInputs;

    private Animator animator;

    private float zamanlayici;

    public bool isAming;

    public float sarjor = 30;

    public float anlikSarjor = 30;

    public float sarjorDolumHizi = 1;
    public float sarjorYenilenme = 3;

    private bool isRealoding = false;




    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();

    }


    private void Start()
    {
        anlikSarjor = sarjor;
    }
    private void Update()
    {
        zamanlayici += Time.deltaTime;
        if (anlikSarjor > 0)
        {
            AimAndShoot();
        }

        if (zamanlayici >= sarjorDolumHizi && anlikSarjor < sarjor)
        {
            zamanlayici = 0;
            anlikSarjor++;

        }



        if (anlikSarjor == 0)
        {
            StartCoroutine(Reloding());
            return;
        }


    }


    private void AimAndShoot()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        aimRig.weight = Mathf.Lerp(aimRig.weight, aimRigWeight, Time.deltaTime * 20f);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }
        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
            thirdPersonController.SetRotateOnMove(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
            isAming = true;
            aimRigWeight = 1f;


        }
        else
        {
            thirdPersonController.SetSensitivity(normalSensitivity);
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetRotateOnMove(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
            isAming = false;
            aimRigWeight = 0f;

        }

        if (isRealoding == false)
        {
            if (starterAssetsInputs.shoot && isAming)
            {
                Vector3 aimDirection = (mouseWorldPosition - spawnBulletPosition.position).normalized;
                Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDirection, Vector3.up));
                starterAssetsInputs.shoot = false;
                anlikSarjor--;

            }
        }
    }

    IEnumerator Reloding()
    {
        isRealoding = true;

        yield return new WaitForSeconds(sarjorYenilenme);

        anlikSarjor = sarjor;

        isRealoding = false;
    }

    private void LateUpdate()
    {

        if (starterAssetsInputs.aim)
        {
            gun.SetActive(true);
            cursor.SetActive(true);
        }
        else
        {
            gun.SetActive(false);
            cursor.SetActive(false);
        }


    }
}
