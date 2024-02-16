using System.ComponentModel.DataAnnotations;

namespace FootballLeagueManager.Models.Entities
{
    public interface IEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
