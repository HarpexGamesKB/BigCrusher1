using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public Vector3 ScaleVector = new Vector3(0.1f, 0.1f, 0.1f);
    //public float Smooth = 0.1f;
    //public Pointer Pointer;
    //public Renderer PlayerRenderer;
    //public AudioSource AudioSource;
    //public float Radius;
    public float Power = 10f;
    public float MaxPower = 60f;
    public float ScaleFactor = 0.0001f;
    public int Health = 2;
    public EnemyMove EnemyMove;

    private void OnTriggerEnter(Collider other)
    {
        CollectableItem collectable = other.GetComponent<CollectableItem>();

        if (collectable)
        {
            if(collectable.isCollected == false)
            {
                collectable.OnCollectedByEnemy();
                collectable.transform.SetParent(transform);
                ChangePower(ScaleFactor, true);
                EnemyMove.OnCollect(collectable);
                
            }
            //return;
            //SnowManager.CollectSnow(other.GetComponent<Snow>());
            //AudioSource.pitch = Random.Range(0.8f, 1.2f);
            //AudioSource.Play();
        }

        Player player = other.GetComponentInParent<Player>();
        if (player)
        {
            
            EnemyMove.LoseSomeMass();
            return;
        }

        ActivatePhisicsOnContact activator = other.GetComponent<ActivatePhisicsOnContact>();
        if (activator)
        {
            activator.ActivatePhysics();
            return;
        }
    }
    private void FixedUpdate()
    {
        ControlScale();
    }
    public void TakeDamage(int value)
    {
        Health -= value;
        if(Health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
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
        transform.localScale = Vector3.Lerp(transform.localScale, targetVector, 10 * Time.deltaTime);
        //Radius = Power * 0.12f;
        //}
    }
}
