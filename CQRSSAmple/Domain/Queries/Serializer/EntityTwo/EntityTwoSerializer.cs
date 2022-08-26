using System.Collections.Generic;
using System.Linq;
using CQRSSAmple.Domain.EntityDTO;
using Microsoft.EntityFrameworkCore;

namespace CQRSSAmple.Domain.Queries.Serializer.EntityTwo
{
    public class EntityTwoSerializer : IEntityTwoSerializer
    {
        public List<EntityTwoDTO> SerializeList(ICollection<Entity.EntityTwo> toSerialize)
        {
            return SerializeList(toSerialize.ToList());
        }

        public List<EntityTwoDTO> SerializeList(DbSet<Entity.EntityTwo> toSerialize)
        {
            return SerializeList(toSerialize.ToList());
        }
        
        public List<EntityTwoDTO> SerializeList(List<Entity.EntityTwo> toSerialize)
        {
            var result = new List<EntityTwoDTO>();
            foreach (var elem in toSerialize)
            {
                var serialized = SerializeSingle(elem);
               
                result.Add(serialized);
            }
            return result;
        }
        
        public  EntityTwoDTO SerializeSingle(Entity.EntityTwo toSerialize)
        {
            var result = new EntityTwoDTO()
            {
                ID = toSerialize.ID,
                FieldOneEntityTwo = toSerialize.FieldOneEntityTwo,
                FieldDTOEntityTwoDTO = toSerialize.FieldOneEntityTwo + "DTO"
            };
            return result;
        }
    }
}