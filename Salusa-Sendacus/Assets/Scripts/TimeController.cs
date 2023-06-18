using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeController : MonoBehaviour
{

    //Tüm değerleri serializefield yapmamın nedeni bunların unity içerisinde değiştirilebilmesi için
    [SerializeField] private float dayTimeMultiplier;
    [SerializeField] private float nigthTimeMultiplier;
    [SerializeField] private float startHour;

    [SerializeField] private TextMeshProUGUI timeText;

    [SerializeField] private Light sunLight;

    [SerializeField] private float sunriseHour;

    [SerializeField] private float sunsetHour;

    [SerializeField] private Color dayAmbientLight;

    [SerializeField] private Color nightAmbientLight;

    [SerializeField] private AnimationCurve lightChangeCurve;

    [SerializeField] private float maxSunLightIntensity;

    [SerializeField] private Light moonLight;

    [SerializeField] private float maxMoonLightIntensity;
    private DateTime currentTime;

    private TimeSpan sunriseTime;

    private TimeSpan sunsetTime;

    private float sunLightRotation;



    // Start is called before the first frame update
    void Start()
    {

        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);
        // güneş doğum ve güneş batım zamanlarını ayarlıyoruz 
        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);


    }

    // Update is called once per frame
    void Update()
    {
        //Yazdığım fonksyonları update içerisinde çalıştıyorum
        UpdateTimeOfDay();
        RotateSun();
        UpdateLightSettings();
    }

    private void UpdateTimeOfDay()
    {
        //currentTime.AddSeconds ile gerçek zamanı ayarlıyoruz
        //Time.deltaTime bana geçen zamanı verirken daytime multiplayier bana bu değeri değiştirmeme olanak sağlıyor
        currentTime = currentTime.AddSeconds(Time.deltaTime * dayTimeMultiplier);
        //timetext'in null olup olmadığını kontrol ediyoruz
        // daha sonra TOString metoduyla currentTime'ı textte yazması için stringe dönüştürüyoruz
        if (timeText != null)
        {
            timeText.text = currentTime.ToString("HH:mm");
        }
    }

    private void RotateSun()
    {
        // if'in içinde yazan koşul şuan gündüz mü diye kontrol ediyor
        if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            //güneş doğumu ve batımı arasındaki zamanı calculatetimedifference metoduyla kontrol ediyoruz
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunriseTime, sunsetTime);
            //güneş doğduğundan beridir ne kadar zaman geçtiğine bakıyoruz
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);
            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;
            //burada mathf.lerp Kullanarak güneşin dönmesi gereken değeri akıcı bir biçimde hesaplıyoruz
            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage);

        }
        // Gece zamanı için bir else 
        else
        {
            // burda ise yukarıdaki yaptığımız işlemlerin aynılaırını yapıyoruz
            //fakat burası gece olduğu için burda güneş batımından güneş doğumuna kadar ilgileniyoruz
            //ondan dolayı timeSinceSunset değeriyle Sunsettosunriseduration değeri güneşimizi döndürüyor
            currentTime = currentTime.AddSeconds(Time.deltaTime * nigthTimeMultiplier);
            TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(sunsetTime, sunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetTime, currentTime.TimeOfDay);
            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;
            sunLightRotation = Mathf.Lerp(180, 360, (float)percentage);
        }
        //Rotasyonu hesapladığımıza göre artık güneşi döndürebiliriz 
        //vector3.right yapmamızın nedeni ise güneşi x ekseninde döndürmek istememiz
        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right);

    }


    //Güneş/Ayın dönmesi için doğuş ve batış zamanını hesaplıyoruz
    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;
        if (difference.TotalSeconds < 0)
        {
            difference += TimeSpan.FromHours(24);
        }

        return difference;
    }

    private void UpdateLightSettings()
    {
        // Burda güneş ve ay Doğarken ve Batarken yoğunlukluklarını değiştiriyorum
        //mathf.lerp fonksyonu akıcı bir değişim sağlatıyor
        float dotProduct = Vector3.Dot(sunLight.transform.forward, Vector3.down);
        sunLight.intensity = Mathf.Lerp(0, maxSunLightIntensity, lightChangeCurve.Evaluate(dotProduct));
        moonLight.intensity = Mathf.Lerp(maxMoonLightIntensity, 0, lightChangeCurve.Evaluate(dotProduct));
        RenderSettings.ambientLight = Color.Lerp(nightAmbientLight, dayAmbientLight, lightChangeCurve.Evaluate(dotProduct));
    }

}
