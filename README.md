# Movie Search

Dieses Projekt enthält eine Reihe von Funktionen, die verschiedene Aufgaben ausführen, wie z.B. das Abrufen von Filminformationen von der OMDB-API und das Anzeigen dieser Informationen in einer Benutzeroberfläche.

## Hauptfunktionen

1. `Form1()`: Diese Funktion initialisiert die Komponenten der Form.

2. `Form1_Load(object sender, EventArgs e)`: Diese Funktion wird aufgerufen, wenn die Form geladen wird und setzt den Standardwert für comboBox2.

3. `button1_Click(object sender, EventArgs e)`: Diese Funktion wird aufgerufen, wenn der Button1 geklickt wird. Sie ruft die Funktionen `abfrage(i)` und `comboboxsearch()` auf.

4. `comboboxsearch()`: Diese Funktion sucht nach einem zufälligen Film mithilfe der OMDB-API und fügt den Titel des Films zur comboBox1 und zur Liste hinzu.

5. `button2_Click(object sender, EventArgs e)`: Diese Funktion wird aufgerufen, wenn der Button2 geklickt wird. Sie ruft die Funktion `abfrage(b)` auf.

6. `comboBox2_SelectedIndexChanged(object sender, EventArgs e)`: Diese Funktion wird aufgerufen, wenn das ausgewählte Element in comboBox2 geändert wird. Sie ändert die Sichtbarkeit verschiedener Steuerelemente basierend auf dem ausgewählten Index.

7. `abfrage(bool check)`: Diese Funktion führt eine Abfrage durch die OMDB-API durch und zeigt die abgerufenen Filminformationen in textBox2 an. Sie lädt auch das Filmposter herunter und zeigt es in pictureBox1 an.

Bitte ersetzen Sie `"Your-APIkey"` durch Ihren tatsächlichen API-Schlüssel, bevor Sie diese Funktionen verwenden.
