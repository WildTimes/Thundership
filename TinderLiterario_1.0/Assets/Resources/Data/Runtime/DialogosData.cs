using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
/// 
[System.Serializable]
public class DialogosData
{
  [SerializeField]
  string[] frases_player = new string[0];
  public string[] Frases_player { get {return frases_player; } set { frases_player = value;} }
  
  [SerializeField]
  string[] respostas_friend = new string[0];
  public string[] Respostas_friend { get {return respostas_friend; } set { respostas_friend = value;} }
  
  [SerializeField]
  int linhainicio;
  public int Linhainicio { get {return linhainicio; } set { linhainicio = value;} }
  
}