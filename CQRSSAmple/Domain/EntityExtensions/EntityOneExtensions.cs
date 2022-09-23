using CQRSSAmple.Domain.Entity;
using CQRSSAmple.Domain.EntityDTO;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CQRSSAmple.Domain.EntityExtensions
{
    public static class EntityOneExtensions
    {
        public static EntityOneDTO ToDTO(this EntityOne entity)
        {
            return new EntityOneDTO()
            {
                ID = entity.ID,
                FieldOne = entity.FieldOne,
                FieldDTOOne = "AAA"
            };
        }
    }
}