using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Weapon : MonoBehaviour
{
    public PlayerScript player;

    public int ammo = 3;
    public GameObject projectile;
    public Transform tip;
    public float recoil = 100f;
    public float delay = 0;
    public float shootForce = 2000f;
    protected bool readyToShoot = true;

    public float destoryTime = 0f;
    
    protected Vector3 scale;

    void Start()
    {
        player = transform.parent.GetComponent<PlayerScript>();
        player.weapon = this;
        player.playerAnimation.WieldAnimation();
        scale = transform.localScale;
    }

    void OnDestroy()
    {
        player.weapon = null;
        player.playerAnimation.StopWieldAnimation();
    }

    public void FixedUpdate()
    {
        if(player == null) return;
        Rotate(player.playerInput.input.aim);

        if(player.playerInput.input.fire == 0  || !readyToShoot) return;
        Fire(player.playerInput.input);
    }

    public virtual void Fire(MyInput input)
    {
        readyToShoot = false;
        Invoke(nameof(Reload), delay);
        ammo--;
        if(ammo <= 0)
        {
            StartCoroutine(nameof(DestroyWeapon));
        }
    }

    public void Reload()
    {
        readyToShoot = true;
    }

    public virtual void Rotate(Vector2 direction)
    {
        
    }

    IEnumerator DestroyWeapon()
    {
        yield return new WaitForSeconds(0.01f);
        Destroy(this.gameObject, destoryTime);
    }
}
