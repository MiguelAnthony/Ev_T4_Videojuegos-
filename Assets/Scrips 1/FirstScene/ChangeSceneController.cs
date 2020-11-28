using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneController : MonoBehaviour
{
   public GestorNivelesController gestor_niveles;
   public void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.tag == "Knight")
      {
         //Debug.Log("Collisiono para la otra scena");
         gestor_niveles.CargarSiguienteNivel();
      }
   }
}
