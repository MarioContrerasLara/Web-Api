using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Web.Contracts;
using Web.Models;
using Newtonsoft.Json;

namespace Web.Repositories
{
    public class ActorRepository : IActorRepository
    {
        const string JSON_PATH = @"C:\Users\I44099\OneDrive - Verisk Analytics\Documents\LemonCode\C#\Ejercicios\Web API\Web\Web\Resources\Actores.json";
        public void AddActor(Actor actor)
        {
            var actores = GetActors();
            var existeActor = actores.Exists(a => a.Id == actor.Id);
            if (existeActor)
            {
                throw new Exception("Ya existe un autor con ese id");
            }
            actores.Add(actor);
            UpdateActores(actores);
        }

        public void DeleteActor(int id)
        {
            var actores = GetActors();
            var actor = actores.Find(a => a.Id == id);
            if (actor == null)
            {
                throw new Exception("No existe un actor con ese id");
            }
            actores.Remove(actor);
            UpdateActores(actores);
        }

        public Actor GetActorById(int id)
        {
            var actores = GetActors();
            var actor = actores.Find(a => a.Id == id);
            if (actor == null)
            {
                throw new Exception("No existe un actor con ese id");
            }
            return actor;           
            
        }

        public List<Actor> GetActors()
        {
            //throw new System.NotImplementedException();
            try
            {
                var actoresFromFile = GetActorsFromFile();
                List<Actor> actores = JsonConvert.DeserializeObject<List<Actor>>
                (actoresFromFile);
                return actores;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateActor(int id, Actor actorActualizado)
        {
            var actores = GetActors();
            var actor = actores.Find(a => a.Id == id);
            if (actor == null)
            {
                throw new Exception("No existe un actor con ese id");
            }
            UpdateActores(actores);
        }


        private string GetActorsFromFile()
        {
            var json = File.ReadAllText(JSON_PATH);
            return json;
        }
        private void UpdateActores(List<Actor> actores)
        {
            var actoresJson = JsonConvert.SerializeObject(actores,Formatting.Indented);
            File.WriteAllText(JSON_PATH, actoresJson);
        }
    }
}
