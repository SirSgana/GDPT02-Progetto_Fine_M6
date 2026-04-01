Quello che è stato detto alla correzione di M3 originale: 

1) Per prendere il riferimento alla main camera basta fare Camera.main piuttosto che GameObject.FindGameObjectWithTag("MainCamera").GetComponent();

2) Quando devi controllare se c'è il life controller dopo che è avvenuta una collisione NON è una buona cosa costruire l'if in questo modo -> if(lifecontroller = collision.gameobject.GetComponent()) anche perchè poi in altri script l'hai scritto correttamente, ad esempio in PickupFireBall

3) I campi che sono public non hanno bisogno anche di SerializeField, forse volevi che il capo fosse privato?

4) Occhio alle variabili public e al naming convention

5) In EnemySlimeV3 hai invertito l'ordine logico prendendo prima il componente e solo successivamente verifichi il tag e questo potrebbe essere un problema, inoltre l'update presente in questa classe è inutile

6) Il codice in generale non è pulitissimo ed in console ci sono vari errori NullReferenceException perchè in Enemy non c'è nessun controllo se il componente è null (riga 39)


Modifiche eseguite per la refactoring di M6: ATTENZIONE: tutte le modifiche sono in ordine cronologico e scritte al momento. è possibile che alcuni punti siano stati ripresi più volte per migliorare il codice perciò prima di arrivare a conclusioni premature si prega di osservare tutto il refactoring fino alla fine.

1) il 3° punto delle correzioni di M3: è stata trovata la voce [SerializeField] public float moveSpeed = 5f; su PlayerMovement. Convertito il public in private.

2) Rimosso lo script del CameraFollow ed aggiunta la Cinemachine in questo modo ho anche risolto il dover creare un'ambientazione attorno alla mappa del player creando una MapBound.
e rimuovendo il 1° problema della correzione di M3.

3) il punto 4° delle correzioni M3 lo controllerò durante il polish.

4) il punto 2° delle correzioni M3 è stato sistemando creando una variabile che compara il tag e poi successivamente prende il lifecontroller del player togliendo il "gameObject" ma tenendo questa dicitura: LifeController playerLife = collision.GetComponent<LifeController>(); successivamente è stata creata una funzione private che prendesse il LifeController fuori dalle funzioni OnTrigger ed OnCollision così da sintetizzare e pulire il codice.

5) Riordinato l'ordine di esecuzione dei delle funzioni dopo il tagplayer. Ora lo SlimeLV3 non dà più errori in console e funziona meglio (rimosso anche l'update)

6) risolti errori del null reference dello script Enemy.cs. 

Reputo tutte le annotazioni dei docenti per M3 risolte. Ora passo alla miglioria del gioco in sé.

- Creato Menu principale.



