using LEMV.Domain.Entities.Core;
using System;
using System.Collections.Generic;

namespace LEMV.Domain.Entities
{
    public class Project : Entity, IAggregateRoot
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Resume { get; set; }
        public string UrlImage { get; set; }
        public string AuthorName { get; set; }
        public virtual MediaInfo Media { get; set; }

        public ICollection<ProjectStep> Manual { get; set; }
        public virtual string SkillId { get; set; }
        public virtual ICollection<string> AbilitieIds { get; set; }

        public List<string> Tags { get; set; }

        public Project() { }

        public Project(
            string id,
            string titulo,
            string descricao,
            string resume,
            string urlImage,
            string nomeAutor,
            MediaInfo media,
            List<string> tags,
            ICollection<ProjectStep> manual = null)
        {

            Id = id;
            UrlImage = urlImage;
            Title = titulo;
            Description = descricao;
            AuthorName = nomeAutor;
            Resume = resume;
            Manual = manual ?? new List<ProjectStep>();
            Media = media;
            Tags = tags;
        }

        public void AdicionarPassos(ProjectStep passo)
        {
            Manual.Add(passo);
        }

        public void RemoverPassos(ProjectStep passo)
        {
            Manual.Remove(passo);
        }
    }
}