# Progetto Programmazione Enterprise

Questo progetto è stato realizzato per il modulo di Programmazione Enterprise presente nel corso di Paradigmi di Programmazione AA 2023-2024 presso Unicam.

## Libreria Paradigmi

Questo progetto è un'applicazione web per la gestione di una libreria. È stato sviluppato utilizzando ASP.NET Core e Entity Framework Core.

## Funzionalità

- Creazione di un utente (anonima senza autenticazione)
- Autenticazione
- Creazione di una Categoria (non possono esistere due categorie con lo stesso nome)
- Eliminazione di una Categoria (solamente se la categoria non contiene libri)
- Caricamento di un libro
- Modifica di un libro
- Eliminazione di un libro
- Ricerca di un libro in base alle seguenti proprietà (obbligatoria almeno un filtro):
  - Categoria
  - Nome del libro
  - Data di Pubblicazione
  - Autore

La ricerca dovrà paginare i risultati, in base ad un parametro passato nella chiamata.

## Come eseguire il progetto

1. Ripristinare il DB di cui può trovare il dump qui sulla cartella principale della repository git.
2. Cambiare la stringa di connessione presente nel progetto libreriaParadigmi.Web nel appsettings.json(nello specifico dovrebbe essere necessario cambiare solo il nome del server).
3. Avviare il progetto. Swagger si aprirà automaticamente.
4. Fare la chiamata per registrarsi.
5. Fare la chiamata per il login con email e password per ottenere quindi il token jwt.
6. Una volta ottenuto il token ed inserito si ha accesso a tutte le chiamate.