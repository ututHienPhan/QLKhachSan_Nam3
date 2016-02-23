using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguoiDung
    {
        private string tk;

        public string Tk
        {
            get { return tk; }
            set { tk = value; }
        }

        private string phanloai;

        public string Phanloai
        {
            get { return phanloai; }
            set { phanloai = value; }
        }

        private static NguoiDung onlyuser;

        private NguoiDung()
        { }


        public static NguoiDung GetND(string tk, string loai)
        {
            if (onlyuser == null)
            {
                onlyuser = new NguoiDung();
                onlyuser.tk = tk;
                onlyuser.phanloai = loai;
            }
            return onlyuser;
        }

        public static NguoiDung GetND()
        {
            return onlyuser;
        }
    }
}
