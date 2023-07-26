using LEMV.Domain.Entities.Core;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LEMV.Domain.Entities
{
    public class ProjectStep : IAggregate
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<string> Materials { get; set; }

        public ProjectStep()
        {
        }

        public ProjectStep(int ordem, string nomeEtapa, string descricao, ICollection<string> materiais = null)
        {
            Order = ordem;
            Name = nomeEtapa;
            Description = descricao;
            Materials = materiais ?? new List<string>();
        }

        public void AdicionarMateriais(string materiais)
        {
            Materials.Add(materiais);
        }

        public void RemoverMateriais(string materiais)
        {
            Materials.Remove(materiais);
        }
    }
}