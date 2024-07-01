using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Models.Context;

namespace Unicam.Progetto.Libreria.Models.Repositories
{

    /// <summary>
    /// Classe astratta che rappresenta un repository generico per le operazioni di base.
    /// </summary>
    /// <typeparam name="T">Il tipo di entità con cui il repository lavora. Deve essere una classe.</typeparam>
    public abstract class GenericRepository<T> where T : class
    {
        protected MyDbContext _ctx;
        public GenericRepository(MyDbContext ctx)
        {
            _ctx = ctx;
        }


        /// <summary>
        /// Aggiunge una nuova entità al contesto del database.
        /// </summary>
        /// <param name="entity">L'entità da aggiungere.</param>
        public void Aggiungi(T entity)
        {
            _ctx.Set<T>().Add(entity);
        }


        /// <summary>
        /// Ottiene un'entità dal contesto del database utilizzando il suo identificatore.
        /// </summary>
        /// <param name="id">L'identificatore dell'entità da ottenere.</param>
        /// <returns>L'entità corrispondente all'identificatore fornito.</returns>
        public T Ottieni(object id)
        {
            return _ctx.Set<T>()
                .Find(id);
        }


        /// <summary>
        /// Cancella un'entità dal contesto del database.
        /// </summary>
        /// <param name="entity">L'entità da cancellare.</param>
        public void Delete(T entity)
        {
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }


        /// <summary>
        /// Cancella un'entità dal contesto del database utilizzando il suo identificatore.
        /// </summary>
        /// <param name="id">L'identificatore dell'entità da cancellare.</param>
        public void Elimina(object id)
        {
            var entity = Ottieni(id);
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }


        /// <summary>
        /// Aggiorna lo stato di un'entità nel contesto del database.
        /// </summary>
        /// <param name="entity">L'entità da aggiornare.</param>
        public void Update(T entity)
        {
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }


        /// <summary>
        /// Salva tutte le modifiche apportate al contesto del database.
        /// </summary>
        public void Save()
        {
            _ctx.SaveChanges();
        }

    }
}
