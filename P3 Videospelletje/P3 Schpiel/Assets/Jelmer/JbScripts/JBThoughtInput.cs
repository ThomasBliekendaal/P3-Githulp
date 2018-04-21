using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JBthought",menuName = "JBThought")]
public class JBThoughtInput : ScriptableObject {
    [TextArea(2,3)]
    public string[] text;
}
