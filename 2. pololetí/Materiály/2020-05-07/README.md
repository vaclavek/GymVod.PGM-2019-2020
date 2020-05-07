# Seminář 7. 5. 2020

**Záznam hodiny: [https://youtu.be/KTVONvpYo_k](https://youtu.be/KTVONvpYo_k)**

## Obsah

Na dnešní hodině jsme si zopakovali objektově orientované programování v C# a zadali domácí úkol z Grafiky a GUI.

## 1. Objektově orientované programování
Máte deklarované rozhraní *ITvar* takto:
```
public interface ITvar
{
	decimal VypoctiObsah();
	string VratInformace();
}
```

Vytvořte třídy **Kruh, Ctverec a Obdelnik**, které implementují toto rozhraní. Čtverec je speciální případ obdélníku, proto by měl od něj dědit. Přepište pouze ty metody, které jsou nutné.

Vytvořte libovolnou aplikaci, která 20x vytvoří náhodný z těchto objektů a vloží je do jednoho společného seznamu. Pro všechny tvary ze seznamu následně zavolejte obě metody a vypište uživateli výsledky.

## 2. Grafika a GUI
Vytvořte WinForm aplikaci, která bude mít v hlavním menu dva ovládací prvky:
1) tvar - kružnice/elipsa/čtverec
2) barva - bílá/žlutá/červená/zelená/modrá/černá

Zvolení prvku ovlivní, co se vykreslí po kliknutí do formuláře.

Ve formuláři bude možné zadat šířku pera a bude zde tlačítko, které smaže všechny tvary z formuláře.
Kliknutím do formuláře se vykreslí zvolený tvar a zvolené barvě a šířce pera.