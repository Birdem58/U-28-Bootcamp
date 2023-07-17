using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveList : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip _objTamamlama;
    public TextMeshProUGUI objectivetext;
    public bool firstJump = true;
    public bool isMoved = true;
    public bool firstRun = true;
    public bool firstShot = true;
    public bool liweiVadiDuvar = true;

    public bool liweiDinle = true;

    public bool liweiBilgi = true;

    public bool chrisCanavarSavas = true;

    public bool chrisBulunmadi = true;

    public bool chriskonusulmadi = true;

    public bool mayailktriggerduvar = true;

    public bool bantidDuvarTrigger = true;

    public bool mayaikincitriggerduvar = true;

    public bool mayaCanavarDuvari = true;

    public bool mayaIleKonus = true;

    public bool mayaKonusmaSornasi = true;

    public bool mertIlkTriggerDuvar = true;

    public bool mertIkinciTriggerDuvar = true;
    public bool mertCanavarOldurmeTrigger = true;
    public bool mertKonusmaSornasi = true;

    public bool mertiBul = true;


    public int mertCanavarCount;
    public int mayaCanavarCount;
    public int banditCanavarCount;
    public int chrisCanavarCount;
    public int objtutKristal = 0;
    public int index = 0;
    void Start()
    {

    }
    void Update()
    {
        CurrentObj();
    }


    public void TutObjMove()
    {
        if (isMoved && index == 0)
        {
            isMoved = false;
            ObjTransiton();
        }
    }

    public void TutObjJump()
    {
        if (firstJump && index == 1)
        {
            firstJump = false;
            ObjTransiton();
        }
    }
    public void TutObjRun()
    {
        if (firstRun && index == 2)
        {
            firstRun = false;
            ObjTransiton();
        }
    }


    public void TutObjShoot()
    {
        if (firstShot && index == 3)
        {
            firstShot = false;
            ObjTransiton();
        }

    }

    public void TutObjKristal()
    {
        objtutKristal++;
        if (objtutKristal == 15 && index == 4)
        {
            objtutKristal = 0;
            ObjTransiton();
        }
    }

    public void LiweiVadiTrigger()
    {
        if (liweiVadiDuvar && index == 5)
        {
            liweiVadiDuvar = false;
            ObjTransiton();
        }
    }

    public void LiWeiKonusma()
    {
        if (liweiDinle && index == 6)
        {
            liweiDinle = false;
            ObjTransiton();
        }
    }
    public void LiWeiBilgi()
    {
        if (liweiBilgi && index == 7)
        {
            liweiBilgi = false;
            ObjTransiton();
        }
    }

    public void ChrisCanavarSavasi()
    {
        if (chrisCanavarSavas && index == 8)
        {
            chrisCanavarSavas = false;
            ObjTransiton();

        }
    }

    public void ChrisCanavarOlumCount()
    {
        chrisCanavarCount++;
        if (chrisCanavarCount == 5 && index == 9)
        {
            chrisCanavarCount = 0;
            ObjTransiton();
        }

    }

    public void ChrisBulDuvarTrigger()
    {
        if (chrisBulunmadi && index == 10)
        {
            chrisBulunmadi = false;
            ObjTransiton();
        }

    }

    public void ChrisKonusma()
    {
        if (chriskonusulmadi && index == 11)
        {
            chriskonusulmadi = false;
            ObjTransiton();
        }

    }

    public void MayaIlkDuvarTrigger()
    {
        if (mayailktriggerduvar && index == 12)
        {
            mayailktriggerduvar = false;
            ObjTransiton();
        }
    }

    public void BanditDuvarTrigger()
    {
        if (bantidDuvarTrigger && index == 13)
        {
            bantidDuvarTrigger = false;
            ObjTransiton();

        }
    }

    public void BanditCanavarOlum()
    {
        banditCanavarCount++;
        if (banditCanavarCount == 3 && index == 14)
        {
            banditCanavarCount = 0;
            ObjTransiton();
        }
    }
    public void MayaIkinciDuvarTrigger()
    {
        if (mayaikincitriggerduvar && index == 15)
        {
            mayaikincitriggerduvar = false;
            ObjTransiton();
        }
    }

    public void MayaCanavarDuvari()
    {
        if (mayaCanavarDuvari && index == 16)
        {
            mayaCanavarDuvari = false;
            ObjTransiton();
        }
    }

    public void MayaCanavarOldurme()
    {
        mayaCanavarCount++;
        if (mayaCanavarCount == 7 && index == 17)
        {
            mayaCanavarCount = 0;
            ObjTransiton();
        }
    }

    public void MayaIleKonus()
    {
        if (mayaIleKonus && index == 18)
        {
            mayaIleKonus = false;
            ObjTransiton();
        }

    }

    public void MayaKonusmaSornasi()
    {
        if (mayaKonusmaSornasi && index == 19)
        {
            mayaKonusmaSornasi = false;
            ObjTransiton();
        }
    }

    public void MertIlkTriggerDuvar()
    {
        if (mertIlkTriggerDuvar && index == 20)
        {
            mertIlkTriggerDuvar = false;
            ObjTransiton();
        }
    }

    public void MertIkinciTriggerDuvar()
    {
        if (mertIkinciTriggerDuvar && index == 21)
        {
            mertIkinciTriggerDuvar = false;
            ObjTransiton();
        }
    }
    public void MertCanavarOldurmeTrigger()
    {
        if (mertCanavarOldurmeTrigger && index == 22)
        {
            mertCanavarOldurmeTrigger = false;
            ObjTransiton();
        }
    }
    public void MertCanavarOldurme()
    {
        mertCanavarCount++;
        if (mertCanavarCount == 6 && index == 23)
        {
            mertCanavarCount = 0;
            ObjTransiton();
        }
    }



    //BUrayaCanvarlaKarşılaşacağına yakın box trigger ekle
    public void MertiBul()
    {

        if (mertiBul && index == 24)
        {
            mertiBul = false;
            ObjTransiton();
        }
    }

    public void MertKonusmaSornasi()
    {
        if (mertKonusmaSornasi && index == 24)
        {
            mertKonusmaSornasi = false;
            ObjTransiton();
        }
    }



    void ObjTransiton()
    {
        audioSource.PlayOneShot(_objTamamlama);
        index++;

    }
    void ObjTransitonWithoutSound()
    {
        index++;

    }

    void CurrentObj()
    {
        if (index == 0)
        {
            objectivetext.text = "WASD ile Hareket et";
        }
        if (index == 1)
        {
            objectivetext.text = "Space Tuşuna Basıp Zıpla";
        }
        if (index == 2)
        {
            objectivetext.text = "Shift Tuşuna basarak koş";
        }
        if (index == 3)
        {
            objectivetext.text = " Sağ Tıkla Nişan al ve Sol Tıkla Ateş et";
        }
        if (index == 4)
        {
            objectivetext.text = "Gölün Solundaki Kristalleri Topla " + objtutKristal.ToString() + " /15";
        }
        if (index == 5)
        {
            objectivetext.text = "Vadiye doğru ilerle";
        }
        if (index == 6)
        {
            objectivetext.text = "Ağaçların arasındaki yabancı ile Konuş";
        }
        if (index == 7)
        {
            objectivetext.text = "Li Wei Chris'in köyde olduğunu söyledi onu kurtarmak için köye in";
        }
        if (index == 8)
        {
            objectivetext.text = "Canavarları Öldür ";
        }
        if (index == 9)
        {
            objectivetext.text = "Canavarları Öldür " + chrisCanavarCount.ToString() + " /5";
        }
        if (index == 10)
        {
            objectivetext.text = "Chris'i Bul !";
        }
        if (index == 11)
        {
            objectivetext.text = "Chris ile konuş !";
        }
        if (index == 12)
        {
            objectivetext.text = "Gemiye Geri Dön !";
        }
        if (index == 13)
        {
            objectivetext.text = " Geminin Burnunun Baktığı Vadiye Doğru İlerle";
        }
        if (index == 14)
        {
            objectivetext.text = "Seni Pusuya Düşüren Canavarları Öldür " + banditCanavarCount.ToString() + " /3";
        }
        if (index == 15)
        {
            objectivetext.text = "Vadiye Doğru ilerle";
        }
        if (index == 16)
        {
            objectivetext.text = "Maya'nın Olduğu Köyü Bul (ipucu: büyük mantarları takip et )";
        }
        if (index == 17)
        {
            objectivetext.text = "Maya'yı Kurtarmak İçin Canavarları Öldür";
        }
        if (index == 18)
        {
            objectivetext.text = "Maya'yı Bul !";
        }
        if (index == 19)
        {
            objectivetext.text = "Maya İle Konuş";
        }
        if (index == 20)
        {
            objectivetext.text = "Mantarları Takip ederek Gemiye Git";
        }
        if (index == 21)
        {
            objectivetext.text = "Sağa doğru ilerleyip gölü takip ederek Mert'i kurtar !";
        }
        if (index == 22)
        {
            objectivetext.text = "Artık takip etmen gereken şeyi biliyorsun :)";
        }
        if (index == 23)
        {
            objectivetext.text = "Mert'i kurtarmak için Canavarları Öldür " + mertCanavarCount.ToString() + " /6";
        }
        if (index == 24)
        {
            objectivetext.text = "Mert'i Bul !";
        }
        if (index == 25)
        {
            objectivetext.text = "Mert İle Konuş";
        }
        if (index == 26)
        {
            objectivetext.text = "Artık Burdan Gitme Zamanı Gemiye Dön !";
        }



    }


}
