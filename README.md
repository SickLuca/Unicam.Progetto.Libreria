# Progetto Paradigmi Avanzati di Programmazione

Progetto sviluppato per il corso di Programmazione Enterprise presso Unicam durante l'anno accademico 2023-2024.  
Autore: Luca Repupilli

## Libreria Digitale

L'applicazione è un sistema completo per la gestione del catalogo di una libreria tramite Web API, implementato utilizzando ASP.NET Core e Entity Framework Core. Per la documentazione e il testing delle API, è integrato Swagger.

## Funzionalità Principali

- **Gestione degli Utenti**
  - Registrazione di un nuovo utente (anonima, senza autenticazione)
  - Autenticazione tramite JWT

- **Gestione delle Categorie**
  - Creazione di categorie uniche (non sono consentite categorie con lo stesso nome)
  - Eliminazione di una categoria (solo se la categoria è vuota, senza libri associati)

- **Gestione dei Libri**
  - Caricamento di nuovi libri nel catalogo
  - Modifica delle informazioni di un libro esistente
  - Eliminazione di un libro dal catalogo

- **Ricerca Avanzata**
  - Ricerca di libri basata su criteri specifici:
    - Categoria
    - Nome del libro
    - Data di Pubblicazione
    - Autore
  - Paginazione dei risultati per una navigazione più efficiente

## Guida per l'Esecuzione del Progetto

1. **Ripristinare il Database**
   - Utilizzare il file `dump.sql` fornito nel repository per ripristinare il database.

2. **Configurazione della Connessione al Database**
   - Modificare il nome del server nella stringa di connessione presente nel file `appsettings.json` del progetto `Unicam.Progetto.Libreria.Web`.

3. **Avvio dell'Applicazione**
   - Avviare il progetto. Swagger verrà aperto automaticamente nel browser predefinito.

4. **Registrazione di un Utente**
   - Utilizzare la chiamata API `/api/v1/Utenti/new` per registrare un nuovo utente, fornendo i dati richiesti.

5. **Autenticazione e Ottenimento del Token JWT**
   - Effettuare la chiamata API `/api/v1/Utenti/login` per ottenere il token JWT necessario per l'autenticazione.

6. **Autorizzazione con Token JWT**
   - Utilizzare il token JWT ottenuto per autorizzare le successive chiamate API e accedere a tutte le funzionalità del sistema.

7. **Esplorazione e Utilizzo delle Funzionalità**
   - Ora è possibile utilizzare tutte le funzionalità messe a disposizione dall'applicazione tramite le API documentate su Swagger.