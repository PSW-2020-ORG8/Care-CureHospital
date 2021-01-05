using Backend.Model.Tender;
using IntegrationAdapters.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapters.Mapper
{
    public class OfferMapper
    {
        public static OfferDto OfferToOfferDto(Offer offer)
        {
            OfferDto dto = new OfferDto();
            dto.Id = offer.Id;
            dto.MedicamentId = offer.MedicamentId;
            dto.Price = offer.Price;
            dto.Quantity = offer.Quantity;
            dto.Comment = offer.Comment;
            return dto;
        }

        public static Offer OfferDtoToOffer(OfferDto dto)
        {
            Offer offer = new Offer();
            offer.Id = dto.Id;
            offer.MedicamentId = dto.MedicamentId;
            offer.Price = dto.Price;
            offer.Quantity = dto.Quantity;
            offer.Comment = dto.Comment;
            return offer;
        }
    }
}
