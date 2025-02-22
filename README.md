# 🌪️ Windmill Rotation System

## 📌 Beschreibung
Dieses Unity-Skript steuert die Drehung mehrerer Windräder basierend auf ihrer X-Position.  
- Das erste Windrad beginnt sich zu drehen, wenn die **Leertaste** gedrückt wird.  
- Nachdem die Geschwindigkeit mit einem Button **gesperrt** wurde, startet das nächste Windrad.  
- Jedes Windrad dreht sich weiter in seiner **festgelegten Geschwindigkeit**.  
- Die **Lichtintensität** passt sich an die Geschwindigkeit an:  
  - **Maximale Geschwindigkeit** → Licht wird **extrem grell**!  
  - **Sofort dunkler**, wenn die Geschwindigkeit reduziert wird.  

## 🚀 Features
✅ Erstes Windrad startet mit **Leertaste**  
✅ Jedes neue Windrad beginnt erst, wenn das vorherige **gesperrt** wurde  
✅ **Lichtintensität verändert sich dynamisch** mit der Geschwindigkeit  
✅ Extrem helle Beleuchtung bei **maximaler Geschwindigkeit**  

## 🎮 Steuerung
| Taste / Button | Funktion |
|---------------|----------|
| **Leertaste** | Startet das erste Windrad |
| **Slider** | Regelt die Geschwindigkeit des aktuellen Windrads |
| **Button "Lock Speed"** | Sperrt die aktuelle Geschwindigkeit und startet das nächste Windrad |

## 🔧 Installation & Nutzung
1. **Füge das Skript** in ein GameObject in Unity ein.  
2. Weise dem Skript folgende Elemente zu:  
   - **`rotatingPart`** → Der Rotor des Windrads  
   - **`speedSlider`** → UI-Slider zur Geschwindigkeitssteuerung  
   - **`windmillLight`** → Das Licht, das sich je nach Geschwindigkeit anpasst  
   - **`lockSpeedButton`** → Button, um die Geschwindigkeit zu sperren  
3. Starte die Szene und **teste die Steuerung**!  

## 🛠️ Anpassungen
Falls das Licht noch stärker reagieren soll, kannst du in `UpdateWindmillLight()` mit **`Mathf.Pow()`** oder **`Lerp()`** experimentieren.

## 📜 Lizenz
Dieses Projekt ist für **Bildungszwecke** gedacht. Nutze es frei in deinen Unity-Projekten!  
