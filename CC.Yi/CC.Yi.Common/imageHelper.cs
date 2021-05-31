using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Drawing;

namespace CC.Yi.Common
{
    public class SimilarPhoto
    {
        Image SourceImg;
        public SimilarPhoto(string filePath)
        {
            SourceImg = Image.FromFile(filePath);
        }
        public SimilarPhoto(Stream stream)
        {
            SourceImg = Image.FromStream(stream);
        }
        public String GetHash()
        {
            Image image = ReduceSize();
            Byte[] grayValues = ReduceColor(image);
            Byte average = CalcAverage(grayValues);
            String reslut = ComputeBits(grayValues, average);
            return reslut;
        }
        // Step 1 : Reduce size to 8*8
        private Image ReduceSize(int width = 8, int height = 8)
        {
            Image image = SourceImg.GetThumbnailImage(width, height, () => { return false; }, IntPtr.Zero);
            return image;
        }
        // Step 2 : Reduce Color
        private Byte[] ReduceColor(Image image)
        {
            Bitmap bitMap = new Bitmap(image);
            Byte[] grayValues = new Byte[image.Width * image.Height];
            for (int x = 0; x < image.Width; x++)
                for (int y = 0; y < image.Height; y++)
                {
                    Color color = bitMap.GetPixel(x, y);
                    byte grayValue = (byte)((color.R * 30 + color.G * 59 + color.B * 11) / 100);
                    grayValues[x * image.Width + y] = grayValue;
                }
            return grayValues;
        }
        // Step 3 : Average the colors
        private Byte CalcAverage(byte[] values)
        {
            int sum = 0;
            for (int i = 0; i < values.Length; i++)
                sum += (int)values[i];
            return Convert.ToByte(sum / values.Length);
        }
        // Step 4 : Compute the bits
        private String ComputeBits(byte[] values, byte averageValue)
        {
            char[] result = new char[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < averageValue)
                    result[i] = '0';
                else
                    result[i] = '1';
            }
            SourceImg.Dispose();
            return new String(result);
        }
        // Compare hash
        public static Int32 CalcSimilarDegree(string a, string b)
        {
            if (a.Length != b.Length)
                throw new ArgumentException();
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    count++;
            }
            return count;
        }
    }
    public static class imageHelper
    {
        public static int Compare(string filePath1, string filePath2)
        {
            SimilarPhoto photo1 = new SimilarPhoto(filePath1);
            SimilarPhoto photo2 = new SimilarPhoto(filePath2);
            return SimilarPhoto.CalcSimilarDegree(photo1.GetHash(), photo2.GetHash());
        }
        public static bool ByStringToSave(string name, string iss)
        {
            iss = iss.Replace("data:image/png;base64,", "").Replace("data:image/jgp;base64,", "")
                .Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "");
            byte[] arr = Convert.FromBase64String(iss);
            MemoryStream ms = new MemoryStream(arr);
            Bitmap bmp = new Bitmap(ms);
            string StudentWorkImages = "StudentWorkImages";

            if (Directory.Exists(@"./wwwroot/" + StudentWorkImages) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(@"./wwwroot/" + StudentWorkImages);
            }



            bmp.Save(@"./wwwroot/" + StudentWorkImages + "/" + name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Close();
            return true;
        }
        public static bool CreateZip()
        {
            string file_path = @"./wwwroot/StudentWorkImages.zip";
            string file_path2 = @"./wwwroot/StudentWorkImages/";
            if (File.Exists(file_path))
            {
                File.Delete(file_path);
            }

            ZipFile.CreateFromDirectory(file_path2, file_path);
            return true;
        }
        public static bool DeleteAll()
        {
            string file_path = @"./wwwroot/StudentWorkImages/";
            if (Directory.Exists(file_path))
            {
                DelectDir(file_path);
                return true;
            }
            else
                return false;
        }
        public static bool DeleteByString(string name)
        {
            File.Delete(@"./wwwroot/StudentWorkImages/" + name + ".jpg");
            return true;
        }
        public static void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
        }
    }
}
