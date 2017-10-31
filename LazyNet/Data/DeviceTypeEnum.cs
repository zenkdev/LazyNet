using System.ComponentModel.DataAnnotations;

namespace Dekart.LazyNet
{
    public enum DeviceTypeEnum
    {
        [Display(ResourceType = typeof(ConstStrings), Name = "Computer")]
        Computer = 0,
        [Display(ResourceType = typeof(ConstStrings), Name = "Monitor")]
        Monitor = 1,
        [Display(ResourceType = typeof(ConstStrings), Name = "Networking")]
        Networking = 2,
        [Display(ResourceType = typeof(ConstStrings), Name = "VideoSurveillance")]
        VideoSurveillance = 3,
        [Display(ResourceType = typeof(ConstStrings), Name = "AccessControl")]
        AccessControl = 4,
        [Display(ResourceType = typeof(ConstStrings), Name = "Mobile")]
        Mobile = 5,
        [Display(ResourceType = typeof(ConstStrings), Name = "Printer")]
        Printer = 6,
        [Display(ResourceType = typeof(ConstStrings), Name = "Miscellaneous")]
        Miscellaneous = 7
    }
}