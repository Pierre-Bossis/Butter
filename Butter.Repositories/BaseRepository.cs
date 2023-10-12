using Butter.DataAccess;
using Butter.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butter.Repositories
{
    /// <summary>
    /// Classe de base pour les actions sur EF Core
    /// implémentant l'interface générique <seealso cref="IRepo{T, U}"/>
    /// </summary>
    /// <typeparam name="T">Le type d'entité</typeparam>
    /// <typeparam name="U">Le type de la PK dans la DB</typeparam>
    public abstract class BaseRepository<M,T, U> : IRepo<M,T, U>
        where T:class         
    {
         
        private readonly ButterContext _ctx;
        public BaseRepository(string cnstr)
        {
            _ctx = new ButterContext(cnstr);
        }


        /// <summary>
        /// Permet de récupérer tous les enregistrement dans la Db
        /// </summary>
        /// <returns>un <see cref="IEnumerable{T}"/> contenant les données</returns>
        public IEnumerable<M> Get()
        {
            
            // Récupérer la collection de données
            return _ctx.Set<T>().ToList().Select(s=> ToModel(s)).AsEnumerable<M>();


        }

        /// <summary>
        /// Permet de récupérer 1 enregistrement basé sur sa clé
        /// </summary>
        /// <param name="id">l'identifiant de l'enregistrement recherché</param>
        /// <returns>une instance de T ou NULL</returns>
        public M GetById(U id)
        {
             
            // Récupérer la collection de données
            return ToModel(_ctx.Set<T>().Find(id));

        }

        /// <summary>
        /// Permet d'ajouter une entité dans notre db
        /// </summary>
        /// <param name="item">L'entité à ajouter</param>
        public void Add(M item)
        {
           
            //2 Ajouter mon item dans le dbset correspondant
            _ctx.Set<T>().Add(ToEntite(item));
            //3 Save
            _ctx.SaveChanges();
        }

        /// <summary>
        /// Permet de supprimer un enregistrement basé sur l'identifiant
        /// </summary>
        /// <param name="id">l'identifiant de l'élément a supprimer</param>
        public void Delete(U id)
        {
             
            //1.1 Retrouver l'item correspondant
            T item = _ctx.Set<T>().Find(id);
            //2 Supprimer mon item dans le dbset correspondant
            _ctx.Set<T>().Remove(item);
            //3 Save
            _ctx.SaveChanges();
        }

      
        /// <summary>
        /// Permet de mettre à jour une entité
        /// </summary>
        /// <param name="item">L'entité a mettre à jour</param>
        public void Update(M item)
        {
            
            //2 MAJ mon item dans le dbset correspondant
            _ctx.Set<T>().Update(ToEntite(item));
            //3 Save
            _ctx.SaveChanges();
        }


        public abstract M ToModel(T entite);
        public abstract T ToEntite(M model);
    }
}
