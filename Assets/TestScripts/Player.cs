using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Vector3 ScaleVector = new Vector3(0.1f, 0.1f, 0.1f);
    public float Smooth = 0.1f;
    //public Pointer Pointer;
    public Renderer PlayerRenderer;
    public AudioSource AudioSource;
    //public float Radius;
    public float Power = 10f;
    public float MaxPower = 60f;
    public float ScaleFactor = 0.0001f;
    public List<CollectableItem> Collectables = new List<CollectableItem>();
    public int MaximumOfCollectables = 1000;

    public bool invulrable;
    private void OnTriggerEnter(Collider other)
    {
        CollectableItem collectable = other.GetComponent<CollectableItem>();

        if (collectable)
        {
            if (collectable.isCollected == false)
            {
                collectable.OnCollectedByPlayer();
                collectable.transform.SetParent(transform);
                Collectables.Add(collectable);
                ChangePower(ScaleFactor, true);
                if (Collectables.Count > MaximumOfCollectables)
                {
                    int randomint = Random.Range(0, Collectables.Count);
                        Collectables.Remove(Collectables[randomint]);
                }
               // return;
            }
            //SnowManager.CollectSnow(other.GetComponent<Snow>());
            //AudioSource.pitch = Random.Range(0.8f, 1.2f);
            //AudioSource.Play();
        }

        DangerObject dangerObject = other.GetComponent<DangerObject>();
        if (dangerObject )
        {
            
            LoseSomeMass();
        }

        ActivatePhisicsOnContact activator = other.GetComponent<ActivatePhisicsOnContact>();
        if (activator)
        {
            activator.ActivatePhysics();
           // return;
        }

        Finish finish = other.GetComponent<Finish>();
        if (finish)
        {
            LevelManager.Instance.Restart();
        }
        /*
        if (other.GetComponent<YellowSnow>())
        {
            AudioSource.pitch = Random.Range(0.8f, 1.2f);
            AudioSource.Play();
            PlayerRenderer.material.color = Color.yellow;
            SnowManager.isYellow = true;
            if (SnowManager.SnowList.Count > 0)
            {
                SnowManager.UpdateYellowText();
                SnowManager.WinText.enabled = true;
                SnowManager.UpdateYellowWinText();
            }
            Destroy(other.gameObject);
        }*/
    }/*
    private void OnCollisionEnter(Collision collision)
    {
        DangerObject dangerObject = collision.gameObject.GetComponent<DangerObject>();
        if (dangerObject)
        {

            LoseSomeMass();
        }
    }*/
    public void LoseSomeMass()
    {
        if (invulrable) return;
        //חלוםרטעט
        //ÿךשמ חאלאכמ עמ גלונעט
        invulrable = true;
        for (int i = 0; i < Collectables.Count * 0.7f; i++)
        {
            int randomint = Random.Range(0, Collectables.Count);
            Collectables[randomint].BeCollectable();
            Collectables.Remove(Collectables[randomint]);
            
        }
        ResetInvulrable();
    }
    public void ResetInvulrable()
    {
        StartCoroutine(nameof(ResetInvulrableAfter));
    }
    public IEnumerator ResetInvulrableAfter()
    {
        yield return new WaitForSeconds(2f);
        invulrable = false;
    }
    private void FixedUpdate()
    {
        ControlScale();
    }
    public void ChangePower(float power, bool scaleBig)
    {
        //animator.SetTrigger(scaleBig ? "GetBigger" : "GetSmaller");
        Power += power;
        StartCoroutine(ScaleAnimation(power));
        UpdateText();


        if (Power > MaxPower)
        {
            Power = MaxPower;
            ControlScale();
        }
        if (Power < 1f)
        {
            Power = 0f;
            //StartCoroutine(GameOver());
        }
        UpdateText();


    }
    public void UpdateText()
    {
        //PowerText.text = Power.ToString();
    }
    IEnumerator ScaleAnimation(float n)
    {
        Vector3 StartScale = transform.localScale;
        Vector3 EndScale = transform.localScale + Vector3.one * n;

        for (float t = 0; StartScale.y < EndScale.y && transform.localScale.y < MaxPower && t < 1; t += Time.deltaTime * 5f)
        {
            transform.localScale = Vector3.Lerp(StartScale, EndScale, t);
            yield return null;
        }
       // ControlScale();
    }
    public void ControlScale()
    {
        //if (!isGameOver)
        //{
        Vector3 targetVector = new Vector3(Power, Power, Power);
        transform.localScale = Vector3.Lerp(transform.localScale, targetVector,10* Time.deltaTime);
        //Radius = Power * 0.12f;
        //}
    }
}
/*private void OnTriggerEnter(Collider other)
    {
        //Power ++
        if (other.GetComponent<Power>())
        {
            Power powerT = other.GetComponent<Power>();
            ChangePower(powerT.powerUp, powerT.IsPlus);
            Destroy(other.gameObject);
            GameObject effect = Instantiate(powerT.Effect, ExplodePoint.position, Quaternion.identity);
            effect.transform.localScale = transform.localScale;
            effect.transform.SetParent(ExplodePoint);
            return;
        }

        if (other.GetComponent<Attack>())
        {

            other.GetComponent<Attack>().CreateArrow();
            return;

        }
        //Coin ++
        if (other.GetComponent<Finish>())
        {
            GameWin();
            Destroy(other.gameObject);
            return;
        }
        //Power --
        if (other.GetComponent<Trap>())
        {

            Trap trap = other.GetComponent<Trap>();
            
            if (Power >= trap.PowerToBreak)
            {
                stressReceiver.InduceContactStress(trap.PowerToBreak * 0.015f - 0.05f);
                Vector3 pos = other.ClosestPoint(transform.position);
                Instantiate(trap.Partecle, pos, Quaternion.identity);
                CoinManager.AddCoin(trap.CoinsForDestroy);
                Destroy(other.gameObject);
                if (trap.Prefab != null)
                {
                    trap.CreatePrefab();
                    StartCoroutine("Explosion", 0.02f);
                }
            }
            else
            {
                if (!isInvulrable)
                {
                    StartCoroutine(GameOver());
                }
            }
        }
    }

    public void ChangePower(float power, bool scaleBig)
    {
        animator.SetTrigger(scaleBig ? "GetBigger" : "GetSmaller");
        Power += power;
        StartCoroutine(ScaleAnimation(power / 10f));
        UpdateText();


        if (Power > MaxPower)
        {
            Power = MaxPower;
            ControlScale();
        }
        if (Power < 10f)
        {
            Power = 0f;
            StartCoroutine(GameOver());
        }
        UpdateText();


    }
    public void UpdateText()
    {
        PowerText.text = Power.ToString();
    }

    

    public void Explosion()
    {
        Collider[] overlappedCollider = Physics.OverlapSphere(transform.position, Radius);
        for (int i = 0; i < overlappedCollider.Length; i++)
        {
            Rigidbody rb = overlappedCollider[i].attachedRigidbody;
            if (rb != null && rb != PlayerMove.body)
            {
                rb.AddExplosionForce(Force * 20f, ExplodePoint.position, Radius);
                rb.AddForce(Vector3.forward * Force, ForceMode.VelocityChange);
            }
        }
    }
    */
