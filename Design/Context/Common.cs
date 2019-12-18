using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Context
{
    public class Common
    {
        private static ShopGameContext _Instance=new ShopGameContext();

        public static ShopGameContext Instance { get => _Instance; set => _Instance = value; }
    }
}
