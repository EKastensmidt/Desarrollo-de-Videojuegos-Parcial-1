using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour, ISubject
{
    [SerializeField] ActorStats stats;
    public ActorStats Stats { get => stats; set => stats = value; }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    public virtual void Move(Vector3 direction)
    {
        transform.Translate(direction * stats.Speed * Time.deltaTime, Space.World);
    }

    public virtual void Rotate (Quaternion rotation)
    {
        transform.rotation = rotation;
    }

    public virtual void Shoot(GameObject bulletEmitter,GameObject bullet ,float bulletSpeed)
    {
        GameObject instBullet = Instantiate(bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation);
        Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
        instBulletRigidbody.AddForce(bulletEmitter.transform.forward * bulletSpeed);
    }

    protected virtual void DamageTaken(Actor attacker)
    {
        
    }

    protected virtual void Die()
    {
        GameEvents.instance.Death();
    }

    #region Observer

    private List<IObserver> _observers = new List<IObserver>();
    public List<IObserver> Observers => _observers;

    public void Notify(IEvent ev)
    {
        foreach (var obeserver in _observers)
        {
            obeserver.OnNotify(this, ev);
        }
        
    }

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
        
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }
    #endregion
}
