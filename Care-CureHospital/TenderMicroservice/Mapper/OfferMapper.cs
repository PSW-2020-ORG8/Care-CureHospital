using TenderMicroservice.Domain;
using TenderMicroservice.Dto;

namespace TenderMicroservice.Mapper
{
    public class OfferMapper
    {
        public static OfferDto OfferToOfferDto(Offer offer)
        {
            OfferDto dto = new OfferDto();
            dto.Id = offer.Id;
            dto.TenderId = offer.TenderId;
            dto.PharmacyName = offer.PharmacyName;
            dto.PharmacyEmail = offer.PharmacyEmail;
            dto.Price = offer.Price;
            dto.Quantity = offer.Quantity;
            dto.Comment = offer.Comment;
            dto.ActiveTender = offer.ActiveTender;
            return dto;
        }

        public static Offer OfferDtoToOffer(OfferDto dto)
        {
            Offer offer = new Offer();
            offer.Id = dto.Id;
            offer.TenderId = dto.TenderId;
            offer.PharmacyName = dto.PharmacyName;
            offer.PharmacyEmail = dto.PharmacyEmail;
            offer.Price = dto.Price;
            offer.Quantity = dto.Quantity;
            offer.Comment = dto.Comment;
            offer.ActiveTender = dto.ActiveTender;
            return offer;
        }
    }
}
