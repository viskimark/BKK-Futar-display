# BKK-Futar-display

---

**You can now try it online! / Már online is ki tudod próbálni!**

**https://bkk-futar-display.vercel.app/**

---

This app is a simulation of the displays of BKK found in Budapest. The backend is written in F#, while the frontend is written in Blazor (C#).

The program is in hungarian, and as such, this readme will be written in hungarian aswell.
If you are still interested, i would be more than happy to provide an english translation later.

# BKK Futár kijelző szimuláció
Ez az alkalmazás a Budapesten található LCD-s Futár kijelzők szimulációja, egy adott megálló (vagy csomópont) valós idejű indulásait mutatja, a megszokott stílust rekreálva.

Az alapja F#-ban készült, míg a UI Blazor segítségével készült.

![image of the program running](https://github.com/viskimark/BKK-Futar-display/blob/main/img.png?raw=true)

A használathoz szükséges egy **Futár API kulcs**, amihez szükséges egy key.txt fájl létrehozása (alapesetben a BlazorUI mappán belül), s a saját kulcs beillesztése.

A követhető megállókat a **megallok.json** fájlba lehet felvinni. A követett megállókhoz meg lehet adni, hogy milyen kijáratot párosítson mellé a program (ld. bemutató kép).

A programon belül a megálló nevére kattintva lehet másik megállót választani, valamint egy alternatív, fiktív-retro stílusra is át lehet váltani.

Lehet fiktív járatokat létrehozni, amik alapesetben a **fiktiv.json** fájlban vannak. A program felépítéséből adódóan a megallok.json fájlban egyszerűen fel lehet venni fiktív megállókat is,
ezáltal a saját járatainkat nem feltétlen csak létező megállóból lehet követni.

![image of fictive routes](https://github.com/viskimark/BKK-Futar-display/blob/main/fiktiv.png?raw=true)