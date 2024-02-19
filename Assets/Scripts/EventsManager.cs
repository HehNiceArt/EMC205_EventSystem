using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    #region IDK
    //private static EventsManager instance;
    //public static EventsManager Instance { get { return instance; } }

    //public delegate void PortalEvent();
    //public static event PortalEvent onKnifePortal = delegate { };
    //public static event PortalEvent onAxePortal = delegate { };
    //private void Awake()
    //{
    //    if (instance != null && instance != this)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //    else
    //    {
    //        instance = this;
    //    }
    //}

    //public void KnifePortal()
    //{
    //    onKnifePortal?.Invoke();
    //}
    //public void AxePortal()
    //{
    //    onAxePortal?.Invoke();
    //}
    #endregion

    
    public static EventsManager Instance { get; private set; }
    public delegate void PortalEvent();
    public static event PortalEvent OnKnifePortal = delegate { };
    public static event PortalEvent OnAxePortal = delegate { };
    public static event PortalEvent OnGunPortal = delegate { };


    private void Awake()
    {
        Instance = this;
    }
    public void KnifePortal()
    {
        OnKnifePortal?.Invoke();
    }

    public void AxePortal()
    {
        OnAxePortal?.Invoke();
    }
    public void GunPortal()
    {
        OnGunPortal?.Invoke();
    }
}
