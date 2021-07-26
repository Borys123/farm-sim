using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farming : MonoBehaviour
{
    public Material notPlowed;
    public Material Plowed;
    public GameObject Object;
    private bool isPlowed = false;
    private bool isPlanted = false;
    private bool isGrown = false;
    private GameObject plant;
    private Animation anim;
    public float speed = 1.0f;
    private int crop = -1;
    private int previous = -1;
    private double wheatCropAmount = 50.0;
    private double cornCropAmount = 65.0;
    private double beetCropAmount = 200.0;
    private double rapeseedCropAmount = 30.0;
    private double wheatSeedAmount = 1.5;
    private double cornSeedAmount = 0.2;
    private double beetSeedAmount = 0.2;
    private double rapeseedSeedAmount = 0.04;
    public AudioSource source;
    public AudioClip shovelClip;
    public AudioClip sickleClip;
    public AudioClip seedClip;

    void resetState()
    {
        isPlowed = false;
        isPlanted = false;
        isGrown = false;
    }

    void Start()
    {
        resetState();
    }

    void Update()
    {
        
    }

    void Add(int x)
    {
        switch(x)
        {
            case 0:
                if (previous == 3)
                    Inventory.wheat += (wheatCropAmount + 30/100 * wheatCropAmount);
                else
                    Inventory.wheat += wheatCropAmount;
                break;
            case 1:
                if (previous == 0)
                    Inventory.corn += (cornCropAmount + 30 / 100 * cornCropAmount);
                else
                    Inventory.corn += cornCropAmount;
                break;
            case 2:
                if (previous == 1)
                    Inventory.beet += (beetCropAmount + 30 / 100 * beetCropAmount);
                else
                    Inventory.beet += beetCropAmount;
                break;
            case 3:
                if (previous == 2)
                    Inventory.rapeseed += (rapeseedCropAmount + 30 / 100 * rapeseedCropAmount);
                else
                    Inventory.rapeseed += rapeseedCropAmount;
                break;
        }
    }
    void Plow()
    {
        Object.GetComponent<MeshRenderer>().material = Plowed;
        isPlowed = true;
        isPlanted = false;
        isGrown = false;
    }

    void Plant(int crop)
    {
        if (crop >= 0)
        {
            switch(crop)
            {
                case 0:
                    if (Inventory.wheatSeed >= wheatSeedAmount)
                    {
                        Inventory.wheatSeed -= wheatSeedAmount;
                        isPlanted = true;
                        StartCoroutine(Grow(crop));
                        break;
                    }
                    else break;
                case 1:
                    if (Inventory.cornSeed >= cornSeedAmount)
                    {
                        Inventory.cornSeed -= cornSeedAmount;
                        isPlanted = true;
                        StartCoroutine(Grow(crop));
                        break;
                    }
                    else break;
                case 2:
                    if (Inventory.beetSeed >= beetSeedAmount)
                    {
                        Inventory.beetSeed -= beetSeedAmount;
                        isPlanted = true;
                        StartCoroutine(Grow(crop));
                        break;
                    }
                    else break;
                case 3:
                    if (Inventory.rapeseedSeed >= rapeseedSeedAmount)
                    {
                        Inventory.rapeseedSeed -= rapeseedSeedAmount;
                        isPlanted = true;
                        StartCoroutine(Grow(crop));
                        break;
                    }
                    else break;
            }
            
        }
    }

    void Gather(int crop)
    {
        for (int i = 0; i < this.gameObject.transform.GetChild(crop).gameObject.transform.childCount; i++)
        {
            this.gameObject.transform.GetChild(crop).gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        Object.GetComponent<MeshRenderer>().material = notPlowed;
        Add(crop);
        previous = crop;
        resetState();
    }

    public IEnumerator Grow(int crop)
    {
        for (int i = 0; i < this.gameObject.transform.GetChild(crop).gameObject.transform.childCount; i++)
        {
            string animName = "";
            switch (crop)
            {
                case 0:
                    animName = "Growth0";
                    break;
                case 1:
                    animName = "Growth1";
                    break;
                case 2:
                    animName = "Growth2";
                    break;
                case 3:
                    animName = "Growth3";
                    break;

            }
            plant = this.gameObject.transform.GetChild(crop).gameObject.transform.GetChild(i).gameObject;
            plant.SetActive(true);
            anim = plant.GetComponent<Animation>();
            anim.Play();
            if (i == this.gameObject.transform.GetChild(crop).gameObject.transform.childCount - 1)
                while (anim.IsPlaying(animName))
                {
                    yield return null;
                }
        }
        isGrown = true;
    }

    void Hit()
    {
        if (Tools.equipped == 1 && isPlowed == false && isPlanted == false && isGrown == false)
        {
            source.clip = shovelClip;
            source.Play();
            Plow();
        }
        else if (isPlowed == true && isPlanted == false && isGrown == false)
        {
            switch(Tools.equipped)
            {
                case 3:
                    crop = 0;
                    break;
                case 4:
                    crop = 1;
                    break;
                case 5:
                    crop = 2;
                    break;
                case 6:
                    crop = 3;
                    break;
                default:
                    crop = -1;
                    break;
            }

            if (crop >= 0)
            {
                source.clip = seedClip;
                source.Play();
            }
            Plant(crop);
        }
        else if (Tools.equipped == 2 && isPlowed == true && isPlanted == true && isGrown == true)
        {
            source.clip = sickleClip;
            source.Play();
            Gather(crop);
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plow" && isPlowed == false && isPlanted == false && isGrown == false)
        {
            Plow();
        }
        else if (other.gameObject.tag == "Planter" && isPlowed == true && isPlanted == false && isGrown == false)
        {
            switch (PlanterSeeds.equipped)
            {
                case 3:
                    crop = 0;
                    break;
                case 4:
                    crop = 1;
                    break;
                case 5:
                    crop = 2;
                    break;
                case 6:
                    crop = 3;
                    break;
                default:
                    crop = -1;
                    break;
            }
            Plant(crop);
        }
        else if (other.gameObject.tag == "Combine" && isPlowed == true && isPlanted == true && isGrown == true)
        {
            Gather(crop);
        }
    }
}
