using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TradeApp.Entities
{
    public partial class Product
    {
        public Avalonia.Media.Imaging.Bitmap Image{
            get{
                if(ProductPhoto!=null&&ProductPhoto.Length>0){
                    Stream stream =new MemoryStream(ProductPhoto);
                    return new Avalonia.Media.Imaging.Bitmap(stream);
                }
                else{
                    return new Avalonia.Media.Imaging.Bitmap("images/no_photo.jpg");
                }
            }
        }
    }
}