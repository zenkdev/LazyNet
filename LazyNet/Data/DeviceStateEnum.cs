using System.ComponentModel.DataAnnotations;

namespace Dekart.LazyNet
{
    public enum DeviceStateEnum
    {
        [Display(Name = @"Эксплуатируется")]
        Operated = 0,
        [Display(Name = @"Простаивает")]
        Idle = 1,
        [Display(Name = @"Неисправно")]
        Broken = 2,
        [Display(Name = @"Ремонтируется")]
        Repairing = 3,
    }
}