using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicPlatformAPI_V3.Models
{
    public class EveryDataAndNews
    {
        [Key]
        public string Date { get; set; }
        public int HuBei { get; set; }
        public int GuangDong { get; set; }
        public int ZheJiang { get; set; }
        public int HuNan { get; set; }
        public int HeNan { get; set; }
        public int AnHui { get; set; }
        public int ChongQing { get; set; }
        public int ShanDong { get; set; }
        public int JiangXi { get; set; }
        public int SiChuan { get; set; }
        public int JiangSu { get; set; }
        public int BeiJing { get; set; }
        public int FuJian { get; set; }
        public int ShangHai { get; set; }
        public int GuangXi { get; set; }
        public int HeBei { get; set; }
        public int Sanxi { get; set; }
        public int YunNan { get; set; }
        public int HaiNan { get; set; }
        public int HeiLongJiang { get; set; }
        public int LiaoNing { get; set; }
        public int ShanXi { get; set; }
        public int TianJin { get; set; }
        public int GanSu { get; set; }
        public int NeiMengGu { get; set; }
        public int XinJiang { get; set; }
        public int NingXia { get; set; }
        public int JiLin { get; set; }
        public int GuiZhou { get; set; }
        public int QingHai { get; set; }
        public int XiZang { get; set; }
        public int AoMen { get; set; }
        public int XiangGang { get; set; }
        public int TaiWan { get; set; }
        public string News { get; set; }
    }
}
