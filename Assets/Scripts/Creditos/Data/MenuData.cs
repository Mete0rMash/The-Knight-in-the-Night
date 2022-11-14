using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMenuData", menuName = "Data/Menu Data/Base Data")]
public class MenuData : ScriptableObject
{
    [Header("Opciones Menu")]
    public bool juegoEnPausa = false;
    public bool creditos = false;
}
