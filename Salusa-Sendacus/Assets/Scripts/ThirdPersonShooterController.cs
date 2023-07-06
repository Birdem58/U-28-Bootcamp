using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private GameObject regenText;

    [SerializeField] private Rig aimRig;
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;

    [SerializeField] private float saniyebasinalazer = 0.2f;

    [SerializeField] GameObject gun;

    [SerializeField] GameObject cursor;

    [SerializeField] GameObject lightParticle;



    [SerializeField] private float aimSensitivity;

    [SerializeField] private LayerMask aimColliderMask = new LayerMask();

    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;

    [SerializeField] private Transform spawnBulletPosition;
    [SerializeField] private AudioClip _lazerSesi;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip _sarjYenileme;
    [SerializeField] private AudioClip _sarjBitis;
    [SerializeField] private AudioClip _sarjToplama;
    [SerializeField] private AudioClip _hasarArttir;
    public AudioClip[] PistolSoundEffects;

    // public ParticleSystem upgrade;
    private float aimRigWeight;

    private ThirdPersonController thirdPersonController;

    private StarterAssetsInputs starterAssetsInputs;

    private Animator animator;

    private float zamanlayici;

    private float lazerZamanlayici;

    public bool isAming;

    public int sarjor = 30;

    public int anlikSarjor = 30;

    public float sarjorDolumHizi = 3;
    public float sarjorYenilenme = 3;

    public int Hasar = 20;

    public ChargeBar chargeBar;

    private bool isRealoding = false;




    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        //  upgrade = GetComponent<ParticleSystem>();

    }


    private void Start()
    {  // anlık şarjörü şarjör kapasitemize eşitliyorum
        anlikSarjor = sarjor;
        chargeBar.SetMaxCharge(sarjor);
        regenText.SetActive(false);
        lightParticle.SetActive(false);

    }
    private void Update()
    {
        // oyun içersinde framelere göre geçen zamanla bir zamanlayıcı tutuyorum 
        zamanlayici += Time.deltaTime;

        lazerZamanlayici += Time.deltaTime;



        // nişan alıp ateş etmemize anlık olarak şarjörümüzde mermi var mı yok mu ona göre karar veriyoruz
        if (anlikSarjor > 0)
        {
            AimAndShoot();
        }
        //burada zamanlayıcıyı şarjordolumhızı yani belirli bir saniyeyi geçtikten sonra anlık şarjoru 1 kere arttıracak şekilde 
        // ve && ile de bunu sadece anlık şarjor sarjorümüzden küçük olduğu zamanlar yapacağı şekilde koşullanırıyorum
        if (zamanlayici >= sarjorDolumHizi && anlikSarjor < sarjor)
        {
            zamanlayici = 0;
            anlikSarjor++;
            chargeBar.SetCharge(anlikSarjor);

        }





    }


    //Karakterimizin uzay içerisinde baktığı yerlere kafasını vve silahını çevirmesine yarayan ve aynı zamanda 
    // nişan alıp ateş etmesini sağlayan bir fonkyson ondan dolayı adı AimAndShoot
    private void AimAndShoot()
    {
        // değişken adından da anlaşılabileceği gibi burada imlecimizin dünya pozisyonunu görüyoruz
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        aimRig.weight = Mathf.Lerp(aimRig.weight, aimRigWeight, Time.deltaTime * 20f);
        // imlecin pozisyonunu transform değerine dönüştürebileceğimiz bir şekilde alıyoruz
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }
        // eğer nişan alırsak yani Sağ tıka basarsak hem aim virtual kameramız aktif oluyor
        // ki bu sayede yakına bakıyoruz ve ayrıca mathf.lerp kullanarak bu geçiş arasında bir yumuşaklık da sağlıyoruz
        // hemde nişan animasyonunu tetikliyoruz
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
        // burda ise nişan almazsak belirli değerleri dengelememiz gerekiyor ki 
        // karakterimiz abuk subuk hareket etmesin ve geçişler rahat olsun
        else
        {
            thirdPersonController.SetSensitivity(normalSensitivity);
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetRotateOnMove(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
            isAming = false;
            aimRigWeight = 0f;

        }
        // burada if içerisinde if yazmamın sebebi hem o an realoding yapıp yapmadığımı kontrol etmem (1.if) 
        // ayrıca şuan aim durumunda olup olmadığımızı kontrol eden (2. if) ve bu sırada
        // sol tıka (input.shoot) basıp basmadığımımzı kontrol eden de bir if var.
        // 2. if içerisinde her sol tıka bastığımızda ateş edilmesini ve şarjorün azalmasını sağlıyorum 
        if (isRealoding == false && isAming)
        {
            if (starterAssetsInputs.shoot && lazerZamanlayici >= saniyebasinalazer)
            {
                int x = Random.Range(0, 2);
                Vector3 aimDirection = (mouseWorldPosition - spawnBulletPosition.position).normalized;
                Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDirection, Vector3.up));
                audioSource.PlayOneShot(PistolSoundEffects[x]);
                starterAssetsInputs.shoot = true;
                anlikSarjor--;
                chargeBar.SetCharge(anlikSarjor);
                lazerZamanlayici = 0;

            }
            // eğer şarjımız bitmişse de burda corotine'i başlatıyorum.
            if (anlikSarjor == 0)
            {
                StartCoroutine(Reloding());
                audioSource.PlayOneShot(_sarjBitis);
                return;
            }
            chargeBar.SetCharge(anlikSarjor);
        }
    }

    //Reloding fonksyonumuz 
    //fonksyonun Ienumerator olmasının sebebi şarjın dolmasının
    // belirli bir zaman alması ve o zaman aralığında da karakterin başka eylmelerde bulunmasını sağlamak örneğin yürüme zıplama vs
    IEnumerator Reloding()
    {
        isRealoding = true;

        yield return new WaitForSeconds(sarjorYenilenme);

        anlikSarjor = sarjor;
        audioSource.PlayOneShot(_sarjYenileme);
        chargeBar.SetCharge(anlikSarjor);





        isRealoding = false;
    }

    IEnumerator ShowRegenText()
    {
        yield return new WaitForSeconds(1);
        regenText.SetActive(false);
    }

    IEnumerator StopHasarEffect()
    {
        yield return new WaitForSeconds(1);
        lightParticle.SetActive(false);
    }

    //Karakter Aim aldığında hedef cursorünün ve Lazer silahının görünmesini sağlıyor.
    //bu fonksyonun referansını lateupdate de görmemizin sebebi animasyonlardan daha 
    //sonra çalışmasının görsel bütünlüğe uymasından kaynaklı
    private void AimAndShow()
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

    public void ChargeHasar()
    {
        Hasar += 5;
        audioSource.PlayOneShot(_hasarArttir);
        lightParticle.SetActive(true);
        StartCoroutine(StopHasarEffect());
    }


    public void ChargeBarRegen()
    {
        audioSource.PlayOneShot(_sarjToplama);
        if (sarjorDolumHizi >= 0.3f)
        {
            sarjorDolumHizi -= 0.1f;
            regenText.SetActive(true);
        }
        if (sarjorYenilenme > 2f)
        {
            sarjorYenilenme -= 0.1f;
            regenText.SetActive(true);
        }
        StartCoroutine(ShowRegenText());


    }


    private void LateUpdate()
    {

        AimAndShow();


    }
}
