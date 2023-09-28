# BKK-Futar-display
This app is a simulation of the displays of BKK found in Budapest. The backend is written in F#, while the frontend is written in Blazor (C#).

The program is in hungarian, and as such, this readme will be written in hungarian aswell.
If you are still interested, i would be more than happy to provide an english translation later.

# BKK Futár kijelző szimuláció
Ez az alkalmazás a Budapesten található LCD-s Futár kijelzők szimulációja, egy adott megálló (vagy csomópont) valós idejű indulásait mutatja, a megszokott stílust rekreálva.

Az alapja F#-ban készült, míg a UI Blazor segítségével készült.

A használathoz szükséges egy **Futár API kulcs**, ami jelenleg az apiHandler.fs-ben, a stopDeparturesUrl végén van hardcode-olva, ezt később ki fogom szervezni egy egyszerű txt fájlba, az egyszerűbb átírás miatt.

A követhető megállókat a **megallok.json** fájlba lehet felvinni.

A programon belül a megálló nevére kattintva lehet másik megállót választani, valamint egy alternatív, fiktív-retro stílusra is át lehet váltani.
