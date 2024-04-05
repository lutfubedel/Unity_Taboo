using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Words : MonoBehaviour
{
    public List<List<string>> wordList = new List<List<string>>()
    {
        new List<string>(){"Tatil","Plaj","Deniz","Güneþ","Yaz"},
        new List<string>(){"Kitap","Sayfa","Yazar","Kütüphane","Roman"},
        new List<string>(){"Pasta","Tatlý","Krem","Çikolata","Fýrýn"},
        new List<string>(){"Bisiklet","Tekerlek","Pedal","Sürmek","Yol"},
        new List<string>(){"Müzik","Þarký","Enstrüman","Konser","Nota"}
    };
}
