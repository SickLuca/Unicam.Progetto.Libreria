using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Application.Abstractions.Services
{
    /// <summary>
    /// Interfaccia implementata dall'entità Libro al fine di esporre i servizi necessari alle web api.
    /// </summary>
    public interface ILibroService
    {
        /// <summary>
        /// Questo metodo è volto alla restituzione di una lista di oggetti di tipo Libro paginata in base
        /// a dei parametri passati nella chiamata.
        /// </summary>
        /// <param name="from">Indice di partenza della paginazione         </param>
        /// <param name="num">Numero di libri da recuperare                 </param>
        /// <param name="name">Nome del libro                               </param>
        /// <param name="author">Autore del libro                           </param>
        /// <param name="publicationDate">Data di pubblicazione del libro   </param>
        /// <param name="editor">Editore del libro                          </param>
        /// <param name="categoryName">Categorie passate per id             </param>
        /// <param name="totalNum">Quante sono le pagine                    </param>
        /// <returns>Una lista di oggetti libro paginata in base a from e num</returns> 
        List<Libro> GetLibri(int from, int num, string? name, string? author, DateTime? publicationDate, string? editor, string? categoryName, out int totalNum);
        
        
        
        
        
        /// <summary>
        /// Metodo utilizzato per l'aggiunta di un libro al database
        /// </summary>
        /// <param name="libro">L'oggetto Libro che vogliamo aggiungere</param>
        /// <param name="categorieIds">Gli Id delle sue categorie</param>
        void AddLibro(Libro libro, List<int> categorieIds);
        
        
        
        /// <summary>
        /// Metodo utilizzato per la modifica di un libro già esistente nel database
        /// </summary>
        /// <param name="id">L'Id del libro che vogliamo modificare             </param>
        /// <param name="nome">Nuovo nome                                       </param>
        /// <param name="autore">Nuovo autore                                   </param>
        /// <param name="editore">Nuovo editore                                 </param>
        /// <param name="data">Nuova data di pubblicazione                      </param>
        /// <param name="CategorieIds">Nuovi Id di categorie già esistenti      </param>
        /// <returns>True se la modifica è andata a buon fine, false altrimenti </returns>
        public bool UpdateLibro(int id, string nome, string autore, string editore, DateTime data, List<int> CategorieIds);


        /// <summary>
        /// Metodo utilizzato per la rimozione di un libro esistente nel database
        /// </summary>
        /// <param name="id">L'Id del libro che vogliamo rimuovere</param>
        /// <returns>True se la rimozione è andata a buon fine, false altrimenti </returns>
        public bool RemoveLibro(int id);
    }

    
}
