using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public float distanceToSee;
    public GameObject shovel;
    public GameObject seeds;
    public GameObject sickle;
    public bool active = true;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && shovel.activeSelf == true && active == true)
        {
            StartCoroutine(Animate(shovel, "shovelUse"));
        }
        else if (Input.GetMouseButtonDown(0) && sickle.activeSelf == true)
        {
            StartCoroutine(Animate(sickle, "sickleUse"));
        }
        else if (Input.GetMouseButtonDown(0) && seeds.activeSelf == true)
        {
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, this.transform.forward, 
                    out hit, distanceToSee) && hit.transform.tag == "Field")
            {
                hit.transform.SendMessage("Hit");
            }
        }
    }

    public IEnumerator Animate(GameObject go, string animstring)
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceToSee) && hit.transform.tag == "Field")
        {
            hit.transform.SendMessage("Hit");
        }
        Animator anim = go.GetComponent<Animator>();
        anim.Play(animstring);
        while (anim.GetCurrentAnimatorClipInfo(0).Length == 0)
        {
            yield return null;
        }
        active = false;
        while (anim.GetCurrentAnimatorClipInfo(0).Length != 0 && anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == animstring)
        {
            yield return null;
        }
        active = true;
    }
}
