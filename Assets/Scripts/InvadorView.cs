using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvadorView : MonoBehaviour
{
    private InvadorBase m_Invador;

    public InvadorBase Invador => m_Invador;

    public void AttachBase(InvadorBase invador) => m_Invador = invador;

    public void Die()
    {
        Destroy(gameObject);
    }
}
