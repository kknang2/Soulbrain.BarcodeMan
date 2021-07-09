using AutoMapper;
using Soulbrain.BarcodeMan.Authenticate;
using Soulbrain.BarcodeMan.Domain;
using Soulbrain.BarcodeMan.Dtos.Comment;
using Soulbrain.BarcodeMan.Dtos.MaterialGroup;
using Soulbrain.BarcodeMan.Dtos.MaterialType;
using Soulbrain.BarcodeMan.Dtos.Product;
using Soulbrain.BarcodeMan.Dtos.WebBarCode;
using Soulbrain.BarcodeMan.Dtos.WebBoard;
using Soulbrain.BarcodeMan.Dtos.WebNotice;
using System.Linq;

namespace Soulbrain.BarcodeMan
{
    public static class DtoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(m => {
                m.CreateMap<VendorP, User>()
                 .ForMember(dest => dest.VendorNameKo, opt => opt.MapFrom(src => src.Vendor.VendorName));

                m.CreateMap<WebNotice, WebNoticeListItem>()
                 .ForMember(dest => dest.HasAttachment, opt => opt.MapFrom(src => src.Attachments.FirstOrDefault() != null));
                m.CreateMap<WebNotice, WebNoticeDetail>();

                m.CreateMap<WebBoard, WebBoardListItem>()
                 .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments.Count))
                 .ForMember(dest => dest.HasAttachment, opt => opt.MapFrom(src => src.Attachments.FirstOrDefault() != null));
                m.CreateMap<WebBoard, WebBoardDetail>();

                m.CreateMap<CommentInput, WebBoardComment>();

                m.CreateMap<WebBarCodeInput, WebBarCode>();

                m.CreateMap<Product, PopupProductListItem>()
                 .ForMember(dest => dest.ProductNameKo, opt => opt.MapFrom(src => src.ProductName))
                 .ForMember(dest => dest.PackingUnitCode, opt => opt.MapFrom(src => src.ProductVendors.FirstOrDefault().PackingUnitCode))
                 .ForMember(dest => dest.PackingQty, opt => opt.MapFrom(src => src.ProductVendors.FirstOrDefault().PackingQty))
                 .ForMember(dest => dest.VendorCode, opt => opt.MapFrom(src => src.ProductVendors.FirstOrDefault().PrdVendorCode));

                m.CreateMap<MaterialGroup, MaterialGroupSelectItem>()
                 .ForMember(dest => dest.MaterialGroupNameKo, opt => opt.MapFrom(src => src.MaterialGroupName));

                m.CreateMap<MaterialType, MaterialTypeSelectItem>()
                 .ForMember(dest => dest.MaterialTypeNameKo, opt => opt.MapFrom(src => src.MaterialTypeName));
            });
        }
    }
}
