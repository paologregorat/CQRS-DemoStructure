using System.Collections.Generic;
using System.Linq;
using CQRSSAmple.Domain.EntityDTO;
using Microsoft.EntityFrameworkCore;

namespace CQRSSAmple.Domain.Queries.Serializer.EntityOne
{
    public class EntityOneSerializer : IEntityOneSerializer
    {
        public List<EntityOneDTO> SerializeList(ICollection<Entity.EntityOne> toSerialize)
        {
            return SerializeList(toSerialize.ToList());
        }

        public List<EntityOneDTO> SerializeList(DbSet<Entity.EntityOne> toSerialize)
        {
            return SerializeList(toSerialize.ToList());
        }
        
        public List<EntityOneDTO> SerializeList(List<Entity.EntityOne> toSerialize)
        {
            var result = new List<EntityOneDTO>();
            foreach (var elem in toSerialize)
            {
                var serialized = SerializeSingle(elem);
               
                result.Add(serialized);
            }
            return result;
        }
        
        public  EntityOneDTO SerializeSingle(Entity.EntityOne toSerialize)
        {
            var result = new EntityOneDTO()
            {
                ID = toSerialize.ID,
                FieldOne = toSerialize.FieldOne,
                FieldDTOOne = "AAA"
            };
            return result;
        }
    }
}