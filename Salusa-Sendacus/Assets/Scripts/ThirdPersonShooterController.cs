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

    public float fullGunCapacity = 30.0f;

    public float onGoingGunCapacity = 15.0f;

    public float bulletRegen = 1.0f;

    public TextMeshProUGUI jarjorText;

    [SerializeField] GameObject gun;

    [SerializeField] private float aimSensitivity;

    [SerializeField] private LayerMask aimColliderMask = new LayerMask();

    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;

    [SerializeField] private Transform spawnBulletPosition;


    private float aimRigWeight;

    private ThirdPersonController thirdPersonController;

    private StarterAssetsInputs starterAssetsInputs;

    private Animator animator;

    public bool isAming;



    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }


    private void Start()
    {

    }
    private void Update()
    {
        if (onGoingGunCapacity > 0)
        {
            AimAndShoot();
        }



        jarjorText.text = onGoingGunCapacity.ToString();
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


        if (starterAssetsInputs.shoot && isAming)
        {
            Vector3 aimDirection = (mouseWorldPosition - spawnBulletPosition.position).normalized;
            Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDirection, Vector3.up));
            starterAssetsInputs.shoot = false;
            onGoingGunCapacity--;



        }
    }

    IEnumerator UpdateGunCapacity()
    {
        if (onGoingGunCapacity < fullGunCapacity)
        {
            onGoingGunCapacity++;
            yield return null;
        }

        yield return new WaitForSeconds(2);
    }

    private void LateUpdate()
    {

        if (starterAssetsInputs.aim)
        {
            gun.SetActive(true);
        }
        else
        {
            gun.SetActive(false);
        }
        StartCoroutine(UpdateGunCapacity());

    }
}
