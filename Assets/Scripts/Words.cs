using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Words : MonoBehaviour
{
    public List<List<string>> wordList = new List<List<string>>()
    {
        new List<string>(){"Tatil","Plaj","Deniz","G�ne�","Yaz"},
        new List<string>(){"Kitap","Sayfa","Yazar","K�t�phane","Roman"},
        new List<string>(){"Pasta","Tatl�","Krem","�ikolata","F�r�n"},
        new List<string>(){"Bisiklet","Tekerlek","Pedal","S�rmek","Yol"},
        new List<string>(){"M�zik","�ark�","Enstr�man","Konser","Nota"}
    };
}
